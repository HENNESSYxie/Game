using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackLevel { get; set; }
        public int DefenseLevel { get; set; }
        public Player(string name, int health = 100)
        {
            Name = name;
            Health = health;
        }
        public Player(string name, int health = 100, int defense = 1, int attack = 1)
        {
            Name = name;
            Health = health;
            AttackLevel = attack;
            DefenseLevel = defense;
        }
    }
}
