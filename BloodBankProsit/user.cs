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

namespace BloodBankProsit
{
    public partial class user : Form
    {
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");
        public user()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminProfile admin = new AdminProfile();
            admin.Show();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("select blood_user.*,blood_details.* from blood_user,blood_details where blood_user.user_id=blood_details.user_id and blood_user.user_id =" +textBox1.Text + "", con);
            cmd.ExecuteNonQuery();
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    String fn = Convert.ToString(reader["fname"]);
                    String mn = Convert.ToString(reader["mname"]);
                    String name = Convert.ToString(reader["Name"]);
                    String blood = Convert.ToString(reader["b_group"]);
                    String ldn = Convert.ToString(reader["lastdonate"]);
                    String loc = Convert.ToString(reader["location"]);
                    String email = Convert.ToString(reader["email"]);
                    String bprice = Convert.ToString(reader["b_price"]);


                    textBox2.Text = mn;
                    textBox7.Text = fn;
                    textBox8.Text = name;
                    comboBox1.Text = blood;
                    textBox3.Text = ldn;
                    textBox4.Text = loc;
                    textBox5.Text = email;
                    textBox6.Text = bprice;

                }
                

            }
            else
            {
                MessageBox.Show("No ID found");
                textBox2.Clear();
                textBox7.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox8.Clear();
                comboBox1.Text="";
                   
            }
            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
             char ch = e.KeyChar;
                if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
                {
                    e.Handled = true;
                }
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminProfile profile= new AdminProfile();
            profile.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("UPDATER(" + textBox1.Text + ",'" + textBox8.Text + "','" + textBox7.Text + "', '" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "'," + textBox6.Text + ",TO_DATE('" + textBox3.Text + "', 'mm/dd/yyyy hh:mi:ss AM'))", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update data succesfull");
            }
            catch
            {
                MessageBox.Show("Insert data correctly");
            }
            finally { con.Close(); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to delete all data?", "Confirm message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("deleteuser(" + textBox1.Text + ")", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete data succesfull");
                    this.Close();
                    user aa = new user();
                    aa.Show();
                }
                catch
                {
                    MessageBox.Show("Insert id first");
                }
                finally { con.Close(); }
            }
        }

        private void user_Load(object sender, EventArgs e)
        {

        }
    }
}
