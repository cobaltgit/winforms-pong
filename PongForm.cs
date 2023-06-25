using System.Diagnostics;

namespace Pong
{
    public partial class PongForm : Form
    {
        private int XSpeed = 5;
        private int YSpeed = 5;

        private int PlayerOneScore = 0;
        private int PlayerTwoScore = 0;

        private bool FirstStarted = true;
        private bool Cooldown = true;
        private bool Paused = false;

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
            if (!Paused)
            {
                TogglePause();
            }
        }

        private void PongForm_Activated(object sender, EventArgs e)
        {
            if (FirstStarted)
            {
                FirstStarted = false;
            } 
            else 
            { 
                TogglePause(); 
            }
        }

        private void BallTimer_Tick(object sender, EventArgs e)
        {
            if (Cooldown)
            {
                Cooldown = false;
                BallTimer.Interval = 15;
            }

            BallPic.Left -= XSpeed;
            BallPic.Top -= YSpeed;

            if (BallPic.Left > 800)
            {
                PlayerOneScoreLabel.Text = (++PlayerOneScore).ToString();
                BallPic.Location = new Point(this.Width / 2, rng.Next(1, this.Height));
                BallTimer.Interval = 1000;
                BallPic.Hide();
                Cooldown ^= true;
                BallPic.Show();
                XSpeed = -XSpeed;
                YSpeed = -YSpeed;
            }
            else if (BallPic.Right < 0)
            {
                PlayerTwoScoreLabel.Text = (++PlayerTwoScore).ToString();
                BallPic.Location = new Point(this.Width / 2, rng.Next(1, this.Height) % YSpeed);
                BallTimer.Interval = 1000;
                BallPic.Hide();
                Cooldown ^= true;
                BallPic.Show();
                XSpeed = -XSpeed;
                YSpeed = -YSpeed;
            }

            if (BallPic.Top <= 0 || BallPic.Top >= 550)
            {
                YSpeed = -YSpeed;
            }

            if (BallPic.Bounds.IntersectsWith(PlayerOnePaddlePic.Bounds) || BallPic.Bounds.IntersectsWith(PlayerTwoPaddlePic.Bounds))
            { // todo: the ball shouldn't go up or down if it bounces off the middle part of the paddle pictureboxes
                XSpeed = -XSpeed;
            }
        }
        private void PongForm_KeyDown(object sender, KeyEventArgs e) // caveat: player 1 and player 2 cannot control their paddles at the same time due to a WinForms limitation
        {
            if (!Paused)
            {
                switch (e.KeyCode) // the paddles will not completely reach the top/bottom of the screen as originally featured in the real 1972 circuit board
                {
                    case Keys.Up:
                        if (PlayerOnePaddlePic.Top > 15)
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
                        if (PlayerTwoPaddlePic.Top > 15)
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
            Paused ^= true;
            if (Paused)
            {
                BallTimer.Stop();
                this.Text = "Pong: Press ESC or refocus window to unpause";
            } 
            else
            {
                BallTimer.Start();
                this.Text = "Pong";
            }
        }
    }
}