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




namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String str = "server=pathfinder.chpcq7i3yggs.us-west-2.rds.amazonaws.com;database=PathfinderApp;UID=visualstudio;password=12345";
                String query = "select * from MAP";
                MySqlConnection con = new MySqlConnection(str);
                MySqlCommand cmd = new MySqlCommand(query, con);
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    MessageBox.Show("Connected");
                    MySqlDataReader rdr = cmd.ExecuteReader();
                    String storage = "";
                    for(int i = 0; i < rdr.FieldCount; i++)
                    {
                        storage += rdr.GetName(i) + "    ";
                    }
                    storage += "\n";
                    while (rdr.Read())
                    {
                        for(int i = 0; i < rdr.FieldCount; i++)
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
                DataSet ds = new DataSet();
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
