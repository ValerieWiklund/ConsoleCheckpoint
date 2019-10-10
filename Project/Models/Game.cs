using ConsoleAdventure.Project.Interfaces;

namespace ConsoleAdventure.Project.Models
{
  public class Game : IGame
  {
    public IRoom CurrentRoom { get; set; }
    public IPlayer CurrentPlayer { get; set; }

    //NOTE Make yo rooms here...
    public void Setup()
    {
      Room gb = new Room("Giraffe Barn", " A large three story room with a large split door");
      Room cy = new Room("Courtyard", "Open air area close to the exit");
      Room bd = new Room("Bears Area", "Long rectangular shaped area");
      Room gs = new Room("Gift Shop", "Just like an souvenir shop with stuffed animals and other toys hanging on the walls");
      Room ex = new Room("Exit", "This is the exit!!! You won");

      gb.Exits.Add("east", cy);
      cy.Exits.Add("west", gb);

      cy.Exits.Add("east", bd);
      bd.Exits.Add("west", cy);


      bd.Exits.Add("north", gs);
      gs.Exits.Add("south", bd);

      gs.Exits.Add("north", ex);

      Item crowbar = new Item("Crowbar", "A heavy, long metal object great for smashing things or prying them open");
      Item haybales = new Item("Hay Bales", "A large number of hay bales scattered around the room");
      Item meat = new Item("Raw meat", "A bucket of raw meat sitting by the entrance");

      gb.Items.Add(haybales);
      cy.Items.Add(crowbar);
      bd.Items.Add(meat);

      CurrentRoom = gb;
      Player riley = new Player("Riley");
      CurrentPlayer = riley;




    }

    public Game()
    {
      Setup();
    }



  }
}