namespace Snake_Game
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.backgroundTimer = new System.Windows.Forms.Timer(this.components);
            this.startingScreen = new System.Windows.Forms.PictureBox();
            this.gameOverScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameOverScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.Tan;
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(746, 631);
            this.picCanvas.TabIndex = 2;
            this.picCanvas.TabStop = false;
            this.picCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.UpdatePictureBoxGraphic);
            // 
            // scoreLabel
            // 
            this.scoreLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(72, 651);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(668, 32);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "Score: 0";
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.Location = new System.Drawing.Point(462, 651);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(704, 32);
            this.highScoreLabel.TabIndex = 3;
            this.highScoreLabel.Text = "High Score:";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 120;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // backgroundTimer
            // 
            this.backgroundTimer.Interval = 90;
            this.backgroundTimer.Tick += new System.EventHandler(this.backgroundTimer_Tick);
            // 
            // startingScreen
            // 
            this.startingScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("startingScreen.BackgroundImage")));
            this.startingScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startingScreen.Location = new System.Drawing.Point(-10, 0);
            this.startingScreen.Name = "startingScreen";
            this.startingScreen.Size = new System.Drawing.Size(796, 758);
            this.startingScreen.TabIndex = 4;
            this.startingScreen.TabStop = false;
            // 
            // gameOverScreen
            // 
            this.gameOverScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gameOverScreen.BackgroundImage")));
            this.gameOverScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gameOverScreen.Location = new System.Drawing.Point(0, 0);
            this.gameOverScreen.Name = "gameOverScreen";
            this.gameOverScreen.Size = new System.Drawing.Size(774, 642);
            this.gameOverScreen.TabIndex = 5;
            this.gameOverScreen.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 702);
            this.Controls.Add(this.gameOverScreen);
            this.Controls.Add(this.startingScreen);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.picCanvas);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "The Snake Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.startingScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gameOverScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label highScoreLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Timer backgroundTimer;
        private System.Windows.Forms.PictureBox startingScreen;
        private System.Windows.Forms.PictureBox gameOverScreen;
    }
}

