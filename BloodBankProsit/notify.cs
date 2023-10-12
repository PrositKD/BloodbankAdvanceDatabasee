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
    public partial class notify : Form
    {
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");
        public notify()
        {
            InitializeComponent();
        }

        private void notify_Load(object sender, EventArgs e)
        {
            con.Open();
            OracleCommand cmd = new OracleCommand("select RSender,B_type,time from request where RReciver=" + userprofile.userid + " ", con);
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to accept?", "Confirm message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("RControl.acceptreject( " + textBox1.Text + ")", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("request accected");
                    textBox1.Clear();
                    this.Close();
                    notify f = new notify();
                    f.Show();

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm to reject request?", "Confirm message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    con.Open();
                    OracleCommand cmd = new OracleCommand("RControl.acceptreject( " + textBox1.Text + ")", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("request rejected");
                    textBox1.Clear();
                    this.Close();
                    notify f = new notify();
                    f.Show();

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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            userprofile f = new userprofile();
            f.Show();

        }
    }
}
