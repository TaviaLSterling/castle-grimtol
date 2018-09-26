using System;
using System.Collections.Generic;
namespace CastleGrimtol.Project

{
    public class Game : IGame
    {
        public bool Quits = false;
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        public void GetUserInput()
        {
            throw new System.NotImplementedException();
        }

        public void Go(string direction)
        {
            
        }

        public void Help()
        {
            Console.WriteLine("Here is a list of things you can do: ");
            Console.WriteLine("You can type 'go North','go South','go East', or 'go West' to move through the game.");

        }

        public void Inventory()
        {
            Console.Write($"{CurrentPlayer.Inventory}");
        }

        public void Look()
        {
            Console.WriteLine($"{CurrentRoom.Description}");
        }

        public void Quit()
        {
            Quits = true;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Setup()
        {
         var roomOne = new Room("Room One", "This is a room");
         var roomTwo = new Room("Room Two","This is also a room");
         var roomThree = new Room("Room Three","This is the third room");
         var roomFour = new Room("Room Four","This is the last room");

         Item key = new Item("Key","a rusty old key");
         roomTwo.AddItem(key);
         CurrentRoom = roomOne;

        roomOne.Exits.Add("east", roomTwo);
        roomTwo.Exits.Add("east", roomThree);
        roomThree.Exits.Add("east", roomFour);
        }

        public void StartGame()
        {
            Console.Clear();
            Setup();
            Console.WriteLine("Welcome to the Game");
            Console.Write("Choose which direction to go: ");
            Console.ReadLine();
        }

        public void TakeItem(string itemName)
        {
            
        }

        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
    }
}