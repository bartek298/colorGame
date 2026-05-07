using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace colorGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            reset.Visible = false;
            over.Visible = false;
        }
        Random r = new Random();
        Color[] colors = { Color.Blue, Color.Red, Color.Green,Color.Black };
        int score = 0;
        void movebar(PictureBox bars)
        {
            if (bars.Top <= this.Height)
            {
                bars.Top += 4;
            }
            else
            {
                bars.Top = 0;
                bars.BackColor = colors[r.Next(colors.Length)];
            }
        }

        void gameOver(PictureBox bars)
        {
            if (bars.Bounds.IntersectsWith(player.Bounds))
            {
                if (bars.BackColor != player.BackColor)
                {
                    timer1.Enabled = false;
                    reset.Visible = true;
                    over.Visible = true;
                }
                else
                {
                    score++;
                    points.Text = score.ToString();
                } 
   
            }
        }
        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && player.Left>0)
            {
                player.Left += -20;
            }
            if (e.KeyCode == Keys.Right&& player.Right<=this.Width)
            {
                player.Left += +20;
            }
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                player.BackColor = colors[r.Next(colors.Length)];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            movebar(pictureBox1);
            movebar(pictureBox2);
            movebar(pictureBox3);
            gameOver(pictureBox1);
            gameOver(pictureBox2);
            gameOver(pictureBox3);
        }

        private void reset_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void over_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
