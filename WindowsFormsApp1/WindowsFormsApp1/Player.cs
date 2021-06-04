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
        private int health;
        private int attackLevel;
        private int defenseLevel;
        public int Health
        {
            get => health;
            set 
            {
                if (value > 100)
                {
                    value = 100;
                    health = value;
                }
                else if (value < 0)
                {
                    value = 0;
                    health = value;
                }
                else
                    health = value;
            }
        } 
        public int AttackLevel 
        {
            get => attackLevel;
            set
            {
                if (value > 10)
                {
                    value = 10;
                    attackLevel = value;
                }
                else
                    attackLevel = value;
            }
        }
        public int DefenseLevel 
        {
            get => defenseLevel;
            set
            {
                if (value > 10)
                {
                    value = 10;
                    defenseLevel = value;
                }
                else
                    defenseLevel = value;
            }
        }
        public int Defense { get; set; }
        public int Attack { get; set; }
        public Player(string name, int health = 100, int attack =3, int defense = 1)
        {
            this.attackLevel = 1;
            this.defenseLevel = 1;
            Name = name;
            this.health = health;
            Defense = defense;
            Attack = attack;
        }     
    }
}
