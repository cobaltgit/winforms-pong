using System.Threading;

namespace Pong
{
    public partial class PongForm : Form
    {
        private string xDirection = "right";
        private string yDirection = "up";

        private int playerOneScore = 0;
        private int playerTwoScore = 0;

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
            BallTimer.Stop();
            this.Text = "Pong: Paused";
        }

        private void PongForm_Activated(object sender, EventArgs e)
        {
            BallTimer.Start();
            this.Text = "Pong";
        }

        private void BallTimer_Tick(object sender, EventArgs e)
        {
            if (xDirection == "right")
            {
                BallPic.Left += 5;
            }
            else if (xDirection == "left")
            {
                BallPic.Left -= 5;
            }

            if (yDirection != null) // todo: the ball shouldn't go up or down if it bounces off the middle part of the paddle pictureboxes
            {
                if (yDirection == "up")
                {
                    BallPic.Top -= 5;
                }
                else if (yDirection == "down")
                {
                    BallPic.Top += 5;
                }
            }

            if (BallPic.Left > 775)
            {
                playerOneScore++;
                PlayerOneScoreLabel.Text = playerOneScore.ToString();
                BallPic.Location = new Point(this.Width / 2, rng.Next(1, this.Height));
                BallTimer.Stop();
                BallPic.Hide();
                Thread.Sleep(1000);
                BallPic.Show();
                BallTimer.Start();
                xDirection = "left";
                yDirection = yDirection == "up" ? "down" : "up";
            }
            else if (BallPic.Left < 0)
            {
                playerTwoScore++;
                PlayerTwoScoreLabel.Text = playerTwoScore.ToString();
                BallPic.Location = new Point(this.Width / 2, rng.Next(1, this.Height));
                BallTimer.Stop();
                BallPic.Hide();
                Thread.Sleep(1000);
                BallPic.Show();
                BallTimer.Start();
                xDirection = "right";
                yDirection = yDirection == "up" ? "down" : "up";
            }

            if (BallPic.Top < 0)
            {
                yDirection = "down";
            }
            else if (BallPic.Top > 550)
            {
                yDirection = "up";
            }

            if (BallPic.Bounds.IntersectsWith(PlayerOnePaddlePic.Bounds) || BallPic.Bounds.IntersectsWith(PlayerTwoPaddlePic.Bounds))
            {
                if (xDirection == "left")
                {
                    xDirection = "right";
                }
                else if (xDirection == "right")
                {
                    xDirection = "left";
                }

                if (yDirection == "up")
                {
                    yDirection = "down";
                }
                else if (yDirection == "down")
                {
                    yDirection = "up";
                }
            }
        }
        private void PongForm_KeyDown(object sender, KeyEventArgs e) // caveat: player 1 and player 2 cannot control their paddles at the same time due to a WinForms limitation
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (PlayerOnePaddlePic.Top > 10)
                    {
                        PlayerOnePaddlePic.Top -= 10;
                    }
                    break;
                case Keys.Down:
                    if (PlayerOnePaddlePic.Top < 450)
                    {
                        PlayerOnePaddlePic.Top += 10;
                    }
                    break;
                case Keys.W:
                    if (PlayerTwoPaddlePic.Top > 10)
                    {
                        PlayerTwoPaddlePic.Top -= 10;
                    }
                    break;
                case Keys.S:
                    if (PlayerTwoPaddlePic.Top < 450)
                    {
                        PlayerTwoPaddlePic.Top += 10;
                    }
                    break;
            }
        }
    }
}