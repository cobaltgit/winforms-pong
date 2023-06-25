using System.Diagnostics;
using System.Threading;

namespace Pong
{
    public partial class PongForm : Form
    {
        private int xSpeed = 5;
        private int ySpeed = 5;

        private int playerOneScore = 0;
        private int playerTwoScore = 0;

        private bool cooldown = true;
        private bool paused = false;

        private Random rng = new Random();

        public PongForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            BallTimer.Start();
        }

        private void PongForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void PongForm_Deactivate(object sender, EventArgs e)
        {
            TogglePause();
        }

        private void PongForm_Activated(object sender, EventArgs e)
        {
            TogglePause();
        }

        private void BallTimer_Tick(object sender, EventArgs e)
        {
            if (cooldown)
            {
                cooldown = false;
                BallTimer.Interval = 15;
            }

            BallPic.Left -= xSpeed;
            BallPic.Top -= ySpeed;

            if (BallPic.Left > 775)
            {
                PlayerOneScoreLabel.Text = (++playerOneScore).ToString();
                BallPic.Location = new Point(this.Width / 2, rng.Next(1, this.Height));
                BallTimer.Interval = 1000;
                BallPic.Hide();
                if (!cooldown)
                {
                    cooldown = true;
                }
                BallPic.Show();
                xSpeed = -xSpeed;
                ySpeed = -ySpeed;
            }
            else if (BallPic.Left < 0)
            {
                PlayerTwoScoreLabel.Text = (++playerTwoScore).ToString();
                BallPic.Location = new Point(this.Width / 2, rng.Next(1, this.Height));
                BallTimer.Interval = 1000;
                BallPic.Hide();
                if (!cooldown)
                {
                    cooldown = true;
                }
                BallPic.Show();
                xSpeed = -xSpeed;
                ySpeed = -ySpeed;
            }

            if (BallPic.Top < 0 || BallPic.Top > 550)
            {
                ySpeed = -ySpeed;
            }

            if (BallPic.Bounds.IntersectsWith(PlayerOnePaddlePic.Bounds) || BallPic.Bounds.IntersectsWith(PlayerTwoPaddlePic.Bounds))
            { // todo: the ball shouldn't go up or down if it bounces off the middle part of the paddle pictureboxes
                xSpeed = -xSpeed;
            }
        }
        private void PongForm_KeyDown(object sender, KeyEventArgs e) // caveat: player 1 and player 2 cannot control their paddles at the same time due to a WinForms limitation
        {
            if (!paused)
            {
                switch (e.KeyCode) // the paddles will not completely reach the top/bottom of the screen as originally featured in the real 1972 circuit board
                {
                    case Keys.Up:
                        if (PlayerOnePaddlePic.Top > 10)
                        {
                            PlayerOnePaddlePic.Top -= 15;
                        }
                        break;
                    case Keys.Down:
                        if (PlayerOnePaddlePic.Top < 450)
                        {
                            PlayerOnePaddlePic.Top += 15;
                        }
                        break;
                    case Keys.W:
                        if (PlayerTwoPaddlePic.Top > 10)
                        {
                            PlayerTwoPaddlePic.Top -= 15;
                        }
                        break;
                    case Keys.S:
                        if (PlayerTwoPaddlePic.Top < 450)
                        {
                            PlayerTwoPaddlePic.Top += 15;
                        }
                        break;
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                TogglePause();
            }
        }

        private void TogglePause()
        {
            paused ^= true;
            if (paused)
            {
                BallTimer.Stop();
                this.Text = "Pong: Paused";
            } else
            {
                BallTimer.Start();
                this.Text = "Pong";
            }
        }
    }
}