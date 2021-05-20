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
        List<Bitmap> res;
        public Form1()
        {
            InitializeComponent();           
            dict = new Dictionary<Button, Bitmap>();
            dict.Add(button1, Properties.Resources.Attack);
            dict.Add(button2, Properties.Resources.Blue);
            dict.Add(button3, Properties.Resources.Green);
            dict.Add(button4, Properties.Resources.Blue);
            dict.Add(button5, Properties.Resources.DoubleDamage);
            dict.Add(button6, Properties.Resources.Defense);
            dict.Add(button7, Properties.Resources.DeadlyPurple);
            dict.Add(button8, Properties.Resources.Purple);
            dict.Add(button9, Properties.Resources.DoubleDefense);
            dict.Add(button10, Properties.Resources.HealthRegen);
            dict.Add(button11, Properties.Resources.Attack);
            dict.Add(button12, Properties.Resources.Blue);
            dict.Add(button13, Properties.Resources.Green);
            dict.Add(button14, Properties.Resources.HealthRegen);
            dict.Add(button15, Properties.Resources.Inspect);
            dict.Add(button16, Properties.Resources.Inspect);
            dict.Add(button17, Properties.Resources.Defense);
            dict.Add(button18, Properties.Resources.DoubleDamage);
            dict.Add(button19, Properties.Resources.Purple);
            dict.Add(button20, Properties.Resources.Blue);
            dict.Add(button21, Properties.Resources.Attack);
            dict.Add(button22, Properties.Resources.Defense);
            dict.Add(button23, Properties.Resources.DeadlyPurple);
            dict.Add(button24, Properties.Resources.DeadlyPurple);
            dict.Add(button25, Properties.Resources.Attack);
            dict.Add(button26, Properties.Resources.Green);
            dict.Add(button27, Properties.Resources.Green);
            dict.Add(button28, Properties.Resources.Defense);
            dict.Add(button29, Properties.Resources.DeadlyPurple);
            dict.Add(button30, Properties.Resources.DoubleDefense);
            dict.Add(button31, Properties.Resources.HealthRegen);
            dict.Add(button32, Properties.Resources.HealthRegen);
            dict.Add(button33, Properties.Resources.DoubleDamage);
            dict.Add(button34, Properties.Resources.DoubleDamage);
            dict.Add(button35, Properties.Resources.Purple);
            dict.Add(button36, Properties.Resources.Purple);
            
        }
        
        private void button_Click(object sender, EventArgs e)
        {
            if (first != null && second != null)
                return;
            Button clickedButton = sender as Button;
            if (clickedButton == null)
                return;
            if (clickedButton.Image != null)
                return;
            if (first == null)
            {
                first = clickedButton;
                first.Image = dict[clickedButton];
                return;
            }
            second = clickedButton;
            second.Image = dict[clickedButton];
            if (GetHash(new Bitmap(first.Image)).SequenceEqual(GetHash(new Bitmap(second.Image))))
            {
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
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            var img1 = first.Image;
            var img2 = second.Image;
            first.Image = null;
            second.Image = null;
            first = null;
            second = null;
        }
    }
}
