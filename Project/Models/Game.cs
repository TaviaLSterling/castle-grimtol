using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project

{
    public class Game : IGame
    {
        bool Playing = true;
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void GetUserInput()
        {
            while (Playing)
            //command seperate from direction
            {   Console.Write("What do you do now?");
                string input = Console.ReadLine().ToLower();
                string firstWord = input.Split(" ")[0];
                //first word
                string secondWord = "";
                if (input.Split(" ").Length > 1)
                //second word
                {
                    secondWord = input.Split(" ")[1];
                }

                switch (input)
                {
                    case "help":
                        Help();
                        break;
                    case "look":
                        Look();
                        break;
                    case "take pig":
                        TakeItem(secondWord);
                        break;
                    case "use pig":
                        UseItem(secondWord);
                        break;
                    case "backpack":
                        Backpack();
                        break;
                    case "go north":
                    // Go("north");
                        CurrentRoom = CurrentRoom.ChangeRoom("north");
                        Look();
                        break;
                    case "go east":
                    //  Go("east");
                        CurrentRoom = CurrentRoom.ChangeRoom("east");
                        Look();
                        break;
                    case "go west":
                    // Go("west")
                        CurrentRoom = CurrentRoom.ChangeRoom("west");
                        Look();
                        break;
                    case "go south":
                    // Go("south");
                        CurrentRoom = CurrentRoom.ChangeRoom("south");
                        Look();
                        break;
                    case "quit":
                        Quit();
                        break;
                        // default:
                        // Console.WriteLine("You cannot do that.");
                        // break;
                }
            }
        }

        public void Go(string direction)
        {
            if (CurrentRoom.Exits.ContainsKey(direction))
            {
                CurrentRoom = CurrentRoom.Exits[direction];
            }
            // else
            // {
            //     Console.WriteLine("You shouldn't go that way");
            // }
        }

        public void Help()
        {
            Console.WriteLine("Here is a list of things you can do: \n");
            Console.WriteLine("You can type 'North', 'South','East', or 'West' to move through the game.");
            Console.WriteLine("You can type 'Look' to see a description of where you are.");
            Console.WriteLine("You can type 'Take' and the item name to take an item and put it in your backpack.");
            Console.WriteLine("You can type 'Use' and the item name to use an item that is in your backpack");
            Console.WriteLine("You can type 'Quit' to fail at saving the pig and leave the game.");
            Console.WriteLine("You can type 'Backpack' to see what items you've picked up along the way.");
            Console.WriteLine("Time is running out!");
        }

        public void Backpack()
        {
            if (CurrentPlayer.Backpack.Count > 0)
            {
                CurrentPlayer.Backpack.ForEach(Item =>
         {
             Console.WriteLine("Here's what is in your backpack: ");
             Console.WriteLine($"{Item.Name}");
            //  Console.Write("What do you do now? ");
         });
            }
            else
            {
                System.Console.WriteLine("Looks like there's nothing in your backpack.");
            }
        }
    

    
public void Winning()
{
     Console.WriteLine("You and the pig have made it out alive!");
                Console.WriteLine("Congratulations! You win!");
                Quit();
}


public void Look()
{
    Console.WriteLine($"{CurrentRoom.Description}");
     if (CurrentRoom.Name == "backRoom")
            {
                Console.WriteLine("You and the pig have made it out alive!");
                Console.WriteLine("Congratulations! You win!");
                Winning();
                Quit();
            }
            else if(CurrentRoom.Name == "Room Four" && CurrentPlayer.Backpack.Count == 0) 
            {
                Console.WriteLine("You forgot to grab the pig! There's no way out and you both burn alive.");
                Console.WriteLine("You have lost the game.");
                Quit();
            }
            // else if(CurrentRoom.Name == "Main Barn Room" && CurrentRoom == CurrentRoom.Exits["south"])
            // { 
            //     Console.WriteLine("you died");
            // }
    // Console.Write("What do you do now? ");
}

public void Quit()
{
    // Console.Clear();
    // Console.WriteLine("You got scared and failed at saving the piglet! Now the sweet smell of bacon permeates the air.");
    Playing = false;
}

public void Reset()
{
    throw new NotImplementedException();
}

public void Setup()
{
    Room field = new Room("Field", "You are standing in a field and see a barn burning to the North. You hear the sound of a poor squealing pig that's trapped in the burning barn. You should probably go save it, brave Samaritan!");
    Room barnRoomOne = new Room("Main Barn Room", "You have entered the main room of the barn. The fire has engulfed the door that you entered through, but luckily you see the squealing pig! He's so cute. You should probably grab him and get out of here!");
    Room emptyPen = new Room("Empty Pig Pen", "You made your way into an empty pig pen. The barn is starting to collapse around you. You should probably keep moving.");
    Room backRoom = new Room("Room Four", "You've come to the end of the barn. The fire is closing in on all sides now. You see a window that's a little too high for you to reach. If only you had something sturdy to stand on...");

    Item pig = new Item("Pig", "it's a scared little pig");
    // Item key = new Item("Key","a rusty old key");

    barnRoomOne.AddItem(pig);
    //  roomThree.AddItem(key);
    CurrentRoom = field;
    CurrentPlayer = new Player();

    field.Exits.Add("north", barnRoomOne);
    barnRoomOne.Exits.Add("south", field);
    barnRoomOne.Exits.Add("east", emptyPen);
    emptyPen.Exits.Add("west", barnRoomOne);
    emptyPen.Exits.Add("east", backRoom);
    backRoom.Exits.Add("west", emptyPen);

}

public void StartGame()
{
    Console.Clear();
    Setup();
    Console.WriteLine("You can type 'Go North','Go South','Go East', or 'Go West' to move through this game.\n");
    Console.WriteLine("If you need assistance just type 'Help', or type 'Quit' at any point to end the game.\n");
    Console.WriteLine("You can also type 'Backpack' to see what you've picked up along the way\n");

    Console.WriteLine($"{CurrentRoom.Description}");
    // Console.Write("Choose which direction to go: ");
    GetUserInput();
}

public void TakeItem(string itemName)
{
    Item item = CurrentRoom.Items.Find(i => i.Name.ToLower().Contains(itemName));
    if (CurrentRoom.Items.Contains(item))
    {
        Console.WriteLine("You picked up the pig and put it in your backpack");
        // Console.WriteLine("Where would you like to go now?");
        CurrentPlayer.Backpack.Add(item);
        CurrentRoom.Items.Remove(item);
    }
}

public void UseItem(string itemName)
{
    Item item = CurrentPlayer.Backpack.Find(i => i.Name.ToLower().Contains(itemName));
    if (item != null)
    {
        if (CurrentRoom.Name == "Room Four" && itemName == "pig")
        {
            CurrentPlayer.Backpack.Remove(item);
            Console.WriteLine("You successfully retrieved the stout pig from your backpack. Eventually you get the pig to stand still long enough to stand on it's back and reach the window. You open the window, grab the terrified pig, and jump out the window together.\n");
            Winning();
        }
    }



    //   if(itemName == "Pig" && CurrentRoom == roomFour && CurrentPlayer.Inventory.Contains(pig))
    //   {
    // 
    //   }
}
        public void EndGame()
        {
            if(CurrentRoom.Name == "Main Barn Room" &&  CurrentRoom == CurrentRoom.Exits["south"]){

        Console.Clear();
         Console.Write("You tried to go back the way you came. The fire collapsed the barn around you, and you and the pig burned to a crisp.");
        //    Quit();
      Console.WriteLine("Would you like to play again? Y/N?");
      var answer = Console.ReadLine().ToLower();
      if (answer == "y")
      {
       
        StartGame();
      }
      else
      {
        Quit();
      }
            }
    }
           }
    }
