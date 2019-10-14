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
      if (to == "Tiger Den")
      {
        Console.Clear();
        Console.WriteLine(" \n \n You are unsure of where you are. As you move forward into the pen, you suddenly recognize where you are - the tiger's den. \nYou rush back to the door. \n \n It  won't open!! Soon, you are surrounded by the tigers. They don't pause to play with their food, they just pounce and ... you DIE. \n \n \n");
        Quit();
      }
      if (to == "Exit")
      {
        Console.Clear();
        Console.WriteLine(" \n \n Finally! The exit. You survived your ordeal and you are free. \n \n \n Congratulations for winning the game. \n \n \n");
        Quit();
      }
      if (to == "Giraffe Barn")
      {
        Messages.Add("It is very dark in here. There is no way to see if there are any exits or giraffes that might step on you or kick you.");
      }
      else if (to != "")
      {
        Look();
      }
      else
      {
        Messages.Add("Invalid Request");
        return;
      }




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
      Messages.Add($"\n \nWelcome! \n \n");
      Messages.Add("You were at an evening charity event for the Zoo. You were enjoying the evening so much, you didn't realize how late it was. Now, there isn't anybody else around to show you the way out. Hopefully you will be able to find your way out. \n");
      Look();

    }
    ///<summary>When taking an item be sure the item is in the current room before adding it to the player inventory, Also don't forget to remove the item from the room it was picked up in</summary>
    public void TakeItem(string itemName)
    {
      var hold = _game.CurrentRoom.Items;
      for (int i = 0; i < hold.Count; i++)
      {
        var temp = hold[i].Name;
        if (itemName == temp)
        {
          _game.CurrentPlayer.Inventory.Add(hold[i]);
          _game.CurrentRoom.Items.Remove(hold[i]);
          Messages.Add($"The {itemName} has been added to your inventory");
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
        if (itemName != temp)
        {
          Messages.Add($"{itemName} is not in this room");
        }
        else
        {
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
      // var hold = _game.CurrentRoom.UseItem(itemName);
      var hold = "";
      hold = _game.CurrentRoom.Usages[itemName];
      // _game.CurrentRoom.Exits.Add(hold);
      Messages.Add($"{hold}");
      // Messages.Add($"")
    }


    //Constructor
    public GameService()
    {
      Messages = new List<string>();
      _game = new Game();
    }
  }
}
