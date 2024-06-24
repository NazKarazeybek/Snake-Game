using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media; //for sound

namespace Snake_Game
{
    public partial class Form1 : Form
    {

        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();

        int maxWidth;
        int maxHeight;

        int snakeSpeed = 10;

        int score;
        int highScore;

        int screenNum = 0; // for title and ending screen 

        Random rand = new Random();

        bool goLeft, goRight, goUp, goDown, escapePressed, enterPressed; //controls

        SoundPlayer introMusic = new SoundPlayer(Properties.Resources.introMusic);
        SoundPlayer gameOverSound = new SoundPlayer(Properties.Resources.gameOver); 
        //added sound


        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeyIsDown); // Add event handler for key down
            this.KeyUp += new KeyEventHandler(KeyIsUp); // Add event handler for key up
            backgroundTimer.Tick += new EventHandler(backgroundTimer_Tick); // Timer event for background
            backgroundTimer.Enabled = true; 
            gameOverScreen.Visible = false; 
            new Settings(); // Initialize settings
            introMusic.Play(); //play intro music
        }

        private void StartGame(object sender, EventArgs e)
        {
            RestartGame();
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            //setting the directions
            if (goLeft)
            {
                Settings.directions = "left";
            }
            if (goRight)
            {
                Settings.directions = "right";
            }
            if (goDown)
            {
                Settings.directions = "down";
            }
            if (goUp)
            {
                Settings.directions = "up";
            }
            //end of directions

            for (int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    // Move snake head
                    switch (Settings.directions)
                    {
                        case "left":
                            Snake[i].X --;
                            break;
                        case "right":
                            Snake[i].X++;
                            break;
                        case "down":
                            Snake[i].Y++;
                            break;
                        case "up":
                            Snake[i].Y--;
                            break;
                    }

                    // Check if the snake hits the boundary and wrap around
                    if (Snake[i].X < 0)
                    {
                        Snake[i].X = maxWidth;
                    }
                    if (Snake[i].X > maxWidth)
                    {
                        Snake[i].X = 0;
                    }
                    if (Snake[i].Y < 0)
                    {
                        Snake[i].Y = maxHeight;
                    }
                    if (Snake[i].Y > maxHeight)
                    {
                        Snake[i].Y = 0;
                    }

                    // Check if the snake eats the food
                    if (Snake[i].X == food.X && Snake[i].Y == food.Y)
                    {
                        EatFood();
                    }

                    // Check if the snake hits itself
                    for (int j = 1; j < Snake.Count; j++)
                    {
                        if (Snake[i].X == Snake[j].X && Snake[i].Y == Snake[j].Y)
                        {
                            GameOver();
                            screenNum = 2;
                        }
                    }
                }
                else
                {
                    //move snake body
                    Snake[i].X = Snake[i - 1].X;
                    Snake[i].Y = Snake[i - 1].Y;
                }
            }
            picCanvas.Invalidate();
        }

        public void ScreenChange()
        {
            // Handle screen changes based on the current screen and key presses
            if (enterPressed == true && screenNum == 0)
            {
                screenNum = 1;
                startingScreen.Visible = false; 
                RestartGame();
                enterPressed = false; 
                introMusic.Stop();
                gameOverSound.Stop();
            }
            if (enterPressed == true && screenNum == 2)
            {
                screenNum = 1;
                gameOverScreen.Visible = false;
                RestartGame();
            }

            if (escapePressed == true)
            {
                Application.Exit();
            }
        }
        private void UpdatePictureBoxGraphic(object sender, PaintEventArgs e) //picCanvas
        {
            Graphics canvas = e.Graphics;
            Brush snakeColour;

            //draw snake
            for (int i = 0; i < Snake.Count; i++)
            {
                if (i == 0)
                {
                    snakeColour = Brushes.Black; // Head of the snake
                }
                else
                {
                    snakeColour = Brushes.DarkGreen; // Body of the snake
                }

                canvas.FillEllipse(snakeColour, new Rectangle
                    (
                    Snake[i].X * Settings.Width,
                    Snake[i].Y * Settings.Height,
                    Settings.Width, Settings.Height
                    ));
            }
            // Draw the food
            canvas.FillEllipse(Brushes.DarkRed, new Rectangle
            (
            food.X * Settings.Width,
            food.Y * Settings.Height,
            Settings.Width, Settings.Height
            ));
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            // Handle key up events
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Escape)
            {
                escapePressed = false;
            }
            if (e.KeyCode == Keys.Enter)
            {
                enterPressed = false;
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            // Handle key down events
            if (e.KeyCode == Keys.Left && Settings.directions != "right")
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right && Settings.directions != "left")
            {
                goRight = true;
            }
            if (e.KeyCode == Keys.Up && Settings.directions != "down")
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down && Settings.directions != "up")
            {
                goDown = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                escapePressed = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                enterPressed = true;
            }
        }

        private void backgroundTimer_Tick(object sender, EventArgs e)
        {
            ScreenChange(); 
            Refresh();
        }

        private void RestartGame()
        {
            // Initialize game settings
            maxWidth = picCanvas.Width / Settings.Width - 1;
            maxHeight = picCanvas.Height / Settings.Height - 1;

            Snake.Clear(); // Clear the snake list
            score = 0;
            scoreLabel.Text = "Score: " + score;

            Circle head = new Circle { X = 10, Y = 5 };
            Snake.Add(head); // adding the head part of the snake to the list

            // Create the body of the snake
            for (int i = 0; i < 1; i++)
            {
                Circle body = new Circle();
                Snake.Add(body);
            }

            // Generate food at a random location
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
            gameTimer.Start();
        }
        private void EatFood()
        {
            score += 1; // Increase score by 1
            scoreLabel.Text = "Score: " + score;

            // Add new body part to the snake
            Circle body = new Circle
            {
                X = Snake[Snake.Count - 1].X,
                Y = Snake[Snake.Count - 1].Y
            };

            Snake.Add(body);

            // Generate new food at a random location
            food = new Circle { X = rand.Next(2, maxWidth), Y = rand.Next(2, maxHeight) };
        }

        private void GameOver()
        {           
            gameTimer.Stop();

            if (score > highScore)
            {
                highScore = score;

                highScoreLabel.Text = "High Score: " + highScore;
                highScoreLabel.ForeColor = Color.Maroon;
                //highScoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            }
            gameOverScreen.Visible = true;
            gameOverSound.Play();
        }
    }
}
