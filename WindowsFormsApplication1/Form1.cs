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
using System.Windows.Controls;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        static String str = "server=pathfinder.chpcq7i3yggs.us-west-2.rds.amazonaws.com;database=PathfinderApp;UID=visualstudio;password=12345";
        static MySqlConnection con = new MySqlConnection(str);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mapButton_click(object sender, EventArgs e)
        {
            try
            {
                String query = "select * from MAP";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connected");
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    String storage = "";
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        storage += rdr.GetName(i) + "    ";
                    }
                    storage += "\n";
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            storage += rdr.GetString(i) + "    ";
                        }
                        storage += "\n";
                    }
                    rdr.Close();
                    MessageBox.Show(storage);
                }
                else
                    MessageBox.Show("Disconnected");
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            try
            {
                String query = "select * from USER";
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connected");
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    String storage = "";
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        storage += rdr.GetName(i) + "    ";
                    }
                    storage += "\n";
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            storage += rdr.GetString(i) + "    ";
                        }
                        storage += "\n";
                    }
                    rdr.Close();
                    MessageBox.Show(storage);
                }
                else
                    MessageBox.Show("Disconnected");
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void submitUser_Click(object sender, EventArgs e)
        {
            String query = "insert into USER values (\'" + int.Parse(UserIDEntry.Text) + "\' , " +
                (adminCheckBox.Checked) + ", \'" + fnameBox.Text + "\', \'" + lnameBox.Text + "\');";
            //   MessageBox.Show(query);
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void UserIDEntry_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String query = "SELECT * FROM USER_RATING WHERE USER_RATING.UID = " + int.Parse(UserIDEntry.Text);
            if (!string.IsNullOrWhiteSpace(UserIDEntry.Text))
            {
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                MySqlDataReader rdr = cmd.ExecuteReader();
                String storage = "";
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    storage += rdr.GetName(i) + "    ";
                }
                storage += "\n";
                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        storage += rdr.GetString(i) + "    ";
                    }
                    storage += "\n";
                }
                con.Close();
                MessageBox.Show(storage);
            }
            else
            {
                MessageBox.Show("You need to enter a user ID...");
            }
        }

        private void listRefresh_Click(object sender, EventArgs e) {
            mapviewListBox.Items.Clear();
            string query = "SELECT * FROM MAP;";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader reader;
            ListBoxItem newItem = new ListBoxItem();
            newItem.Content = "<Select Map>";           
            mapviewListBox.Items.Add(newItem.ToString());
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                newItem = new ListBoxItem();
                newItem.Content = reader["ID"].ToString();
              //  MessageBox.Show(newItem.ToString().Substring(START,END);
                mapviewListBox.Items.Add(newItem.ToString()); //this still prints crap.
            }
            reader.Close();
        }

        private void grabLandscapesButton_Click(object sender, EventArgs e)
        {
            if(mapviewListBox.Items.Count < 1)
            {
                MessageBox.Show("Please refresh the list of maps first");
                return;
            }
            String text = mapviewListBox.GetItemText(mapviewListBox.SelectedItem);
            if(text == "<Select Map>")
            {
                MessageBox.Show("You need to select a valid option.");
                return;
            }
            MessageBox.Show(text);
            String query = "SELECT * FROM LANDSCAPE WHERE LANDSCAPE.MID = " + int.Parse(text);
            MessageBox.Show(query);

        }
    }
}

