﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        List<Image> list = new List<Image>() { Properties.Resources.Attack, Properties.Resources.Red,
        Properties.Resources.Defense,Properties.Resources.Blue,
        Properties.Resources.Yellow,Properties.Resources.Defense,
        Properties.Resources.Red, Properties.Resources.Red,
        Properties.Resources.Empty,Properties.Resources.Empty,
        Properties.Resources.Attack, Properties.Resources.Attack,
        Properties.Resources.Defense,Properties.Resources.Defense,
        Properties.Resources.Green,Properties.Resources.Green,
        Properties.Resources.Blue, Properties.Resources.Clones, 
        Properties.Resources.Clones, Properties.Resources.Attack,
        Properties.Resources.Attack, Properties.Resources.Defense,
        Properties.Resources.Defense, Properties.Resources.Tripple_Damage,
        Properties.Resources.Tripple_Damage,Properties.Resources.Yellow,
        Properties.Resources.Defense,Properties.Resources.Defense,
        Properties.Resources.Clones, Properties.Resources.Defense,
         Properties.Resources.Red,Properties.Resources.Clones,
        Properties.Resources.Green,Properties.Resources.Green,
        Properties.Resources.Defense,Properties.Resources.Attack ,
        };
        Button first, second;
        public Form1()
        {
            InitializeComponent();
            PlaceImagesToButtonsSecond();
            PlaceImagesToButtons();
        }
        private void PlaceImagesToButtonsSecond()
        {
            var lst = new List<Image>(list);
            Button button;
            int randomNumber;
            for (int i = 0; i < tableLayoutPanel2.Controls.Count; i++)
            {
                if (tableLayoutPanel2.Controls[i] is Button)
                    button = (Button)tableLayoutPanel2.Controls[i];
                else
                    continue;
                randomNumber = rnd.Next(0, lst.Count);
                button.BackgroundImage = lst[randomNumber];
                lst.RemoveAt(randomNumber);
                
            }
        }

        private void PlaceImagesToButtons()
        {
            Button button;
            int randomNumber;
            for(int i=0;i<tableLayoutPanel1.Controls.Count;i++)
            {
                if (tableLayoutPanel1.Controls[i] is Button)
                    button = (Button)tableLayoutPanel1.Controls[i];
                else
                    continue;
                randomNumber = rnd.Next(0, list.Count);
                button.BackgroundImage = list[randomNumber];
                list.RemoveAt(randomNumber);
            }
        }

      
    }
}
