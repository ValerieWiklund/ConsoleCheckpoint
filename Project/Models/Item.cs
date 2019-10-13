using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Item : IItem
  {

    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<string, IRoom> Usages { get; set; }

    public Item(string name, string desc)
    {
      Name = name;
      Description = desc;
      Usages = new Dictionary<string, IRoom>();

    }

    public string GetTemplate()
    {
      string template = $"{Name}";
      return template;
    }







    // public IItem UseItem(string itemName)
    // {
    //   // if (Usages.Count != 0)
    //   // {
    //   //   return Usages[0];
    //   // }
    //   // return this;

    // }

  }
}