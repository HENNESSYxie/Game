using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
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
        Dictionary<Button, Bitmap> dict;   
        Button first, second;
        Random rnd = new Random();
        List<Bitmap> Images = new List<Bitmap>() { Properties.Resources.Attack,
            Properties.Resources.Blue,  
            Properties.Resources.Green,
            Properties.Resources.Blue,
            Properties.Resources.DoubleDamage,
            Properties.Resources.Defense, 
            Properties.Resources.DeadlyPurple,
            Properties.Resources.Purple,
            Properties.Resources.DoubleDefense,
            Properties.Resources.HealthRegen,
            Properties.Resources.Attack,
            Properties.Resources.Blue,
            Properties.Resources.Green,  
            Properties.Resources.HealthRegen,
            Properties.Resources.Inspect,
            Properties.Resources.Inspect, 
            Properties.Resources.Defense,
            Properties.Resources.DoubleDamage,
            Properties.Resources.Purple,
            Properties.Resources.Blue,
            Properties.Resources.Attack,
            Properties.Resources.Defense,
            Properties.Resources.DeadlyPurple,
            Properties.Resources.DeadlyPurple,
            Properties.Resources.Attack,
            Properties.Resources.Green,
            Properties.Resources.Green,
            Properties.Resources.Defense,
            Properties.Resources.DeadlyPurple,
            Properties.Resources.DoubleDefense,
            Properties.Resources.HealthRegen,
            Properties.Resources.HealthRegen,
            Properties.Resources.DoubleDamage,
            Properties.Resources.DoubleDamage,
            Properties.Resources.Purple, 
            Properties.Resources.Purple
        } ;
        List<Button> buttons;
        public Form1()
        {
            InitializeComponent();
            PlaceImagesToButtons(); 
        }
        public void PlaceImagesToButtons()
        {
            dict = new Dictionary<Button, Bitmap>();
            buttons = new List<Button>() { button1,button2,button3,button4,button5,button6,button7, button8, button9, button10,
            button11,button12,button13,button14,button15,button16,button17,button18,button19, button20, button21,button22,
            button23, button24, button25, button26, button27,button28,button29,button30,button31,button32,button33,button34,
            button35, button36};
            int count = buttons.Count;
            for(int i=0;i<count;i++)
            {
                var buttonNum = rnd.Next(0, buttons.Count);
                var imageNum = rnd.Next(0, Images.Count);    
                dict.Add(buttons[buttonNum], Images[imageNum]);
                buttons.RemoveAt(buttonNum);
                Images.RemoveAt(imageNum);
            }

        }
        
        private void button_Click(object sender, EventArgs e)
        {
            if (first != null && second != null)
                return;
            Button clickedButton = sender as Button;
            if (clickedButton == null)
                return;
            if (clickedButton.BackgroundImage != null)
                return;
            if (first == null)
            {
                first = clickedButton;
                first.BackgroundImage = dict[clickedButton];
                return;
            }
            second = clickedButton;
            second.BackgroundImage = dict[clickedButton];
            if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(second.BackgroundImage))))
            {
                if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Attack))))
                    MessageBox.Show("Attack");
                else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Blue))))
                    MessageBox.Show("Blue");
                else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DeadlyPurple))))
                    MessageBox.Show("DeadlyPURPLE");
                else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Purple))))
                    MessageBox.Show("Purple");
                else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Defense))))
                    MessageBox.Show("Defense");
                else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DoubleDefense))))
                    MessageBox.Show("DoubleDefense");
                else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DoubleDamage))))
                    MessageBox.Show("DoubleDamage");
                else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Green))))
                    MessageBox.Show("Green");
                else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.HealthRegen))))
                    MessageBox.Show("HealthRegen");
                else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Inspect))))
                    MessageBox.Show("Inspect");
                first = null;
                second = null;
            }
            else { timer1.Start(); }

        }
        public static List<bool> GetHash(Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();         
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {              
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();         
            first.BackgroundImage = null;
            second.BackgroundImage = null;
            first = null;
            second = null;
        }
    }
}
