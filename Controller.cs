using System.Reflection.Emit;

namespace wander;

public struct Room {
  public Int32[] doors;
}

public struct GState {
  public Int32 arrows;
  public Int32 coins;
  public Int32 room;
  public Int32[] doors;
  public string warnings;
}

class Controller {

  GState gstate;
  
  
  static Room[] rooms = 
    new Room[]{
      new Room { doors = [ 1, 4 ]},
      new Room { doors = [ 1, 2 ]},
      new Room { doors = [ 2, 3 ]},
      new Room { doors = [ 3, 4, 1 ]},
    };

  static string[] warnings = {
    "",
    "I feel a breeze",
    "I hear bats",
    "I smell something"
  };
  
  public Controller() {
    this.gstate = new GState();
    this.gstate.arrows = 3;
    this.gstate.coins = 0;
    this.gstate.room = 0;
    this.gstate.doors = rooms[0].doors;
    this.gstate.warnings = "";
  }

  public GState GameState() {
    return this.gstate;
  }

  public Boolean isValidDoor(Int32 room) {
    return Array.FindIndex(this.gstate.doors, (val) => val == room) != -1;
  }

  public void Move(Int32 toRoom) {
    this.gstate.room = toRoom;
    this.gstate.warnings = warnings[toRoom];
    this.gstate.doors =  rooms[toRoom].doors;
    this.gstate.coins += 1;
  }

  public void Shoot(Int32 intoRoom) {
    Console.WriteLine("Not implemented - Shoot into room {0}", intoRoom);
  }
}