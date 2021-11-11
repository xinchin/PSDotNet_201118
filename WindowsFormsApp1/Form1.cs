using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void demoHelloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Demo.DemoHelloForm frm = new Demo.DemoHelloForm();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void demoForm1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Demo.DemoForm1 frm = new Demo.DemoForm1();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }
    }
}
