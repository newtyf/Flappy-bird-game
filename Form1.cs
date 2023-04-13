using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdGame
{
    public partial class Form1 : Form
    {
        private int pipeSpeed = 8;
        private int gravity = 15;
        private int score = 0;
        private Bitmap bmpImageToDown;
        private Bitmap bmpImageToUp;
        
        public Form1()
        {
            InitializeComponent();
            
            /*
            Image imagen = flappyBird.Image;
            int angleRotate = 15;
            
            bmpImageToDown = new Bitmap(imagen.Width, imagen.Height);
            Graphics graphic1 = Graphics.FromImage(bmpImageToDown);
            graphic1.RotateTransform(angleRotate);
            graphic1.DrawImage(imagen, new Point(0,0));
            
            bmpImageToUp = new Bitmap(imagen.Width, imagen.Height);
            Graphics graphicUp = Graphics.FromImage(bmpImageToUp);
            graphicUp.RotateTransform(-angleRotate);
            graphicUp.DrawImage(imagen, new Point(0,0));
            flappyBird.Image = bmpImageToDown;
            
            */
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // label1.Parent = pipeTop;
            label1.BackColor = Color.Transparent;
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;

            if (pipeBottom.Left < -pipeBottom.Width)
            {
                pipeBottom.Left = 600;
                score++;
                label1.Text = $@"Score: {score}";
            }
            if (pipeTop.Left < -pipeTop.Width)
            {
                pipeTop.Left = 800;
                score++;
                label1.Text = $@"Score: {score}";
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) || flappyBird.Bounds.IntersectsWith(ground.Bounds) )
            {
                Debug.WriteLine("game over");
                GameOver();
            }
            
            if (score == 15)
            {
                pipeSpeed = 15;
            }
        }

        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            // throw new System.NotImplementedException();
            if (e.KeyCode == Keys.Space)
            {
                gravity = -15;
                // flappyBird.Image = bmpImageToUp;
            }
        }

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
                // flappyBird.Image = bmpImageToDown;
            }
        }

        private void GameOver()
        {
            gameTimer.Stop();
            label1.Height+= 100;
            label1.Width*= 2;
            label1.Text = $@"Game Over, su puntaje fue de {score}";
            label1.Location = new Point(Width/2 - label1.Width/2, Height/2);
        }
    }
}