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

    public partial class Form3 : Form
    {
        System.Media.SoundPlayer SoundPlayer;
        int clickCount;
        GameModel1 gameModel1;
        View1 view1;
        public Form3(string txt1, string txt2)
        {
            InitializeComponent();
            SoundPlayer = new System.Media.SoundPlayer(Properties.Resources.SOAD_TOXICITY);
            SoundPlayer.PlayLooping();
            gameModel1 = new GameModel1(new Player(txt1), new Player(txt2), this);
            view1 = new View1(gameModel1, this);
            view1.ShowInformation();
            pictureBox1.BackgroundImage = Properties.Resources.Arrow_right;
            gameModel1.PlaceImagesToButtons();
            gameModel1.PlaceImagesToButtons2();
        }

        private void button_Click(object sender, EventArgs e)
        {
            gameModel1.MakeMove(sender);
            view1.ShowInformation();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            gameModel1.Timer3();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            gameModel1.Timer4();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {
            clickCount++;
            if (clickCount % 2 == 1)
                SoundPlayer.Stop();
            else
                SoundPlayer.PlayLooping();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            SoundPlayer.Stop();
        }

        private void button_ClickForSecondPlayer(object sender, EventArgs e)
        {
            gameModel1.MakeMoveSecondPlayer(sender);
            view1.ShowInformation();
        }


        private void timer2_Tick(object sender, EventArgs e)
        {
            gameModel1.Timer2();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           gameModel1.Timer1();
        }
    }

    public class View1
    {
        GameModel1 gameModel1;
        Form3 f1;
        public View1(GameModel1 gameModel1, Form3 f1)
        {
            this.gameModel1 = gameModel1;
            this.f1 = f1;
        }

        public void ShowInformation()
        {
            f1.progressBar1.Value = gameModel1.you.Health;
            f1.label7.Text = gameModel1.you.Health.ToString();
            f1.label8.Text = gameModel1.enemy.Health.ToString();
            f1.progressBar2.Value = gameModel1.enemy.Health;
            f1.label5.Text = $"NAME : {gameModel1.you.Name}";
            f1.label6.Text = $"NAME : {gameModel1.enemy.Name}";
            f1.label1.Text = $"ATTACK LEVEL : {gameModel1.you.AttackLevel}";
            f1.label2.Text = $"DEFENSE LEVEL : {gameModel1.you.DefenseLevel}";
            f1.label4.Text = $"ATTACK LEVEL : {gameModel1.enemy.AttackLevel}";
            f1.label3.Text = $"DEFENSE LEVEL : {gameModel1.enemy.DefenseLevel}";
        }
    }

    public class GameModel1
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
        };
        List<Bitmap> ImagesCopy;
        List<Button> buttons;
        List<Button> buttons1NULLs;
        List<Button> buttons2NULLs;
        Dictionary<Button, Bitmap> dict2;
        Dictionary<List<bool>, Queue<Button>> botButtons;
        List<Button> buttons2;
        public Player you, enemy;
        bool yourTurn = true;
        bool inspectCard;
        Form3 f1;

        public GameModel1(Player you, Player enemy, Form3 f1)
        {
            this.you = you;
            this.enemy = enemy;
            this.f1 = f1;
            ImagesCopy = new List<Bitmap>(Images);

        }

        public void PlaceImagesToButtons()
        {
            dict = new Dictionary<Button, Bitmap>();
            buttons = new List<Button>() { f1.button1,f1.button2,f1.button3,f1.button4,f1.button5,f1.button6,
            f1.button7, f1.button8, f1.button9, f1.button10,f1.button11,f1.button12,
            f1.button13,f1.button14,f1.button15,f1.button16,f1.button17,f1.button18,
            f1.button19, f1.button20, f1.button21,f1.button22,f1.button23, f1.button24,
            f1.button25, f1.button26, f1.button27,f1.button28,f1.button29,f1.button30,
            f1.button31,f1.button32,f1.button33,f1.button34,f1.button35, f1.button36};
            int count = buttons.Count;
            for (int i = 0; i < count; i++)
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
            botButtons = new Dictionary<List<bool>, Queue<Button>>();
            buttons2 = new List<Button>() { f1.button37,f1.button38,f1.button39,f1.button40,f1.button41,f1.button42,
            f1.button43, f1.button44, f1.button45, f1.button46,f1.button47,f1.button48,
            f1.button49,f1.button50,f1.button51,f1.button52,f1.button53,f1.button54,
            f1.button55, f1.button56, f1.button57,f1.button58,f1.button59, f1.button60,
            f1.button61, f1.button62, f1.button63,f1.button64,f1.button65,f1.button66,
            f1.button67,f1.button68,f1.button69,f1.button70,f1.button71, f1.button72};
            Queue<Button> buttons = new Queue<Button>();
            //buttons.Enqueue(buttons2[GetHash(new Bitmap(Properties.Resources.Blue)))]);
            botButtons.Add(GetHash(new Bitmap(Properties.Resources.Blue)), buttons);
            buttons = new Queue<Button>();
            botButtons.Add(GetHash(new Bitmap(Properties.Resources.Purple)), buttons);
            buttons = new Queue<Button>();
            botButtons.Add(GetHash(new Bitmap(Properties.Resources.Green)), buttons);
            buttons = new Queue<Button>();
            botButtons.Add(GetHash(new Bitmap(Properties.Resources.HealthRegen)), buttons);
            buttons = new Queue<Button>();
            botButtons.Add(GetHash(new Bitmap(Properties.Resources.Attack)), buttons);
            buttons = new Queue<Button>();
            botButtons.Add(GetHash(new Bitmap(Properties.Resources.DoubleDamage)), buttons);
            buttons = new Queue<Button>();
            botButtons.Add(GetHash(new Bitmap(Properties.Resources.Defense)), buttons);
            buttons = new Queue<Button>();
            botButtons.Add(GetHash(new Bitmap(Properties.Resources.DoubleDefense)), buttons);
            //botButtons.Add(GetHash(new Bitmap(Properties.Resources.Green)), buttons);
            //botButtons.Add(GetHash(new Bitmap(Properties.Resources.HealthRegen)), buttons);

            int count = buttons2.Count;
            for (int i = 0; i < count; i++)
            {
                var buttonNum = rnd.Next(0, buttons2.Count);
                var imageNum = rnd.Next(0, ImagesCopy.Count);
                foreach (List<bool> current in botButtons.Keys)
                {
                    if (current.SequenceEqual(GetHash(ImagesCopy[imageNum])))
                    {
                        botButtons[current].Enqueue(buttons2[buttonNum]);
                    }
                }
                dict2.Add(buttons2[buttonNum], ImagesCopy[imageNum]);
                buttons2.RemoveAt(buttonNum);
                ImagesCopy.RemoveAt(imageNum);
            }

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
        public bool CheckForLeftCards(Player player)
        {
            int count = 0;
            if (player == you)
            {
                var buttons1Copy = new List<Button>() { f1.button1,f1.button2,f1.button3,f1.button4,f1.button5,f1.button6,
                f1.button7, f1.button8, f1.button9, f1.button10,f1.button11,f1.button12,
                f1.button13,f1.button14,f1.button15,f1.button16,f1.button17,f1.button18,
                f1.button19, f1.button20, f1.button21,f1.button22,f1.button23, f1.button24,
                f1.button25, f1.button26, f1.button27,f1.button28,f1.button29,f1.button30,
                f1.button31,f1.button32,f1.button33,f1.button34,f1.button35, f1.button36};
                foreach (var el in buttons1Copy)
                {
                    if (el.BackgroundImage != null)
                        count++;
                }
                if (count == 36)
                    return true;
            }
            if (player == enemy)
            {
                var buttons2Copy = new List<Button>() { f1.button37,f1.button38,f1.button39,f1.button40,f1.button41,f1.button42,
                f1.button43, f1.button44, f1.button45, f1.button46,f1.button47,f1.button48,
                f1.button49,f1.button50,f1.button51,f1.button52,f1.button53,f1.button54,
                f1.button55, f1.button56, f1.button57,f1.button58,f1.button59, f1.button60,
                f1.button61, f1.button62, f1.button63,f1.button64,f1.button65,f1.button66,
                f1.button67,f1.button68,f1.button69,f1.button70,f1.button71, f1.button72};
                foreach (var el in buttons2Copy)
                {
                    if (el.BackgroundImage != null)
                        count++;
                }
                if (count == 36)
                    return true;
            }
            return false;
        }

        public void MakeMove(object sender)
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
                        MessageBox.Show("+1 TO YOUR ATTACK LEVEL");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Blue))))
                    {
                        you.Health += 1;
                        MessageBox.Show("You got +1 HP");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DeadlyPurple))))
                    {
                        you.Health -= 10;
                        MessageBox.Show("DeadlyPURPLE - you lost 10 health points");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Purple))))
                    {
                        you.Health += 2;
                        MessageBox.Show("Purple + 2 HP");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Defense))))
                    {
                        you.DefenseLevel += 1;
                        MessageBox.Show("+1 to LEVEL OF DEFENSE");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DoubleDefense))))
                    {
                        you.DefenseLevel *= 2;
                        MessageBox.Show("LEVEL OF DEFENSE x2");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DoubleDamage))))
                    {
                        you.AttackLevel *= 2;
                        MessageBox.Show("LEVEL OF ATTACK x2");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Green))))
                    {
                        you.Health += 5;
                        MessageBox.Show("+5 HP");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.HealthRegen))))
                    {
                        you.Health += 10;
                        MessageBox.Show("+10 HP");
                    }
                    else if (GetHash(new Bitmap(first.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Inspect))))
                    {
                        inspectCard = true;
                        MessageBox.Show("Inspect your cards for a 3 sec");
                        var buttons1Copy = new List<Button>() { f1.button1,f1.button2,f1.button3,f1.button4,f1.button5,f1.button6,
                        f1.button7, f1.button8, f1.button9, f1.button10,f1.button11,f1.button12,
                        f1.button13,f1.button14,f1.button15,f1.button16,f1.button17,f1.button18,
                        f1.button19, f1.button20, f1.button21,f1.button22,f1.button23, f1.button24,
                        f1.button25, f1.button26, f1.button27,f1.button28,f1.button29,f1.button30,
                        f1.button31,f1.button32,f1.button33,f1.button34,f1.button35, f1.button36};
                        buttons1NULLs = new List<Button>();
                        foreach (var el in buttons1Copy)
                        {
                            if (el.BackgroundImage == null)
                                buttons1NULLs.Add(el);
                            el.BackgroundImage = dict[el];
                        }
                        f1.timer3.Start();
                    }
                    if ((you.Attack * you.AttackLevel) - (enemy.Defense * enemy.DefenseLevel) < 0)
                        enemy.Health = enemy.Health;
                    else
                        enemy.Health -= ((you.Attack * you.AttackLevel) - (enemy.Defense * enemy.DefenseLevel));
                    first = null;
                    second = null;
                    CheckForWinner();
                }
                else f1.timer1.Start();
            }
            inspectCard = false;
            if (!CheckForLeftCards(enemy))
            {
                yourTurn = false;
                f1.pictureBox1.BackgroundImage = Properties.Resources.Arrow_left;
            }
            else
            {
                yourTurn = true;
                f1.pictureBox1.BackgroundImage = Properties.Resources.Arrow_right;
            }
        }
        public void CheckForWinner()
        {
            DialogResult result;
            if (you.Health == 0)
            {
                result = MessageBox.Show($"{enemy.Name} WIN! TRY AGAIN?", "THE GAME IS ENDED", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    f1.Close();
                else Application.Exit();
            }
            else if (enemy.Health == 0)
            {
                result = MessageBox.Show($"{you.Name} WIN! TRY AGAIN?", "THE GAME IS ENDED", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    f1.Close();
                else Application.Exit();
            }
            else if ((CheckForLeftCards(you) && !inspectCard && CheckForLeftCards(enemy) && !inspectCard))
            {
                if (you.Health > enemy.Health)
                {
                    result = MessageBox.Show($"{you.Name} WIN! TRY AGAIN?", "THE GAME IS ENDED", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        f1.Close();
                    else Application.Exit();
                }
                if (you.Health < enemy.Health)
                {
                    result = MessageBox.Show($"{enemy.Name} WIN! TRY AGAIN?", "THE GAME IS ENDED", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                        f1.Close();
                    else Application.Exit();
                }
            }

        }
        public void MakeMoveSecondPlayer(object sender)
        {
            bool takeCard = false;
            if (!yourTurn)
            {
                Bitmap b = new Bitmap(Properties.Resources.HealthRegen);
                if (takeCard == false)
                {
                    foreach (List<bool> current in botButtons.Keys)
                    {
                        if (current.SequenceEqual(GetHash(b)) && botButtons[current].Count > 0)
                            if (enemy.Health < 20)
                            {
                                try
                                {
                                    first2 = botButtons[current].Dequeue();
                                    first2.BackgroundImage = b;
                                    second2 = botButtons[current].Dequeue();
                                    second2.BackgroundImage = b;
                                    enemy.Health += 10;
                                    takeCard = true;
                                }
                                catch
                                {

                                }
                            }
                    }
                }
                if (takeCard == false)
                {
                    b = new Bitmap(Properties.Resources.Purple);
                    foreach (List<bool> current in botButtons.Keys)
                    {
                        if (current.SequenceEqual(GetHash(b)) && botButtons[current].Count > 0)
                            if (enemy.Health < 30)
                            {
                                try
                                {
                                    first2 = botButtons[current].Dequeue();
                                    first2.BackgroundImage = b;
                                    second2 = botButtons[current].Dequeue();
                                    second2.BackgroundImage = b;
                                    enemy.Health += 5;
                                    takeCard = true;
                                }
                                catch
                                {

                                }
                            }
                    }
                }
                if (takeCard == false)
                {
                    b = new Bitmap(Properties.Resources.Green);
                    foreach (List<bool> current in botButtons.Keys)
                    {
                        if (current.SequenceEqual(GetHash(b)) && botButtons[current].Count > 0)
                            if (enemy.Health < 100)
                            {
                                try
                                {
                                    first2 = botButtons[current].Dequeue();
                                    first2.BackgroundImage = b;
                                    second2 = botButtons[current].Dequeue();
                                    second2.BackgroundImage = b;
                                    enemy.Health += 2;
                                    takeCard = true;
                                }
                                catch
                                {

                                }
                            }
                    }
                }
                if (takeCard == false)
                {
                    b = new Bitmap(Properties.Resources.Blue);
                    foreach (List<bool> current in botButtons.Keys)
                    {
                        if (current.SequenceEqual(GetHash(b)) && botButtons[current].Count > 0)
                            if (enemy.Health < 100)
                            {
                                try
                                {
                                    first2 = botButtons[current].Dequeue();
                                    first2.BackgroundImage = b;
                                    second2 = botButtons[current].Dequeue();
                                    second2.BackgroundImage = b;
                                    enemy.Health += 1;
                                    takeCard = true;
                                }
                                catch
                                {

                                }
                            }
                    }
                }
                if (takeCard == false)
                {
                    b = new Bitmap(Properties.Resources.Attack);
                    foreach (List<bool> current in botButtons.Keys)
                    {
                        if (current.SequenceEqual(GetHash(b)) && botButtons[current].Count > 0)
                                try
                                {
                                    first2 = botButtons[current].Dequeue();
                                    first2.BackgroundImage = b;
                                    second2 = botButtons[current].Dequeue();
                                    second2.BackgroundImage = b;
                                    enemy.AttackLevel += 1;
                                    you.Health -= enemy.AttackLevel;
                                    
                                    takeCard = true;
                                }
                                catch
                                {

                                }
                    }
                }
                if (takeCard == false)
                {
                    b = new Bitmap(Properties.Resources.DoubleDamage);
                    foreach (List<bool> current in botButtons.Keys)
                    {
                        if (current.SequenceEqual(GetHash(b)) && botButtons[current].Count > 0)
                            try
                            {
                                first2 = botButtons[current].Dequeue();
                                first2.BackgroundImage = b;
                                second2 = botButtons[current].Dequeue();
                                second2.BackgroundImage = b;
                                enemy.AttackLevel *= 2;
                                you.Health -= enemy.AttackLevel;
                                takeCard = true;
                            }
                            catch
                            {

                            }
                    }
                }
                if (takeCard == false)
                {
                    b = new Bitmap(Properties.Resources.Defense);
                    foreach (List<bool> current in botButtons.Keys)
                    {
                        if (current.SequenceEqual(GetHash(b)) && botButtons[current].Count > 0)
                                try
                                {
                                    first2 = botButtons[current].Dequeue();
                                    first2.BackgroundImage = b;
                                    second2 = botButtons[current].Dequeue();
                                    second2.BackgroundImage = b;
                                    enemy.DefenseLevel += 1;
                                    takeCard = true;
                                }
                                catch
                                {

                                }
                    }
                }
                if (takeCard == false)
                {
                    b = new Bitmap(Properties.Resources.DoubleDefense);
                    foreach (List<bool> current in botButtons.Keys)
                    {
                        if (current.SequenceEqual(GetHash(b)) && botButtons[current].Count > 0)
                                try
                                {
                                    first2 = botButtons[current].Dequeue();
                                    first2.BackgroundImage = b;
                                    second2 = botButtons[current].Dequeue();
                                    second2.BackgroundImage = b;
                                enemy.DefenseLevel *= 1;
                                takeCard = true;
                                }
                                catch
                                {

                                }
                    }
                }
                //f1.label4.Text = "sososiska";
                //view1.ShowInformation();
                //f1.timer2.Start();
                inspectCard = false;
                if (!CheckForLeftCards(you))
                {
                    yourTurn = true;
                    f1.pictureBox1.BackgroundImage = Properties.Resources.Arrow_right;
                }
                else
                {
                    yourTurn = false;
                    f1.pictureBox1.BackgroundImage = Properties.Resources.Arrow_left;
                }
                return;

                /*
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
                        MessageBox.Show("+1 TO YOUR ATTACK LEVEL");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Blue))))
                    {
                        enemy.Health += 1;
                        MessageBox.Show("You got +1 HP");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DeadlyPurple))))
                    {
                        enemy.Health -= 10; ;
                        MessageBox.Show("DeadlyPURPLE - you lost 10 health points");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Purple))))
                    {
                        enemy.Health += 2;
                        MessageBox.Show("Purple +2 HP");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Defense))))
                    {
                        enemy.DefenseLevel += 1;
                        MessageBox.Show("+1 to LEVEL OF DEFENSE");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DoubleDefense))))
                    {
                        enemy.DefenseLevel *= 2;
                        MessageBox.Show("LEVEL OF DEFENSE x2");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.DoubleDamage))))
                    {
                        enemy.AttackLevel *= 2;
                        MessageBox.Show("LEVEL OF ATTACK x2");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Green))))
                    {
                        enemy.Health += 5;
                        MessageBox.Show("+5 HP");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.HealthRegen))))
                    {
                        enemy.Health += 10;
                        MessageBox.Show("+10 HP");
                    }
                    else if (GetHash(new Bitmap(first2.BackgroundImage)).SequenceEqual(GetHash(new Bitmap(Properties.Resources.Inspect))))
                    {
                        inspectCard = true;
                        MessageBox.Show("Inspect your cards for a 3 sec");
                        var buttons2Copy = new List<Button>() { f1.button37,f1.button38,f1.button39,f1.button40,f1.button41,f1.button42,
                        f1.button43, f1.button44, f1.button45, f1.button46,f1.button47,f1.button48,
                        f1.button49,f1.button50,f1.button51,f1.button52,f1.button53,f1.button54,
                        f1.button55, f1.button56, f1.button57,f1.button58, f1.button59, f1.button60,
                        f1.button61, f1.button62, f1.button63,f1.button64,f1.button65,f1.button66,
                        f1.button67,f1.button68,f1.button69,f1.button70,f1.button71, f1.button72};
                        buttons2NULLs = new List<Button>();
                        foreach (var el in buttons2Copy)
                        {
                            if (el.BackgroundImage == null)
                                buttons2NULLs.Add(el);
                            el.BackgroundImage = dict2[el];
                        }
                        f1.timer4.Start();
                    }
                    if ((enemy.Attack * enemy.AttackLevel) - (you.Defense * you.DefenseLevel) < 0)
                        you.Health = you.Health;
                    else
                        you.Health -= ((enemy.Attack * enemy.AttackLevel) - (you.Defense * you.DefenseLevel));
                    first2 = null;
                    second2 = null;
                    CheckForWinner();
                }
                else f1.timer2.Start();
            }
            inspectCard = false;
            if (!CheckForLeftCards(you))
            {
                yourTurn = true;
                f1.pictureBox1.BackgroundImage = Properties.Resources.Arrow_right;
            }
            else
            {
                yourTurn = false;
                f1.pictureBox1.BackgroundImage = Properties.Resources.Arrow_left;
            }*/
            }
        }

        public void Timer1()
        {
            f1.timer1.Stop();
            first.BackgroundImage = null;
            second.BackgroundImage = null;
            first = null;
            second = null;
        }

        public void Timer2()
        {
            f1.timer2.Stop();
            first2.BackgroundImage = null;
            second2.BackgroundImage = null;
            first2 = null;
            second2 = null;
        }

        public void Timer3()
        {
            f1.timer3.Stop();
            foreach (var el in buttons1NULLs)
                el.BackgroundImage = null;
        }

        public void Timer4()
        {
            f1.timer4.Stop();
            foreach (var el in buttons2NULLs)
                el.BackgroundImage = null;
        }
    }
}

