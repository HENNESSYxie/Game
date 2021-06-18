using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Map : Form
    {
        public LinkedList<Form> OpenedForms = new LinkedList<Form>();

        int score;
        Dictionary<KeyValuePair<int, int>, float> dict = new Dictionary<KeyValuePair<int, int>, float>();
        List<float> d = new List<float>();
        public Map()
        {
            OpenedForms.AddFirst(this);
            int counter = 0;
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(keyboard);
            List<Node> nodes = new List<Node>();
            for (int i = 0; i < 16; i += 4)
            {
                for (int j = 0; j < 16; j += 4)
                {
                    nodes.Add(new Node(i, j, counter));
                    dict.Add(new KeyValuePair<int, int>(counter, counter + 1), 1);
                    if (counter >= 1)
                    {
                        dict.Add(new KeyValuePair<int, int>(counter, counter - 1), 1);
                    }
                    if (counter <= 11)
                    {
                        dict.Add(new KeyValuePair<int, int>(counter, counter + 4), 1);
                    }
                    if (counter >= 4)
                    {
                        dict.Add(new KeyValuePair<int, int>(counter, counter - 4), 1);
                    }
                    counter++;
                }
            }
            for (int i = 0; i < nodes.Count; i++)
            {
                d.Add(float.MaxValue);
            }
            d[0] = 0;
            bool[] visited = new bool[nodes.Count];
            for (int i = 0; i < nodes.Count; i++)
                visited[i] = false;
            int minIndex = -1;
            for (int i = 0; i < nodes.Count; i++)
            {
                minIndex = -1;
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (minIndex == -1 && (visited[j] == false))
                    {
                        minIndex = j;
                    }
                    else if (visited[j] == false && (d[j] < d[minIndex]))
                    {
                        minIndex = j;
                    }
                }
                if (d[minIndex] == float.MaxValue)
                    break;

                visited[minIndex] = true;

                List<KeyValuePair<int, int>> neighbours = new List<KeyValuePair<int, int>>();
                foreach (KeyValuePair<KeyValuePair<int, int>, float> keyValuePair in dict)
                {
                    var currentPair = keyValuePair.Key;
                    if (currentPair.Key == minIndex)
                        neighbours.Add(currentPair);
                }

                foreach (var neighbour in neighbours)
                {
                    try
                    {
                        if (d[minIndex] + dict[neighbour] < d[neighbour.Value])
                        {
                            d[neighbour.Value] = d[minIndex] + dict[neighbour];
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void keyboard(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "D":
                    player.Location = new Point(player.Location.X + 3, player.Location.Y);
                    break;
                case "A":
                    player.Location = new Point(player.Location.X - 3, player.Location.Y);
                    break;
                case "W":
                    player.Location = new Point(player.Location.X, player.Location.Y - 3);
                    break;
                case "S":
                    player.Location = new Point(player.Location.X, player.Location.Y + 3);
                    break;
                    //Перемещение
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "wall")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (player.Left > x.Left)
                            player.Left += 10;
                        if (player.Left + x.Width < x.Left + x.Width)
                            player.Left -= 5;
                        if (player.Top < x.Top)
                            player.Top -= 5;
                        if (player.Top + x.Height > x.Top + x.Height)
                            player.Top += 5;
                        player.Left -= 5;
                        //Коллизия стен
                    }
                }
                if (x is PictureBox && (string)x.Tag == "coin")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        score++;
                        label1.Text = score.ToString();
                        //Сбор очков (можно удалить)
                    }
                }
                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        SinglePlayer frm = new SinglePlayer("player", "bot");
                        frm.ShowDialog();
                        
                        if (frm.GameModeWithNPC.isGameWon)
                        {
                            Controls.Remove(x);
                            score = score + 5;
                        }
                        label1.Text = score.ToString();
                        //Вызов боя с врагом и его удаление
                    }
                }
            }
            if (player.Bounds.IntersectsWith(Exit.Bounds))
            {
                MessageBox.Show("Вы победили всех боссов и прошли игру!");
                MessageBox.Show("Вас счёт:" + score);
                Close();
                //Переход на фиолетовый квадрат (финал)
            }
            if (player.Bounds.IntersectsWith(Enemy1.Bounds))
            {
                Controls.Remove(Door1);
            }
            if (player.Bounds.IntersectsWith(Enemy2.Bounds))
            {
                Controls.Remove(Door3);
            }
            if (player.Bounds.IntersectsWith(Enemy3.Bounds))
            {
                Controls.Remove(Door2);
            }
            if (player.Bounds.IntersectsWith(Enemy4.Bounds))
            {
                Controls.Remove(Door4);
            }
            if (player.Bounds.IntersectsWith(Enemy5.Bounds))
            {
                Controls.Remove(Door5);
            }
            if (player.Bounds.IntersectsWith(Enemy6.Bounds))
            {
                Controls.Remove(Door7);
            }
            if (player.Bounds.IntersectsWith(Enemy7.Bounds))
            {
                Controls.Remove(Door8);
            }
            if (player.Bounds.IntersectsWith(Boss.Bounds))
            {
                Controls.Remove(Door6);
            }
            if (player.Bounds.IntersectsWith(FinalBoss.Bounds))
            {
                Controls.Remove(FinalBoss);
            }
            //Механика открытия дверей
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    public class Node
    {
        public float x;
        public float y;
        public int number;
        public Node(float x, float y, int number)
        {
            this.number = number;
            this.x = x;
            this.y = y;
        }
    }
}
