using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankProsit
{
    public partial class AdminProfile : Form
    {
        public AdminProfile()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            printdetails print= new printdetails();   
            print.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            user admin = new user();
            admin.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
           login admin = new login();
            admin.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Price pp= new Price();
            pp.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            useractivity admin = new useractivity();
            admin.Show();
        }
    }
}
