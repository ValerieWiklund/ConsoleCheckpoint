using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;

namespace ConsoleAdventure.Project.Services
{
  public class GameService : IGameService
  {
    private IGame _game { get; set; }
    public List<string> Messages { get; set; }


    public void Go(string direction)
    {
      //  get your template for printing the room you are in.

      _game.CurrentRoom = _game.CurrentRoom.Go(direction);
      string to = _game.CurrentRoom.Name;
      Look();

    }

    public void Help()
    {
      Messages.Add("GO + (direction) - moves you from room to room");
      Messages.Add("USE + (Item name) - allows you to use an item in the room or from your inventory");
      Messages.Add("TAKE + (Item name) - adds the item to your inventory");
      Messages.Add("LOOK - shows you the description of the room you are in");
      Messages.Add("INVENTORY -  shows you all the items in your inventory");
      Messages.Add("HELP - shows a list of commands and actions");
      Messages.Add("QUIT - quits the game");
    }

    public void Inventory()
    {
      Messages.Add("\n \n Displaying Inventory:");
      if (_game.CurrentPlayer.Inventory.Count == 0)
      {
        Messages.Add("\n You do not have any items to use. \n");
      }
      else
      {
        Messages.Add(_game.CurrentPlayer.GetTemplate());
      }
    }

    public void Look()
    {
      Messages.Add(_game.CurrentRoom.GetTemplate());
    }

    public void Quit()
    {
      Console.WriteLine("Thank you for playing");
      Environment.Exit(0);
    }
    ///<summary>
    ///Restarts the game 
    ///</summary>
    public void Reset()
    {
      throw new System.NotImplementedException();
    }

    public void Setup()
    {
      Messages.Add($"Welcome {_game.CurrentPlayer.Name}");
      Messages.Add("You were at an evening charity event for the Zoo. You were enojoying the evening so much, you didn't realize you are all alone. After looking at your watch, you realize the event has been over for awhile. There isn't anybody around to show you out.");
      Look();

    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      Messages.Add("Taking an Item");
      var hold = _game.CurrentRoom.Items;
      for (int i = 0; i < hold.Count; i++)
      {
        var temp = hold[i].Name;
        if (itemName == temp)
        {
          _game.CurrentPlayer.Inventory.Add(hold[i]);
          _game.CurrentRoom.Items.Remove(hold[i]);
          Messages.Add($"{itemName} have been added to your inventory");
        }
        else
        {
          Messages.Add("No such item");
        }
      }

    }
    ///<summary>
    ///No need to Pass a room since Items can only be used in the CurrentRoom
    ///Make sure you validate the item is in the room or player inventory before
    ///being able to use the item
    ///</summary>
    public void UseItem(string itemName)
    {
      for (int i = 0; i < _game.CurrentRoom.Items.Count; i++)
      {
        var temp = _game.CurrentRoom.Items[i].Name;
        Messages.Add($"value of {temp}");
        if (itemName != temp)
        {
          Messages.Add($"{itemName} is not in this room");
        }
        else
        {
          Messages.Add($"{itemName} is in this room.");
          for (int x = 0; x < _game.CurrentPlayer.Inventory.Count; x++)
          {
            var temp2 = _game.CurrentPlayer.Inventory[x].Name;
            if (itemName != temp2)
            {
              Messages.Add("That item is not available");
            }
          }
        }
      }


      // if (itemName == IItem)
      Messages.Add($" you just used {itemName}");
      // var hold = _game.CurrentRoom.UseItem(itemName);
      var hold = "";
      hold = _game.CurrentRoom.Usages[itemName];
      // _game.CurrentRoom.Exits.Add(hold);
      Messages.Add($"{hold}");
      // Messages.Add($"")



      Messages.Add("Using an Item \n");
    }







    //Constructor
    public GameService()
    {
      Messages = new List<string>();
      _game = new Game();
    }
  }
}
