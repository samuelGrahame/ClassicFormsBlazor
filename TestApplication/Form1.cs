using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Hello World";
            // need to invoke change...
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X - 1, this.Location.Y);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X + 1, this.Location.Y);
        }
    }
}
