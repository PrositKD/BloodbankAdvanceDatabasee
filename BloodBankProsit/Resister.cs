using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BloodBankProsit
{
    public partial class Resister : Form
    {
        
       
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");
        public Resister()
        {
            InitializeComponent();
        }
        public static string username;
        public static string password;
        
        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox2.Text;
            password=textBox5.Text;
            try
            {
                
                con.Open();
               
                OracleCommand cmd = new OracleCommand("insert into blood_User values (  user_id.nextval ,'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + ",TO_DATE('" + textBox6.Text + "','DD-MM-YYYY'),'" + textBox7.Text + "','" + textBox8.Text + "')", con);
                cmd.ExecuteNonQuery();
               
                con.Close();
               
                textBox8.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                this.Hide();
                resister2 profile = new resister2();
                profile.Show();

            }
            catch
            {
                if  (string.IsNullOrEmpty(textBox2.Text))
                {
                    textBox2.Focus();
                    errorProvider2.SetError(this.textBox2, "Your name Required");
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
                else if (string.IsNullOrEmpty(textBox5.Text))
                {
                    textBox5.Focus();
                    errorProvider5.SetError(this.textBox5, "mobile number Required");
                }
                else if (string.IsNullOrEmpty(textBox6.Text))
                {
                    textBox6.Focus();
                    errorProvider6.SetError(this.textBox6, "Date of Birth Required");
                }
                else if (string.IsNullOrEmpty(textBox7.Text))
                {
                    textBox7.Focus();
                    errorProvider7.SetError(this.textBox7, "Email Required");
                }
                else if (string.IsNullOrEmpty(textBox7.Text))
                {
                    textBox8.Focus();
                    errorProvider8.SetError(this.textBox7, "Location Required");
                }
                else
                {
                    try
                    {
                        OracleCommand cmd = new OracleCommand("insert into blood_User values (  id.nextval ,'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'," + textBox5.Text + ",TO_DATE('" + textBox6.Text + "','DD-MM-YYYY'),'" + textBox7.Text + "','" + textBox8.Text + "')", con);
                        cmd.ExecuteNonQuery();


                        textBox8.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        this.Hide();
                        resister2 profile = new resister2();
                        profile.Show();
                    }
                    catch
                    {
                        MessageBox.Show("Cheak format Like Date dd-mm-yyyy");
                    }
                    finally { con.Close(); }

                }

            }
       }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Resister_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            this.textBox6.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            login cs=new login();
            cs.Show();
        }
    }
}
