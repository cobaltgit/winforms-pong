namespace Pong
{
    public partial class PongForm : Form
    {
        private int XSpeed = 5;
        private int YSpeed = 5;
        private const int BallBottomBoundary = 550;

        private Player PlayerOne;
        private Player PlayerTwo;

        private bool FirstStarted = true;
        private bool Reset = true;
        private bool Paused = false;

        private Random rng = new Random();

        public PongForm()
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.PlayerOne = new Player(PlayerOnePaddlePic, Keys.Up, Keys.Down);
            this.PlayerTwo = new Player(PlayerTwoPaddlePic, Keys.W, Keys.S);

            BallTimer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        { // Draws the divider line
            base.OnPaint(e);
            int Midpoint = this.Width / 2;

            using (Pen pen = new Pen(Color.White, 2f))
            {
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                pen.DashPattern = new float[] { 5, 5, 5, 5 };
                e.Graphics.DrawLine(pen, Midpoint, 0, Midpoint, this.Height);
            }
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
            if (Reset)
            {
                Reset = false;
                BallPic.Show();
                BallTimer.Interval = 15;
            }

            BallPic.Left -= XSpeed;
            BallPic.Top -= YSpeed;

            if (BallPic.Left > 800)
            {
                PlayerOne.AddScore(PlayerOneScoreLabel);
                ResetBall();
            }
            else if (BallPic.Right < 0)
            {
                PlayerTwo.AddScore(PlayerTwoScoreLabel);
                ResetBall();
            }

            if (BallPic.Top <= 0 || BallPic.Top >= BallBottomBoundary)
            {
                YSpeed = -YSpeed;
            }

            if (BallPic.Bounds.IntersectsWith(PlayerOne.Paddle.Bounds))
            {
                DoCollision(PlayerOne.Paddle);
            }
            else if (BallPic.Bounds.IntersectsWith(PlayerTwo.Paddle.Bounds))
            {
                DoCollision(PlayerTwo.Paddle);
            }
        }
        private void PongForm_KeyDown(object sender, KeyEventArgs e) // caveat: player 1 and player 2 cannot control their paddles at the same time due to a WinForms limitation
        {
            if (!Paused)
            {
                PlayerOne.Move(e.KeyCode, 15);
                PlayerTwo.Move(e.KeyCode, 15);
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

        private void DoCollision(PictureBox Paddle)
        { // todo: ball should bounce off the top/bottom edges of the paddle
            if (BallPic.Location.Y >= Paddle.Top - BallPic.Height && BallPic.Location.Y <= Paddle.Top + BallPic.Height) // near-top segment of paddle
            {
                YSpeed = -rng.Next(4, 6);
            }
            else if (BallPic.Location.Y > Paddle.Top + BallPic.Height && BallPic.Location.Y <= Paddle.Top + 2 * BallPic.Height) // upper-middle segment of paddle
            {
                YSpeed = -rng.Next(2, 3);
            }
            else if (BallPic.Location.Y > Paddle.Top + 2 * BallPic.Height && BallPic.Location.Y <= Paddle.Top + 3 * BallPic.Height) // middle segment of paddle
            {
                YSpeed = 0;
            }
            else if (BallPic.Location.Y > Paddle.Top + 3 * BallPic.Height && BallPic.Location.Y <= Paddle.Top + 4 * BallPic.Height) // lower-middle segment of paddle
            {
                YSpeed = rng.Next(2, 3);
            }
            else if (BallPic.Location.Y > Paddle.Top + 3 * BallPic.Height && BallPic.Location.Y <= Paddle.Bottom + BallPic.Height) // near-bottom of paddle
            {
                YSpeed = rng.Next(4, 6);
            }
            XSpeed = -XSpeed;
        }
        private void ResetBall()
        {
            BallPic.Location = new Point(this.Width / 2, BallPic.Top);
            BallTimer.Interval = 2000;
            BallPic.Hide();
            Reset ^= true;
        }
    }
}