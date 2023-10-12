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
    public partial class Admin : Form
    {
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");
        public Admin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "select * from admin where admin_id ='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand(query, con);
                cmd.ExecuteNonQuery();

                OracleDataAdapter sda = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                DataTable dt = ds.Tables[0];


                if (dt.Rows.Count > 0)
                {

                    //MessageBox.Show("login Succesfull ");
                    this.Hide();
                    AdminProfile profile = new AdminProfile();
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
            finally
            {
                con.Close();
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "ID Required");
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
           login admin = new login();
            admin.Show();
        }
    }
    }

