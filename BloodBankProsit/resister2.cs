using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BloodBankProsit
{
    public partial class resister2 : Form
    {
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");
        public resister2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                comboBox1.Focus();
                errorProvider1.SetError(this.comboBox1, "Your name Required");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "mobile number Required");
            }
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.Focus();
                errorProvider3.SetError(this.textBox3, "Mother name Required");
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox3.Focus();
                errorProvider4.SetError(this.textBox4, "Father name Required");
            }


            else
            {

                try {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("insert into blood_Details values (  bnumber.nextval ,'" + comboBox1.Text + "','" + textBox2.Text + "',TO_DATE('" + textBox3.Text + "','DD-MM-YYYY'),'" + textBox1.Text + "')", con);
                    OracleCommand cmd2 = new OracleCommand("insert into User_pass values (  " + textBox1.Text + " ,'" + textBox4.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();



                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    MessageBox.Show("Your Id is " + textBox1.Text);
                    this.Hide();
                    login cs = new login();
                    cs.Show();
                }
                catch
                {
                    MessageBox.Show("Cheak format Like Date dd-mm-yyyy");
                    }
                finally { con.Close(); }
            }

        }

        private void resister2_Load(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("select * from blood_user where name ='" + Resister.username + "' and mnum=" + Resister.password + "", con);
            cmd.ExecuteNonQuery();
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    String Id = Convert.ToString(reader["user_Id"]);


                    textBox1.Text = Id;
                    
                }

            }

            con.Close();
            textBox1.Enabled = false;
            this.textBox3.Text = "12-10-2010";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.Text = Convert.ToString(0);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login cs = new login();
            cs.Show();
        }
    }
}
