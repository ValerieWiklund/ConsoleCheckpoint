using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Room : IRoom
  {

    public string Name { get; set; }
    public string Description { get; set; }
    public List<Item> Items { get; set; }
    public Dictionary<string, IRoom> Exits { get; set; }


    public void AddExit(IRoom, room)
    {
      CollectionExtensions.TryAdd(room.Name, room)
    }



    public Room(string name, string desc, List<Item> items, Dictionary<string, IRoom> exits)
    {
      Name = name;
      Description = desc;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }

  }
}