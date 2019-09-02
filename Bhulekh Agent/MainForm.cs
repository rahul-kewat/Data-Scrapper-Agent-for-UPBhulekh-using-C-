using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bhulekh_Agent
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool a = false;
            foreach (Form frm1 in fc)
            {
                if (frm1.Text == "DataAgent")
                {
                    a = true;
                    frm1.BringToFront();
                }
            }
            if (a == false)
            {
                frmDataAgent frm = new frmDataAgent();
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                frm.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool a = false;
            foreach (Form frm1 in fc)
            {
                if (frm1.Text == "frmFrontPage")
                {
                    a = true;
                    frm1.BringToFront();
                }
            }
            if (a == false)
            {
                frmFrontPage frm = new frmFrontPage();
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                frm.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool a = false;
            foreach (Form frm1 in fc)
            {
                if (frm1.Text == "frmReports")
                {
                    a = true;
                    frm1.BringToFront();
                }
            }
            if (a == false)
            {
                frmReports frm = new frmReports();
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                frm.BringToFront();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            bool a = false;
            foreach (Form frm1 in fc)
            {
                if (frm1.Text == "frmGataDataAgent")
                {
                    a = true;
                    frm1.BringToFront();
                }
            }
            if (a == false)
            {
                frmGataDataAgent frm = new frmGataDataAgent();
                frm.MdiParent = this;
                frm.Dock = DockStyle.Fill;
                frm.Show();
                frm.BringToFront();
            }
        }
    }
}







