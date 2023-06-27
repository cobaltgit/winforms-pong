namespace Pong
{
    class Player
    {
        public int Score;
        public PictureBox Paddle;

        public Keys Up;
        public Keys Down;

        public Player(PictureBox Paddle, Keys Up, Keys Down)
        {
            this.Score = 0;
            this.Paddle = Paddle;
            this.Up = Up;
            this.Down = Down;
        }

        public void AddScore(Label ScoreLabel)
        {
            this.Score++;
            this.DrawScore(ScoreLabel);
        }

        public void DrawScore(Label ScoreLabel)
        {
            ScoreLabel.Text = this.Score.ToString();
        }


        public void Move(Keys KeyCode, int Speed)
        {
            if (KeyCode == this.Up)
            {
                if (this.Paddle.Top > Speed)
                {
                    this.Paddle.Top -= Speed;
                }
            }
            else if (KeyCode == this.Down)
            {
                if (this.Paddle.Top < 450) 
                {
                    this.Paddle.Top += Speed;
                }
            }
        }
    }
}
