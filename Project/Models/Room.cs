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


    public string GetTemplate()
    {
      string template = $@"You are in the {Name} room. \n
      As you look around you see {Description}. In the room you see: \n ";
      foreach (var i in Items)
      {
        template += $"{i.Name} {i.Description}";
      }
      return template;
    }


    public Room(string name, string desc)
    {
      Name = name;
      Description = desc;
      Items = new List<Item>();
      Exits = new Dictionary<string, IRoom>();
    }


  }
}