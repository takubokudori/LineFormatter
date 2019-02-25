using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace LineFormatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formatting();
        }

        private void Formatting()
        {
            string a = BeforeBox.Text.Replace("\r", "").Replace("\n", " ").Replace("  ", " ");
            AfterBox.Text = a.Replace(".", ".\r\n");
        }

        private void BeforeBox_TextChanged(object sender, EventArgs e)
        {
            if (isAutoFormat.Checked) Formatting();
        }
    }
}