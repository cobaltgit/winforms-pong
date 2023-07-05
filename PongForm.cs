namespace Pong
{
    public partial class PongForm : Form
    {
        private Player PlayerOne;
        private Player PlayerTwo;

        private Ball Ball;

        private bool Reset = true;
        private bool Paused = true;

        public PongForm()
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.PlayerOne = new Player(PlayerOnePaddlePic, Keys.Up, Keys.Down);
            this.PlayerTwo = new Player(PlayerTwoPaddlePic, Keys.W, Keys.S);
            this.Ball = new Ball(BallPic, BallTimer);

            this.Ball.Timer.Start();
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
            this.TogglePause();
        }

        private void PongForm_Activated(object sender, EventArgs e)
        {
            this.TogglePause();
        }

        private void BallTimer_Tick(object sender, EventArgs e)
        {
            if (Reset)
            {
                Reset = false;
                Ball.IsMoving = true;
                Ball.Graphics.Show();
                Ball.Timer.Interval = 15;
            }

            if (Ball.IsMoving)
            {
                Ball.DoMovement();
            }

            if (Ball.Graphics.Left > 800)
            {
                PlayerOne.AddScore(PlayerOneScoreLabel);
                ResetGame();
            }
            else if (Ball.Graphics.Right < 0)
            {
                PlayerTwo.AddScore(PlayerTwoScoreLabel);
                ResetGame();
            }

            if (Ball.IntersectsWithPaddle(PlayerOne.Paddle))
            {
                Ball.CollideWith(PlayerOne.Paddle);
            }
            else if (Ball.IntersectsWithPaddle(PlayerTwo.Paddle))
            {
                Ball.CollideWith(PlayerTwo.Paddle);
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
                Ball.IsMoving = false;
                this.Text = "Pong: Press ESC or refocus window to unpause";
            }
            else
            {
                Ball.IsMoving = true;
                this.Text = "Pong";
            }
        }

        private void ResetGame()
        {
            Ball.SetLocation(new Point(this.Width / 2, Ball.Graphics.Top));
            Ball.Timer.Interval = 2000;
            Ball.Graphics.Hide();
            Reset ^= true;
        }
    }
}