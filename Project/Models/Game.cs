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

      Room av = new Room("Aviary", "the room is filled with cages of large predatory birds. This is a scary place. \n");
      Room mh = new Room("Monkey House", "all around the outer walls are the monkey cages.");
      Room rp = new Room("Red Panda Enclosure", "the adorable red pandas are sleeping soundly. As you tiptoe past them, you see an exit to the south.");
      Room td = new Room("Tiger Den", "you realize the tigers heard you coming. As you step into the room, they pounce. You die.");
      Room gb = new Room("Giraffe Barn", "It is very dark in here. There is no way to see if there are any exits or giraffes that might step on you or kick you.");
      Room cy = new Room("Courtyard", "a beautiful open air courtyard. Are you free at last? No! it is completely walled.");
      Room bd = new Room("Bear Area", "a long rectangular area with a door on the north wall. Unfortunately, all three of the bears are laying in front of it. ");
      Room gs = new Room("Gift Shop", "a normal souvenir shop with stuffed animals and other toys hanging on the walls. It is kind of creepy. ");
      Room ex = new Room("Exit", "This is the exit!!! You won");

      av.Exits.Add("west", mh);
      mh.Exits.Add("east", av);

      mh.Exits.Add("north", gb);
      gb.Exits.Add("south", mh);

      mh.Exits.Add("south", rp);
      rp.Exits.Add("north", mh);

      rp.Exits.Add("south", td);

      gb.Exits.Add("east", cy);
      cy.Exits.Add("west", gb);

      cy.Exits.Add("east", bd);
      bd.Exits.Add("west", cy);


      bd.Exits.Add("north", gs);
      gs.Exits.Add("south", bd);

      gs.Exits.Add("north", ex);

      // Item crowbar = new Item("crowbar", "A heavy, long metal object great for smashing things or prying them open");
      // Item haybales = new Item("haybales", "A large number of hay bales scattered around the room");
      Item meat = new Item("meat", " By the door,  there is a bucket of raw (meat).");
      Item flashlight = new Item("flashlight", "In the middle of the aisle, there is a (flashlight).");

      // gb.Items.Add(haybales);
      // cy.Items.Add(crowbar);
      bd.Items.Add(meat);
      av.Items.Add(flashlight);

      // gb.Usages.Add("haybales", new Dictionary<string, IRoom> { "east", cy });

      // gs.Usages.Add("crowbar", ("north", ex));
      // gb.Usages.Add("haybales", "east, cy");
      gb.Usages.Add("flashlight", "With the flashlight, you are able to see one exit to the east.");
      bd.Usages.Add("meat", "As you throw the meat to the far end of the pen, the bears lumber after it. Finally, the path is clear to the door.");



      CurrentRoom = av;
      Player riley = new Player("Riley");
      CurrentPlayer = riley;


    }

    public Game()
    {
      Setup();
    }



  }
}