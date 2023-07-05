using System.Reflection.Metadata.Ecma335;
using Timer = System.Windows.Forms.Timer;

namespace Pong
{
    class Ball
    {
        private const int BottomBoundary = 550;

        private int XSpeed = 5;
        private int YSpeed = 5;

        private Random Rand = new Random();

        public PictureBox Graphics;
        public Timer Timer;

        public Boolean IsMoving = false;

        public Ball(PictureBox BallGraphics, Timer BallTimer)
        {
            Graphics = BallGraphics;
            Timer = BallTimer;
        }

        public void DoMovement()
        {
            Graphics.Left -= XSpeed;
            Graphics.Top -= YSpeed;

            if (Graphics.Top <= 0 || Graphics.Top >= BottomBoundary)
            {
                YSpeed = -YSpeed;
            }
        }

        public bool IntersectsWithPaddle(PictureBox Paddle)
        {
            return Graphics.Bounds.IntersectsWith(Paddle.Bounds);
        }

        public void CollideWith(PictureBox Paddle)
        { // todo: ball should bounce off the top/bottom edges of the paddle
            if (Graphics.Location.Y >= Paddle.Top - Graphics.Height && Graphics.Location.Y <= Paddle.Top + Graphics.Height) // near-top segment of paddle
            {
                YSpeed = -Rand.Next(4, 6);
            }
            else if (Graphics.Location.Y > Paddle.Top + Graphics.Height && Graphics.Location.Y <= Paddle.Top + 2 * Graphics.Height) // upper-middle segment of paddle
            {
                YSpeed = -Rand.Next(2, 3);
            }
            else if (Graphics.Location.Y > Paddle.Top + 2 * Graphics.Height && Graphics.Location.Y <= Paddle.Top + 3 * Graphics.Height) // middle segment of paddle
            {
                YSpeed = 0;
            }
            else if (Graphics.Location.Y > Paddle.Top + 3 * Graphics.Height && Graphics.Location.Y <= Paddle.Top + 4 * Graphics.Height) // lower-middle segment of paddle
            {
                YSpeed = Rand.Next(2, 3);
            }
            else if (Graphics.Location.Y > Paddle.Top + 3 * Graphics.Height && Graphics.Location.Y <= Paddle.Bottom + Graphics.Height) // near-bottom of paddle
            {
                YSpeed = Rand.Next(4, 6);
            }
            XSpeed = -XSpeed;
        }

        public void SetLocation(Point Point)
        {
            Graphics.Location = Point;
        }
    }
}
