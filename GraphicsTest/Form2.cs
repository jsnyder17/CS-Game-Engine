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
    public partial class Form2 : Form
    {
        private PictureBox pb;
        private Font fnt;
        private Timer timer;
        private Rectangle rect;
        private int incrementAmt;
        private bool moving;
        private bool paused;

        public Form2()
        {
            InitializeComponent();

            incrementAmt = 4;
            moving = false;
            paused = false;

            fnt = new Font("Arial", 10);

            InitializePictureBox();

            InitializeRectangle();

            this.KeyDown += new KeyEventHandler(Form2_KeyDown);

            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);

            timer.Start();
        }

        public void InitializePictureBox()
        {
            pb = new PictureBox();
            pb.Dock = DockStyle.None;
            pb.Size = new Size(650, 350);
            pb.Location = new Point(50, 50);
            pb.BackColor = Color.White;
            pb.Paint += new PaintEventHandler(pb_Paint);
            this.Controls.Add(pb);
        }

        public void InitializeRectangle()
        {
            rect = new Rectangle();
            rect.Size = new Size(200, 200);
        }

        public void pb_Paint(Object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (paused)
            {
                g.DrawString("PAUSED", fnt, Brushes.Black, new Point(pb.Width / 2, pb.Height / 2));
            }

            g.DrawString("Lmao cheese wiz bad", fnt, Brushes.Blue, new Point(rect.X + 100, rect.Y + 70));
            g.DrawRectangle(Pens.Red, rect);
        }

        public void Form2_KeyDown(Object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    if (!paused)
                    {
                        rect.Offset(0, incrementAmt * -1);
                        moving = true;
                    }
                    break;

                case Keys.A:
                    if (!paused)
                    {
                        rect.Offset(incrementAmt * -1, 0);
                        moving = true;
                    }
                    break;

                case Keys.S:
                    if (!paused)
                    {
                        rect.Offset(0, incrementAmt);
                        moving = true;
                    }
                    break;

                case Keys.D:
                    if (!paused)
                    {
                        rect.Offset(incrementAmt, 0);
                        moving = true;
                    }
                    break;

                case Keys.Escape:
                    if (!paused)
                    {
                        paused = true;
                    }
                    else
                    {
                        paused = false;
                    }

                    break;

                default:
                    break;
            }
        }

        public void timer_Tick(Object sender, EventArgs e)
        {
            pb.Invalidate();

            label2.Text = "(" + rect.X + ", " + rect.Y + ")";
            label4.Text = moving.ToString().ToUpper();

            moving = false;
        }
    }
}
