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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BloodBankProsit
{
    public partial class login : Form
    {
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");

        public login()
        {    
            InitializeComponent();
        }
        public static string username;
        public static string password;

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;
            string query = "select * from user_pass where user_id =" + textBox1.Text + " and password='" + textBox2.Text + "'";
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.ExecuteNonQuery();

                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count>0)
                {

                    //MessageBox.Show("login Succesfull ");
                    this.Hide();
                    userprofile profile= new userprofile();
                    profile.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Id or Password");
                }
            }
            catch
            {
                MessageBox.Show("Enter The User Id Pass First");
            }
            finally {
                con.Close();
            }

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Resister rs = new Resister();
            rs.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "User id Required");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Focus();
                errorProvider2.SetError(this.textBox2, "passwordRequired");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin admin= new Admin();
            admin.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
        }
    }
}
