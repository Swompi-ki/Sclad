using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Sclad
{
    public partial class add_main : Form
    {
        public add_main(string mode, int id)
        {
            InitializeComponent();
            getStatus(statusBox);
            modeS = mode;
            item = id;
            setMode(mode);
        }

        public string modeS = "";
        int item;
        void setMode(string mode)
        {
            if (mode == "add")
            {
                tap.Text = "Добавить";
            }
            else if (mode == "change")
            {
                tap.Text = "";
                string Info = "select name, description from booking where status=" + item.ToString() + ";";
                MySqlConnection conn = DBUtils.GetDBConnection();
                MySqlCommand cmInfo = new MySqlCommand(Info, conn);
                MySqlDataReader inRead;
                cmInfo.CommandTimeout = 60;
                try
                {
                    conn.Open();
                    inRead = cmInfo.ExecuteReader();
                    if (inRead.HasRows)
                    {
                        while (inRead.Read())
                        {
                            tovarBox.Text = inRead.GetString(0);
                            matBox.Text = inRead.GetString(1);
                            statusBox.Text = inRead.GetString(2);
                        }
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void getStatus(TextBox textBox3)
        {
            throw new NotImplementedException();
        }

        void getStatus(ComboBox Box)
        {
            string queryF = "select status from booking;";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(queryF, conn);
            MySqlDataReader rd;
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string row = rd.GetString(3);
                        Box.Items.Add(row);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Кнопка добавления данных на форму Main в list
        private void tap_Click(object sender, EventArgs e)
        {
            string query = "insert into tovar(name, description) values('" + tovarBox.Text + "', '" + matBox.Text + "');";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();

                string queryF = "insert into booking(status) values('" + statusBox.Text + "');";
                MySqlCommand cmDBF = new MySqlCommand(queryF, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader rdF = cmDBF.ExecuteReader();
                    conn.Close();
                    Main Win = new Main();
                    Win.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main win = new Main();
            win.Show();
            this.Hide();
        }
    }
}
