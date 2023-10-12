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
    public partial class Price : Form
    {
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");
        public Price()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("PriceUPDATER('" + comboBox1.Text + "', " + textBox8.Text + ")", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
                MessageBox.Show(comboBox1.Text + "Price set succecfully");
                
            }
            catch {
                MessageBox.Show("please enter valid price and B_group");
            }
            finally { con.Close(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminProfile profile = new AdminProfile();
            profile.Show();
        }
    }
}
