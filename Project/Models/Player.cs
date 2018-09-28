using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string PlayerName { get; set; }
        public List<Item> Backpack { get; set; } = new List<Item>();
        // public void AddItem(Item item)
        // {
        //     Backpack.Add(item);
        // }
        // public Player(string playerName)
        // {
        //     PlayerName = playerName;
            // Backpack = new List<Item>();
        }
    }
