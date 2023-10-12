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

namespace BloodBankProsit
{
    public partial class Pass : Form
    {
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");
        public Pass()
        {
            InitializeComponent();
        }
        public static string passw;
        private void Pass_Load(object sender, EventArgs e)
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
                    String pass = Convert.ToString(reader["password"]);
                    //  String blood = Convert.ToString(reader["b_group"]);
                    // String ldn = Convert.ToString(reader["lastdonate"]);
                    // String loc= Convert.ToString(reader["location"]);
                    // String email = Convert.ToString(reader["email"]);

                    passw = pass;
                    textBox4.Text = Id;
                    //textBox2.Text = name;
                    // textBox3.Text = blood;
                    // textBox4.Text = ldn;
                    // textBox5.Text = loc;
                    // textBox6.Text = email;
                    
                }
                con.Close();
            }
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox2, "Required");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox3, " Required");
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox4, "Required");
            }
            else if (textBox1.Text != passw )

            {
                MessageBox.Show("wrong password");

            }
            else if(textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("Enter new  password correctly");
            }
            else
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("update user_pass set password='" + textBox1.Text + "' where user_id= " + textBox4.Text + "", con);
                cmd.ExecuteNonQuery();


                //cmd.NextResult();
                //MessageBox.Show(cmd1);
                MessageBox.Show("Password change succesfully");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                con.Close();

            }
        }

        private void BACK_Click(object sender, EventArgs e)
        {

            this.Hide();
            userprofile f = new userprofile();
            f.Show();

        }
    }
}
