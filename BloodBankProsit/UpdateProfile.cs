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
    public partial class UpdateProfile : Form
    {
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");
        public UpdateProfile()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            userprofile profile = new userprofile();
            profile.Show();
        }

        private void UpdateProfile_Load(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("select blood_user.*,blood_details.* from blood_user,user_pass,blood_details where blood_user.user_id=user_pass.user_id and" +
                " blood_details.user_id=user_pass.user_id and user_pass.user_id ='" + login.username + "' and user_pass.password=" + login.password + "", con);
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
                    string uid= Convert.ToString(reader["user_id"]);


                    textBox1.Text = mn;
                    textBox7.Text = fn;
                    textBox2.Text = name;
                    comboBox1.Text = blood;
                    textBox3.Text = ldn;
                    textBox4.Text = loc;
                    textBox5.Text = email;
                    textBox6.Text = bprice;
                    textBox8.Text= uid;

                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("UPDATER(" + textBox8.Text + ",'" + textBox2.Text + "','" + textBox7.Text + "', '" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox1.Text + "'," + textBox6.Text + ",TO_DATE('" + textBox3.Text + "', 'mm/dd/yyyy hh:mi:ss AM'))", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                MessageBox.Show("Update data succesfull");
            }
            catch
            {
                MessageBox.Show("Insert data correctly");
            }
            finally
            {
                con.Close();
            }
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to delete all data?", "Confirm message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                OracleCommand cmd = new OracleCommand("deleteuser(" + textBox8.Text + ")", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Delete data succesfull");
              this.Close();
                login aa = new login();
                aa.Show();
            }
        }
    }
}
