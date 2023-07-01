using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace semestralka
{
    public partial class MainWindow : Window
    {

        private List<BalloonLetter> balloons = new List<BalloonLetter>();
        private List<System.Windows.Controls.Image> cannons = new List<System.Windows.Controls.Image>();
        private Dictionary<System.Windows.Controls.Image, BalloonLetter> shots = new Dictionary<System.Windows.Controls.Image, BalloonLetter>();
        private List<System.Windows.Controls.Image> wrongShots = new List<System.Windows.Controls.Image>();
        private bool end = false;

        private double speed = 1.6;
        private int lives = 5;
        private int score = 0;
        private int time = 0;
        private int ballonsInterval = 100;

        private string difficulty;
        private string letters;
        private WindowMenu windowMenu;
        public MainWindow(string diff, string lett, WindowMenu wm)
        {
            InitializeComponent();

            cannons.Add(cannon1);
            cannons.Add(cannon2);
            cannons.Add(cannon3);
            cannons.Add(cannon4);
            cannons.Add(cannon5);

            difficulty = diff;
            letters = lett;
            windowMenu = wm;

            if (diff.Equals("Hard"))
            {
                speed = 1.3;
                ballonsInterval = 60;

            }
            else if (diff.Equals("Medium"))
            {
                speed = 1;
                ballonsInterval = 65;

            }
            else if (diff.Equals("Easy"))
            {
                speed = 0.8;
                ballonsInterval = 70;
            }

            textScore.Text = "Score: " + score;
            textLives.Text = "Lives: " + lives;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
            timer.Start();
            PreviewTextInput += MainWindow_PreviewKeyDown;
            SizeChanged += Window_SizeChanged;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            cannon1.Margin = new Thickness(this.ActualWidth * 0.03, this.ActualHeight * 0.55, 0, 0);
            cannon2.Margin = new Thickness(this.ActualWidth * 0.21, this.ActualHeight * 0.55, 0, 0);
            cannon3.Margin = new Thickness(this.ActualWidth * 0.35, this.ActualHeight * 0.55, 0, 0);
            cannon4.Margin = new Thickness(this.ActualWidth * 0.55, this.ActualHeight * 0.55, 0, 0);
            cannon5.Margin = new Thickness(this.ActualWidth * 0.75, this.ActualHeight * 0.55, 0, 0);
        }

        private void MainWindow_PreviewKeyDown(object sender, TextCompositionEventArgs e)
        {
            if (!end)
            {
                BalloonLetter? delete = null;
                foreach (BalloonLetter bl in balloons)
                {
                    if (e.Text.ToString() == bl.TextBlock.Text)
                    {
                        delete = bl;
                        break;
                    }
                }
                if (delete != null)
                {
                    var shot = new System.Windows.Controls.Image();
                    shot.Source = new BitmapImage(new Uri("images/shot.png", UriKind.Relative));
                    shot.Margin = new Thickness(delete.Position.Item1 + 50, ActualHeight, ActualHeight - 100, 0);
                    shot.HorizontalAlignment = HorizontalAlignment.Left; shot.VerticalAlignment = VerticalAlignment.Center;
                    shot.Height = 100;
                    shot.Width = 50;
                    shots.Add(shot, delete);
                    MainGrid.Children.Add(shot);

                }
                else
                {
                    score--;
                    textScore.Text = "Score: " + score;
                    var shot = new System.Windows.Controls.Image();
                    shot.Source = new BitmapImage(new Uri("images/shot.png", UriKind.Relative));
                    shot.Margin = new Thickness(ActualWidth / 2, ActualHeight, ActualHeight - 100, 0);
                    shot.HorizontalAlignment = HorizontalAlignment.Left; shot.VerticalAlignment = VerticalAlignment.Center;
                    shot.Height = 100;
                    shot.Width = 50;
                    wrongShots.Add(shot);
                    MainGrid.Children.Add(shot);
                }
            }

        }

        private void newBalloon()
        {
            BalloonLetter newBL = new BalloonLetter(letters);
            Random random = new Random();
            double[] pos = new double[5] { 0.05, 0.2, 0.35, 0.55, 0.75 };
            int randomNumber = random.Next(pos.Length);
            int dirrection = 0;
            if (cannons[randomNumber].Source.ToString().Equals("pack://application:,,,/semestralka;component/images/cannon1.png"))
            {
                cannons[randomNumber].Source = new BitmapImage(new Uri("images/cannon2.png", UriKind.Relative));
                dirrection = 80;
            }
            else
            {
                cannons[randomNumber].Source = new BitmapImage(new Uri("images/cannon1.png", UriKind.Relative));
            }
            newBL.Position = ((int)(pos[randomNumber] * this.ActualWidth) + dirrection, 250);
            var image = newBL.Image;
            MainGrid.Children.Add(image);
            var text = newBL.TextBlock;
            MainGrid.Children.Add(text);
            balloons.Add(newBL);
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (!end) { 
                if (time % ballonsInterval == 0)
                {
                    newBalloon();
                }

                BalloonLetter? delete = null;

                foreach (BalloonLetter bl in balloons)
                {
                    bl.Up(speed);
                    if (bl.Position.Item2 < -100)
                    {

                        lives--;
                        textLives.Text = "Lives: " + lives;
                        delete = bl;
                        break;
                    }
                }
                if (delete != null)
                {
                    delete.Hide();
                    balloons.Remove(delete);
                }

                System.Windows.Controls.Image? shotDelete = null; ;

                foreach (var s in shots.Keys)
                {
                    s.Margin = new Thickness(s.Margin.Left, s.Margin.Top - 30, s.Margin.Top - 100, 0);
                    if (s.Margin.Top <= shots[s].Position.Item2 - 250)
                    {
                        shotDelete = s;
                        s.Visibility = Visibility.Collapsed;
                        shots[s].Hide();
                        balloons.Remove(shots[s]);
                        score++;
                        textScore.Text = "Score: " + score;
                    }
                }
                if (shotDelete != null)
                {
                    shots.Remove(shotDelete);
                }

                shotDelete = null;
                foreach (var s in wrongShots)
                {
                    s.Margin = new Thickness(s.Margin.Left, s.Margin.Top - 30, s.Margin.Top - 100, 0);
                    if (s.Margin.Top < 0)
                    {
                        shotDelete = s;
                    }
                }
                if (shotDelete != null)
                {
                    shots.Remove(shotDelete);
                }


                if (lives == 0)
                {
                    end = true;
                    foreach (BalloonLetter bl in balloons)
                    {
                        bl.Hide();
                    }
                    balloons.Clear();
                    System.Windows.Controls.Image image = new System.Windows.Controls.Image();
                    image.Source = new BitmapImage(new Uri("images/gameover.png", UriKind.Relative));
                    image.Width = 700;
                    image.Height = 400;

                    foreach (System.Windows.Controls.Image m in cannons)
                    {
                        m.Visibility = Visibility.Collapsed;
                    }

                    MainGrid.Children.Add(image);
                    menu.Visibility = Visibility.Visible;
                    again.Visibility = Visibility.Visible;
                }
                time++; 
            }
           
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            windowMenu.addScore(score, difficulty);
            windowMenu.Show();
            this.Close();
        }

        private void Again_Click(object sender, RoutedEventArgs e)
        {
            windowMenu.addScore(score, difficulty);
            MainWindow mw = new MainWindow(difficulty, letters, windowMenu);
            mw.Left = 50;
            mw.Top = 50;
            mw.Show();
            this.Close();
        }

    }
}
