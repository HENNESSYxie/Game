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
        public int Defense { get; set; }
        public int Attack { get; set; }
        public Player(string name, int health = 100, int attack = 10, int defense = 5)
        {
            AttackLevel = 1;
            DefenseLevel = 1;
            Name = name;
            Health = health;
            Defense = defense;
            Attack = attack;
        }     
    }
}
