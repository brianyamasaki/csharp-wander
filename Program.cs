namespace wander;

class Program
{
    Controller controller;

    Program() {
        this.controller = new Controller();
    }

    static void Main(string[] args)
    {

        Program program = new Program();

        Console.WriteLine("Commands must be in the form a letter and separated by optional items by a space");
        while (program.GetCommand())
        {
            
        }
    }

    void DisplayGState() {
        GState gState = this.controller.GameState();
        string doors = String.Format("[ {0} ]", String.Join(", ", gState.doors));
        string roomAndInventory = String.Format("Room: {0}, Coins: {1}, Arrows: {2}, Doors to: {3}", gState.room, gState.coins, gState.arrows, doors);
        Console.WriteLine(roomAndInventory);
        if (gState.warnings.Length > 0) {
            Console.WriteLine(String.Format("Warning: {0}", gState.warnings));
        }
    }

    Boolean GetCommand() {
        this.DisplayGState();
        Console.WriteLine("(M)ove to rooms, (S)hoot Arrow or (Q)uit ?");
        var command = Console.ReadLine();
        Int32 room;
        if (command != null && command.Length > 0) {
            var tokens = command.Split(' ');
            switch (tokens[0][0]) {
                case 'm':
                case 'M':
                    room = int.Parse(tokens[1]);
                    if (this.controller.isValidDoor(room)) {
                        this.controller.Move(room);
                    } else {
                        Console.WriteLine("Invalid room");
                    }
                    break;
                case 's':
                case 'S':
                    room = int.Parse(tokens[1]);
                    if (this.controller.isValidDoor(room)) {
                        this.controller.Shoot(int.Parse(tokens[1]));
                    } else {
                        Console.WriteLine("Invalid Room");
                    }
                    break;
                case 'q':
                case 'Q':
                    return false;
                default:
                    Console.WriteLine("Commands must be in the form 'Command' 'room'");
                    break;
            }
        }
        return true;
    }

    
}
 