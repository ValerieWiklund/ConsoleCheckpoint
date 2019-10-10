using System;
using System.Collections.Generic;
using ConsoleAdventure.Project.Interfaces;
using ConsoleAdventure.Project.Models;
using ConsoleAdventure.Project.Services;

namespace ConsoleAdventure.Project.Controllers
{
  public class GameController : IGameController
  {
    private GameService _gameService = new GameService();

    //NOTE Makes sure everything is called to finish Setup and Starts the Game loop
    public void Run()
    {
      Console.Clear();
      //   Console.WriteLine("Enter Player Name:");
      //   string Input = Console.ReadLine();
      _gameService.Setup();
      Print();

      while (true)
      {
        GetUserInput();
      }

    }

    //NOTE Gets the user input, calls the appropriate command, and passes on the option if needed.
    public void GetUserInput()
    {
      Console.WriteLine("What would you like to do?");
      string input = Console.ReadLine().ToLower() + " ";
      string command = input.Substring(0, input.IndexOf(" "));
      string option = input.Substring(input.IndexOf(" ") + 1).Trim();
      //NOTE this will take the user input and parse it into a command and option.
      //IE: take silver key => command = "take" option = "silver key"
      switch (command)
      {
        case "go":
          _gameService.Go(option);
          Print();
          break;
        case "use":
          _gameService.UseItem(option);
          Print();
          break;
        case "take":
          _gameService.TakeItem(option);
          Print();
          break;
        case "inventory":
          _gameService.Inventory();
          Print();
          break;
        case "look":
          _gameService.Look();
          Print();
          break;
        case "help":
          _gameService.Help();
          Print();
          break;
        case "quit":
          _gameService.Quit();
          break;
        default:
          Console.WriteLine("Invalid Entry");
          break;
      }



    }




    //NOTE this should print your messages for the game.
    private void Print()
    {
      foreach (string message in _gameService.Messages)
      {
        Console.WriteLine("\t" + message);
      }
      _gameService.Messages.Clear();
    }

  }
}