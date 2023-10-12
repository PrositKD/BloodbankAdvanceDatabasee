using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BloodBankProsit
{ 
    public partial class userprofile : Form
    {
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");
        public userprofile()
        {
            InitializeComponent();
        }
        public static string userid;
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UpdateProfile profile = new UpdateProfile();
            profile.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           login profile = new login();
            profile.Show();
        }

        private void userprofile_Load(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("select * from AllDetails where user_id  =" + login.username + " and password='" + login.password + "'", con);
            cmd.ExecuteNonQuery();
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    String Id = Convert.ToString(reader["user_Id"]);
                    String name = Convert.ToString(reader["Name"]);
                  //  String blood = Convert.ToString(reader["b_group"]);
                   // String ldn = Convert.ToString(reader["lastdonate"]);
                   // String loc= Convert.ToString(reader["location"]);
                   // String email = Convert.ToString(reader["email"]);


                    textBox1.Text = Id;
                    textBox2.Text = name;
                   // textBox3.Text = blood;
                   // textBox4.Text = ldn;
                   // textBox5.Text = loc;
                   // textBox6.Text = email;

                }

            }
           

                con.Close();
            textBox1.Enabled = false;
            userid = textBox1.Text;



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == "Location")
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from bloodsearch where location='" + textBox8.Text + "' ", con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;

                ///Image column
                /* DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                 dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
                 dgv.ImageLayout = DataGridViewImageCellLayout.Stretch; */

                /// Autosize Table Column
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ///Image Row Height
                // dataGridView1.RowTemplate.Height = 180;
                con.Close();


            }
            else if (comboBox1.SelectedItem == "BloodGroup")
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from bloodsearch where b_group  ='" + textBox8.Text + "' ", con);
                cmd.ExecuteNonQuery();
                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                dataGridView1.DataSource = ds;

                ///Image column
                /* DataGridViewImageColumn dgv = new DataGridViewImageColumn();
                 dgv = (DataGridViewImageColumn)dataGridView1.Columns[5];
                 dgv.ImageLayout = DataGridViewImageCellLayout.Stretch; */

                /// Autosize Table Column
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ///Image Row Height
                // dataGridView1.RowTemplate.Height = 180;
                con.Close();


            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("RControl.insert_request(" + textBox7.Text + ",'" + textBox9.Text + "',SYSDATE, " + textBox1.Text + ")", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Send request succesfull");
                textBox7.Clear();
                textBox9.Clear();
               
            }
            catch
            {
                MessageBox.Show("Select the doner first");
            }
            finally
            {
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void notificationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            notify nt = new notify();
            nt.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
           Pass nt = new Pass();
            nt.Show();
        }
    }
}
