using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            button1.Click += new EventHandler(button1_Click);
        }

        public void button1_Click(Object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Visible = true;
        }
    }
}
