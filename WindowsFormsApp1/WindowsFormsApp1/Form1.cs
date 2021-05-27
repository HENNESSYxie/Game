using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Dictionary<Button, Bitmap> dict;   
        Button first, second, first2, second2;
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
        List<Bitmap> ImagesCopy;
        List<Button> buttons;
        List<Button> buttons1NULLs;
        List<Button> buttons2NULLs;
        Dictionary<Button, Bitmap> dict2;
        List<Button> buttons2;
        Player you, enemy;
        bool yourTurn = true;
        System.Media.SoundPlayer SoundPlayer;
        int clickCount;

        public Form1(string txt1, string txt2)
        {
            InitializeComponent();
            ImagesCopy = new List<Bitmap>(Images);
            SoundPlayer = new System.Media.SoundPlayer(Properties.Resources.SOAD_TOXICITY);
            SoundPlayer.PlayLooping();         
            you = new Player(txt1) ;
            enemy = new Player(txt2);
            progressBar1.Value = you.Health;
            label7.Text = you.Health.ToString();
            label8.Text = enemy.Health.ToString();
            progressBar2.Value = enemy.Health;
            label5.Text = $"NAME : {you.Name}";
            label6.Text = $"NAME : {enemy.Name}";
            label1.Text = $"ATTACK LEVEL : {you.AttackLevel}";
            label2.Text = $"DEFENSE LEVEL : {you.DefenseLevel}";
            label4.Text = $"ATTACK LEVEL : {enemy.AttackLevel}";
            label3.Text = $"DEFENSE LEVEL : {enemy.DefenseLevel}";
            pictureBox1.BackgroundImage = Properties.Resources.Arrow_right;
            PlaceImagesToButtons();
            PlaceImagesToButtons2();
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
        public void PlaceImagesToButtons2()
        {
            dict2 = new Dictionary<Button, Bitmap>();
            buttons2 = new List<Button>() { button37,button38,button39,button40,button41,button42,button43, button44, button45, button46,
            button47,button48,button49,button50,button51,button52,button53,button54,button55, button56, button57,button58,
            button59, button60, button61, button62, button63,button64,button65,button66,button67,button68,button69,button70,
            button71, button72};
            int count = buttons2.Count;
            for (int i = 0; i < count; i++)
            {
                var buttonNum = rnd.Next(0, buttons2.Count);
                var imageNum = rnd.Next(0, Images.Count);
                dict2.Add(buttons2[buttonNum], ImagesCopy[imageNum]);
                buttons2.RemoveAt(buttonNum);
                ImagesCopy.RemoveAt(imageNum);
            }

        }

        private void button_Click(object sender, EventArgs e)
        {
            if (yourTurn)
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
                    {
                        you.AttackLevel += 1;
                        label1.Text = $"ATTACK LEVEL : {you.AttackLevel}";
                        MessageBox.Show("+1 TO YOUR ATTACK LEVEL");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Blue))))
                    {
                        you.Health += 1;
                        progressBar1.Value = you.Health;
                        label7.Text = you.Health.ToString();                     
                        MessageBox.Show("You got +1 HP");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DeadlyPurple))))
                    {
                        you.Health -= 10;
                        progressBar1.Value = you.Health;
                        label7.Text = you.Health.ToString();
                        MessageBox.Show("DeadlyPURPLE - you lost 10 health points");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Purple))))
                    {
                        you.Health += 2;
                        progressBar1.Value = you.Health;
                        label7.Text = you.Health.ToString();
                        MessageBox.Show("Purple");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Defense))))
                    {
                        you.DefenseLevel += 1;
                        label2.Text = $"DEFENSE LEVEL : {you.DefenseLevel}";
                        MessageBox.Show("+1 to LEVEL OF DEFENSE");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DoubleDefense))))
                    {
                        you.DefenseLevel *= 2;
                        label2.Text = $"DEFENSE LEVEL : {you.DefenseLevel}";
                        MessageBox.Show("LEVEL OF DEFENSE x2");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DoubleDamage))))
                    {
                        you.AttackLevel *= 2;
                        label1.Text = $"ATTACK LEVEL : {you.AttackLevel}";
                        MessageBox.Show("LEVEL OF ATTACK x2");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Green))))
                    {
                        you.Health += 5;
                        progressBar1.Value = you.Health;
                        label7.Text = you.Health.ToString();
                        MessageBox.Show("+5 HP");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.HealthRegen))))
                    {
                        you.Health += 10;
                        progressBar1.Value = you.Health;
                        label7.Text = you.Health.ToString();
                        MessageBox.Show("+10 HP");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Inspect))))
                    {
                        MessageBox.Show("Inspect your cards for a 3 sec");
                        var buttons1Copy = new List<Button>() { button1,button2,button3,button4,button5,button6,button7, button8, button9, button10,
                        button11,button12,button13,button14,button15,button16,button17,button18,button19, button20, button21,button22,
                        button23, button24, button25, button26, button27,button28,button29,button30,button31,button32,button33,button34,
                        button35, button36};
                        buttons1NULLs = new List<Button>();

                        foreach (var el in buttons1Copy)
                        {
                            if (el.BackgroundImage == null)
                            {
                                buttons1NULLs.Add(el);
                            }
                            el.BackgroundImage = dict[el];
                        }
                        timer3.Start();
                    }
                    first = null;
                    second = null;
                }
                else { timer1.Start(); }
            }
            progressBar1.Value = you.Health;
            label7.Text = you.Health.ToString();
            yourTurn = false;
            pictureBox1.BackgroundImage = Properties.Resources.Arrow_left;

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();     
            foreach (var el in buttons1NULLs)
                el.BackgroundImage = null;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            foreach (var el in buttons2NULLs)
                el.BackgroundImage = null;
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            clickCount++;
            if (clickCount % 2 == 1)
                SoundPlayer.Stop();
            else
                SoundPlayer.PlayLooping();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SoundPlayer.Stop();
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

        private void button_ClickForSecondPlayer(object sender, EventArgs e)
        {
            if (!yourTurn)
            {
                if (first2 != null && second2 != null)
                    return;
                Button clickedButton = sender as Button;
                if (clickedButton == null)
                    return;
                if (clickedButton.BackgroundImage != null)
                    return;
                if (first2 == null)
                {
                    first2 = clickedButton;
                    first2.BackgroundImage = dict2[clickedButton];
                    return;
                }
                second2 = clickedButton;
                second2.BackgroundImage = dict2[clickedButton];
                if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(second2.BackgroundImage))))
                {
                    if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Attack))))
                    {
                        enemy.AttackLevel += 1;
                        label4.Text = $"ATTACK LEVEL : {enemy.AttackLevel}";
                        MessageBox.Show("+1 TO YOUR ATTACK LEVEL");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Blue))))
                    {
                        enemy.Health += 1;
                        progressBar2.Value = enemy.Health;
                        label8.Text = enemy.Health.ToString();
                        MessageBox.Show("You got +1 HP");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DeadlyPurple))))
                    {
                        enemy.Health -= 10;
                        progressBar2.Value = enemy.Health;
                        label8.Text = enemy.Health.ToString();
                        MessageBox.Show("DeadlyPURPLE - you lost 10 health points");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Purple))))
                    {
                        enemy.Health += 2;
                        progressBar2.Value = enemy.Health;
                        label8.Text = enemy.Health.ToString();
                        MessageBox.Show("Purple +2 HP");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Defense))))
                    {
                        enemy.DefenseLevel += 1;
                        label3.Text = $"DEFENSE LEVEL : {enemy.DefenseLevel}";
                        MessageBox.Show("+1 to LEVEL OF DEFENSE");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DoubleDefense))))
                    {
                        enemy.DefenseLevel *= 2;
                        label3.Text = $"DEFENSE LEVEL : {enemy.DefenseLevel}";
                        MessageBox.Show("LEVEL OF DEFENSE x2");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DoubleDamage))))
                    {
                        enemy.AttackLevel *= 2;
                        label4.Text = $"ATTACK LEVEL : {enemy.AttackLevel}";
                        MessageBox.Show("LEVEL OF ATTACK x2");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Green))))
                    {
                        enemy.Health += 5;
                        progressBar2.Value = enemy.Health;
                        label8.Text = enemy.Health.ToString();
                        MessageBox.Show("+5 HP");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.HealthRegen))))
                    {
                        enemy.Health += 10;
                        progressBar2.Value = enemy.Health;
                        label8.Text = enemy.Health.ToString();
                        MessageBox.Show("+10 HP");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Inspect))))
                    {
                        MessageBox.Show("Inspect your cards for a 3 sec");
                        var buttons2Copy = new List<Button>() { button37,button38,button39,button40,button41,button42,button43, button44, button45, button46,
            button47,button48,button49,button50,button51,button52,button53,button54,button55, button56, button57,button58,
            button59, button60, button61, button62, button63,button64,button65,button66,button67,button68,button69,button70,
            button71, button72};
                        buttons2NULLs = new List<Button>();

                        foreach (var el in buttons2Copy)
                        {
                            if (el.BackgroundImage == null)
                            {
                                buttons2NULLs.Add(el);
                            }
                            el.BackgroundImage = dict2[el];
                        }
                        timer4.Start();
                    }
                    first2 = null;
                    second2 = null;
                }
                else { timer2.Start(); }
            }
            progressBar2.Value = enemy.Health;
            label8.Text = enemy.Health.ToString();
            yourTurn = true;
            pictureBox1.BackgroundImage = Properties.Resources.Arrow_right;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            first2.BackgroundImage = null;
            second2.BackgroundImage = null;
            first2 = null;
            second2 = null;
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
