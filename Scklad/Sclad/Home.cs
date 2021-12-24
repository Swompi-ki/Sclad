using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sclad
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Click_Click(object sender, EventArgs e)
        {
            label1.Text = "Здравтсвуйте, сегодня вы увидите мое приложение склад товаров и материалов";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Main win = new Main();
            win.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
