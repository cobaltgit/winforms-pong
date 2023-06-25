namespace Pong
{
    partial class PongForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            BallPic = new PictureBox();
            BallTimer = new System.Windows.Forms.Timer(components);
            PlayerOnePaddlePic = new PictureBox();
            PlayerOneScoreLabel = new Label();
            PlayerTwoScoreLabel = new Label();
            PlayerTwoPaddlePic = new PictureBox();
            Divider = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)BallPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerOnePaddlePic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PlayerTwoPaddlePic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Divider).BeginInit();
            SuspendLayout();
            // 
            // BallPic
            // 
            BallPic.BackColor = SystemColors.Control;
            BallPic.Location = new Point(130, 0);
            BallPic.Name = "BallPic";
            BallPic.Size = new Size(10, 10);
            BallPic.TabIndex = 0;
            BallPic.TabStop = false;
            // 
            // BallTimer
            // 
            BallTimer.Enabled = true;
            BallTimer.Interval = 5;
            BallTimer.Tick += BallTimer_Tick;
            // 
            // PlayerOnePaddlePic
            // 
            PlayerOnePaddlePic.BackColor = SystemColors.Control;
            PlayerOnePaddlePic.Location = new Point(35, 210);
            PlayerOnePaddlePic.Name = "PlayerOnePaddlePic";
            PlayerOnePaddlePic.Size = new Size(10, 100);
            PlayerOnePaddlePic.TabIndex = 1;
            PlayerOnePaddlePic.TabStop = false;
            // 
            // PlayerOneScoreLabel
            // 
            PlayerOneScoreLabel.AutoSize = true;
            PlayerOneScoreLabel.Font = new Font("Lucida Sans Unicode", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            PlayerOneScoreLabel.ForeColor = SystemColors.HighlightText;
            PlayerOneScoreLabel.Location = new Point(130, 30);
            PlayerOneScoreLabel.Name = "PlayerOneScoreLabel";
            PlayerOneScoreLabel.Size = new Size(44, 45);
            PlayerOneScoreLabel.TabIndex = 2;
            PlayerOneScoreLabel.Text = "0";
            // 
            // PlayerTwoScoreLabel
            // 
            PlayerTwoScoreLabel.AutoSize = true;
            PlayerTwoScoreLabel.Font = new Font("Lucida Sans Unicode", 27.75F, FontStyle.Bold, GraphicsUnit.Point);
            PlayerTwoScoreLabel.ForeColor = SystemColors.HighlightText;
            PlayerTwoScoreLabel.Location = new Point(600, 30);
            PlayerTwoScoreLabel.Name = "PlayerTwoScoreLabel";
            PlayerTwoScoreLabel.Size = new Size(44, 45);
            PlayerTwoScoreLabel.TabIndex = 3;
            PlayerTwoScoreLabel.Text = "0";
            // 
            // PlayerTwoPaddlePic
            // 
            PlayerTwoPaddlePic.BackColor = SystemColors.Control;
            PlayerTwoPaddlePic.Location = new Point(730, 210);
            PlayerTwoPaddlePic.Name = "PlayerTwoPaddlePic";
            PlayerTwoPaddlePic.Size = new Size(10, 100);
            PlayerTwoPaddlePic.TabIndex = 4;
            PlayerTwoPaddlePic.TabStop = false;
            // 
            // Divider
            // 
            Divider.BackColor = SystemColors.Menu;
            Divider.Location = new Point(400, 0);
            Divider.Name = "Divider";
            Divider.Size = new Size(1, 600);
            Divider.TabIndex = 5;
            Divider.TabStop = false;
            // 
            // PongForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowText;
            ClientSize = new Size(784, 561);
            Controls.Add(Divider);
            Controls.Add(PlayerTwoPaddlePic);
            Controls.Add(PlayerTwoScoreLabel);
            Controls.Add(PlayerOneScoreLabel);
            Controls.Add(PlayerOnePaddlePic);
            Controls.Add(BallPic);
            Name = "PongForm";
            Text = "Pong";
            Activated += PongForm_Activated;
            Deactivate += PongForm_Deactivate;
            Load += PongForm_Load;
            KeyDown += PongForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)BallPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerOnePaddlePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)PlayerTwoPaddlePic).EndInit();
            ((System.ComponentModel.ISupportInitialize)Divider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox BallPic;
        private System.Windows.Forms.Timer BallTimer;
        private PictureBox PlayerOnePaddlePic;
        private Label PlayerOneScoreLabel;
        private Label PlayerTwoScoreLabel;
        private PictureBox PlayerTwoPaddlePic;
        private PictureBox Divider;
    }
}