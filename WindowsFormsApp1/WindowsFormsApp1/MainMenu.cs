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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void roundButton1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3("player", "bot");
            form3.ShowDialog();
        }
        private void roundButton2_Click(object sender, EventArgs e)
        {
            EntryNames en = new EntryNames();
            en.ShowDialog();
        }
    }
}
