using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



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
                String query = "select * from map";
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                if (con.State == ConnectionState.Open)
                    MessageBox.Show("Connected");
                else
                    MessageBox.Show("Disconnected");
                DataSet ds = new DataSet();
                MessageBox.Show("connect with sql server");
                con.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
