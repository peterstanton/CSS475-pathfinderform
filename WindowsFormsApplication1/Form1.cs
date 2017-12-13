using System;
using System.Data;
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

        private String processReader(ref MySqlDataReader fromDatabase)
        {
            String storage = "";
            for (int i = 0; i < fromDatabase.FieldCount; i++)
            {
                storage += fromDatabase.GetName(i) + "    ";
            }
            storage += "\n";
            while (fromDatabase.Read())
            {
                for (int i = 0; i < fromDatabase.FieldCount; i++)
                {
                    storage += fromDatabase.GetString(i) + "    ";
                }
                storage += "\n";
            }
            fromDatabase.Close();
            return storage;
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
                    String storage = processReader(ref rdr);
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
            String query = "insert into USER values (" + int.Parse(UserIDEntry.Text) + ", " +
                (adminCheckBox.Checked) + ", \'" + fnameBox.Text + "\', \'" + lnameBox.Text + "\');";
            String query2 = "insert into RANK values (" + int.Parse(UserIDEntry.Text) + ", \'Newbie\', 0);";
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlCommand cmd2 = new MySqlCommand(query2, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
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
                String storage = processReader(ref rdr);
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
            mapviewListBox.Items.Add("<Select Map>");
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListBoxItem newItem = new ListBoxItem();
                newItem = new ListBoxItem();
                newItem.Content = reader["ID"].ToString();
                String[] temp = newItem.ToString().Split(':');
                mapviewListBox.Items.Add(int.Parse(temp[1])); //this still prints crap.
            }
            reader.Close();
            con.Close();
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
            String query = "SELECT * FROM LANDSCAPE WHERE LANDSCAPE.MID = " + int.Parse(text);
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            String storage = processReader(ref rdr);
            con.Close();
            MessageBox.Show(storage);
        }

        private void getRankButton_click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(UserIDEntry.Text.ToString()))
            {
                MessageBox.Show("You must enter a valid user ID");
                return;
            }
            String query = "SELECT USER.ID, USER.fname, USER.lname, RANK.level, RANK.participation_score FROM USER RIGHT JOIN RANK ON USER.ID = RANK.UID WHERE USER.ID = " +
                int.Parse(UserIDEntry.Text) + ";";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            String storage = processReader(ref rdr);
            con.Close();
            MessageBox.Show(storage);

        }

        private void GrabTopFiveButton_Click(object sender, EventArgs e)
        {
            String query = "SELECT USER.fname, USER.lname, RANK.participation_score FROM USER, RANK WHERE USER.ID = RANK.UID AND USER.admin = false ORDER BY RANK.participation_score DESC limit 5;";
            con.Open();
            MySqlCommand cmd = new MySqlCommand(query, con);
            MySqlDataReader rdr = cmd.ExecuteReader();
            String storage = processReader(ref rdr);
            con.Close();
            MessageBox.Show(storage);
        }

        private void increaseUserScoreButton_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrWhiteSpace(UserIDEntry.Text.ToString()))
            {
                MessageBox.Show("Please enter a valid user ID");
                return;
            }
            String query = "UPDATE RANK SET RANK.participation_score = RANK.participation_score + 5 WHERE RANK.uid = " + int.Parse(UserIDEntry.Text) + ";";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void getPolysButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(landscapeIDGetter.Text.ToString()))
            {
                MessageBox.Show("Enter a valid landscape ID.");
                return;
            }
            String query = "SELECT LANDSCAPE.name, Count(LANDSCAPE_POLYGON_POINTS.point_ID) AS 'Count of polygon points' FROM LANDSCAPE INNER JOIN LANDSCAPE_POLYGON_POINTS ON LANDSCAPE.ID = LANDSCAPE_POLYGON_POINTS.landscape_ID WHERE LANDSCAPE_POLYGON_POINTS.landscape_ID = " + int.Parse(landscapeIDGetter.Text) + " ORDER BY LANDSCAPE.ID;";
            MessageBox.Show(query);
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            String storage = processReader(ref rdr);
            con.Close();
            MessageBox.Show(storage);
        }

        private void deleteTrollButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(UserIDEntry.Text.ToString()))
            {
                MessageBox.Show("Enter a valid user ID to delete their ratings");
                return;
            }
            String query = "DELETE FROM USER_RATING WHERE USER_RATING.UID = " + int.Parse(UserIDEntry.Text) + ";";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void getPopPinsButton_Click(object sender, EventArgs e)
        {
            String query = "SELECT PINPOINT.name, COUNT(USER_RATING.PID) FROM PINPOINT, USER_RATING WHERE PINPOINT.ID = USER_RATING.PID AND USER_RATING.PID NOT IN(SELECT USER_RATING.PID FROM USER_RATING WHERE USER_RATING.rating = false) GROUP BY PINPOINT.ID ORDER BY -COUNT(USER_RATING.PID);";
            MySqlCommand cmd = new MySqlCommand(query, con);
            con.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();
            String storage = processReader(ref rdr);
            con.Close();
            MessageBox.Show(storage);
        }
    }
}

