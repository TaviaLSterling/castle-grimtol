using System.Collections.Generic;
namespace CastleGrimtol.Project

{
    public class Game : IGame
    {
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
            throw new System.NotImplementedException();
        }

        public void Inventory()
        {
            throw new System.NotImplementedException();
        }

        public void Look()
        {
            throw new System.NotImplementedException();
        }

        public void Quit()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
           
        }

        public void Setup()
        {
         var roomOne = new Room("Room One", "This is a room");
         var roomTwo = new Room("Room Two","This is also a room");
         var roomThree = new Room("Room Three","This is the third room");
         var roomFour = new Room("Room Four","This is the last room");
         var myItem = new Item("name","description");

        roomOne.Exits.Add("east", roomTwo);
        roomTwo.Exits.Add("east", roomThree);
        roomThree.Exits.Add("east", roomFour);
        }

        public void StartGame()
        {
            
        }

        public void TakeItem(string itemName)
        {
            throw new System.NotImplementedException();
        }

        public void UseItem(string itemName)
        {
            throw new System.NotImplementedException();
        }
    }
}