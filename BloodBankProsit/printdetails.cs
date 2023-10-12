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
using DGVPrinterHelper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BloodBankProsit
{
    public partial class printdetails : Form
    {
        OracleConnection con = new OracleConnection(@"USER ID=SYSTEM;password=445566");
        public printdetails()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminProfile admin = new AdminProfile();
            admin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVPrinter print = new DGVPrinter();
            print.Title = "Donor Details";
            print.SubTitle = "Print Date: " + DateTime.Now.ToShortDateString();
            print.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            print.PageNumbers = true;
            print.PageNumberInHeader = false;
            print.PorportionalColumns = true;
            print.HeaderCellAlignment = StringAlignment.Near;
            print.Footer = "Blood Bank Prosit";
            print.FooterSpacing = 15;
            print.PrintDataGridView(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(comboBox1.SelectedItem == "Location")
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from Usersearch where location ='" + textBox1.Text + "' ", con);
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
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ///Image Row Height
                // dataGridView1.RowTemplate.Height = 180;
                con.Close();


            }
            else if (comboBox1.SelectedItem == "BloodGroup")
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from Usersearch where B_GROUP  ='" + textBox1.Text + "' ", con);
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
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                ///Image Row Height
                // dataGridView1.RowTemplate.Height = 180;
                con.Close();


            }
        }
    }
}
