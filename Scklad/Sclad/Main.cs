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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Get_Into(list);
        }

        void Get_Into(ListView list)
        {
            //Заполнение ListViver данными
            string queru = "select tovar.ID, tovar.name, tovar.inform as информация, booking.status as статус from tovar inner join booking ON tovar.ID = booking.ID;";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(queru, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3) };
                        var listItem = new ListViewItem(row);
                        list.Items.Add(listItem);
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Обновить данные в ListViver
        private void button4_Click(object sender, EventArgs e)
        {
            list.Items.Clear();
            Get_Into(list);
        }

        //Удаление данных нажав на №/ID товара
        private void delet_Click(object sender, EventArgs e)
        {
            string query = "delete from tovar where tovar.ID='" + list.Items[list.SelectedIndices[0]].Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                conn.Close();
                foreach (ListViewItem item in list.SelectedItems)
                {
                    list.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            Home win = new Home();
            win.Show();
            this.Hide();
        }

        //переход на форму добвление и изменение данных
        private void button1_Click(object sender, EventArgs e)
        {
            add_main win = new add_main();
            win.Show();
            this.Hide();
        }

        //переход на форму изменить данных
        private void button2_Click(object sender, EventArgs e)
        {
            add_main win = new add_main();
            win.Show();
            this.Hide();
        }

        //Поиск данных
        private void button3_Click(object sender, EventArgs e)
        {
            list.Items.Clear();
            string queryF = "select * from tovar where concat(name, description) like '%" + textBox1.Text + "%' ";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(queryF, conn);
            cmDB.CommandTimeout = 60;
            try
            {
                conn.Open();
                MySqlDataReader rd = cmDB.ExecuteReader();
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3) };
                        var listItem = new ListViewItem(row);
                        list.Items.Add(listItem);
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
}

