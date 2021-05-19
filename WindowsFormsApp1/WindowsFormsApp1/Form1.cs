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
        List<Image> res;
        public Form1()
        {
            InitializeComponent();
            //PlaceImagesToButtonsSecond();
            //PlaceImagesToButtons();
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
                button.Image = lst[randomNumber];
                lst.RemoveAt(randomNumber);    
            }
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
                int num1 = rnd.Next(0, list.Count);
                first.Image = list[num1];
                list.RemoveAt(num1);
                return;
            }
             int num = rnd.Next(0, list.Count);
            second = clickedButton;
            second.Image = list[num];
            ScriptEngine engine = Python.CreateEngine();            
            if (engine.Execute(
                    $"from PIL import Image, ImageChops"+"\n"+
$"image_one = Image.open({first.Image})" +"\n"+
$"image_two = Image.open({second.Image})" + "\n" +
"   try:" + "\n" +
$"      diff = ImageChops.difference(image_one, image_two)" + "\n"+
"       if diff.getbbox() is None:" + "\n"+      
"           print('success')" + "\n") == "success")
            {
                
                first = null;
                second = null;
            }
            else {timer1.Start(); }
            
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

        private void PlaceImagesToButtons()
        {
            Button button;
            int randomNumber;
            res = new List<Image>();
            for(int i=0;i<tableLayoutPanel1.Controls.Count;i++)
            {
                if (tableLayoutPanel1.Controls[i] is Button)
                    button = (Button)tableLayoutPanel1.Controls[i];
                else
                    continue;
                randomNumber = rnd.Next(0, list.Count);
                //button.Image = list[randomNumber];
                res.Add(list[randomNumber]);
                list.RemoveAt(randomNumber);              
            }
        } 
    }
}
