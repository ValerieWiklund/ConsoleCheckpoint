using System.Collections.Generic;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Interfaces
{
  public interface IRoom
  {
    string Name { get; set; }
    string Description { get; set; }
    List<Item> Items { get; set; }
    Dictionary<string, IRoom> Exits { get; set; }
    // IDictionary<string, Dictionary<string, IRoom>> Usages { get; set; }
    Dictionary<string, string> Usages { get; set; }



    string GetTemplate();
    IRoom Go(string direction);
    IRoom UseItem(string itemName);
  }

}
