using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace semestralka
{
    /// <summary>
    /// Interaction logic for WindowMenu.xaml
    /// </summary>
    public partial class WindowMenu : Window
    {
        private string difficulty = "Hard";
        private string letters = "A, Á, B, C, Č, D, Ď, E, É, F, G, H, I, Í, J, K, L, Ĺ, Ľ, M, N, Ň, O, Ó, P, Q, R, Ŕ, S, Š, T, Ť, U, Ú, V, W, X, Y, Ý, Z, Ž, a, á, ä, b, c, č, d, ď, e, é, f, g, h, i, í, j, k, l, ĺ, ľ, m, n, ň, o, ó, ô, p, q, r, ŕ, s, š, t, ť, u, ú, v, w, x, y, ý, z, ž";
        private List<string> scores = new List<string>();

        public WindowMenu()
        {
            InitializeComponent();
            SizeChanged += Window_SizeChanged;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Left = 50;
            this.Top = 50;
            diffBorder.Margin = new Thickness(this.ActualWidth * 0.35, this.ActualHeight * 0.5, this.ActualWidth *0.4, this.ActualHeight * 0.3);
            diffBorder.Height = 40;
            diffBorder.Width = 150;
            wood.Margin = new Thickness(this.ActualWidth * 0.38, this.ActualHeight * 0.55, this.ActualWidth * 0.4, 0);
            wood.Height = ActualHeight / 3;
            wood.Width = wood.Height * 0.85;
            wood2.Margin = new Thickness(this.ActualWidth * 0.15, this.ActualHeight * 0.55, this.ActualWidth * 0.4, 0);
            wood2.Height = ActualHeight / 3;
            wood2.Width = wood2.Height * 0.85;
            buttonHard.Margin = new Thickness(this.ActualWidth * 0.44, this.ActualHeight * 0.6, 0, 0);
            buttonMedium.Margin = new Thickness(this.ActualWidth * 0.44, this.ActualHeight * 0.71, 0, 0);
            buttonEasy.Margin = new Thickness(this.ActualWidth * 0.44, this.ActualHeight * 0.82, 0, 0);
            playClick.Margin = new Thickness(this.ActualWidth * 0.65, this.ActualHeight * 0.65, this.ActualWidth * 0.1, 0);
            bestScores.Margin = new Thickness(this.ActualWidth * 0.65, this.ActualHeight * 0.45, this.ActualWidth * 0.1, 0);
            arrow.Margin = new Thickness(buttonHard.Margin.Left - 60, this.ActualHeight * 0.6, 0, 0);
            allLetters.Margin = new Thickness(this.ActualWidth * 0.15, this.ActualHeight * 0.6, this.ActualWidth * 0.65, 0);
            allLetters.Width = wood2.Width;
            uppercase.Margin = new Thickness(this.ActualWidth * 0.15, this.ActualHeight * 0.67, this.ActualWidth * 0.65, 0);
            uppercase.Width = wood2.Width;
            lowercase.Margin = new Thickness(this.ActualWidth * 0.15, this.ActualHeight * 0.74, this.ActualWidth * 0.65, 0);
            lowercase.Width = wood2.Width;
            withoutDiacritics.Margin = new Thickness(this.ActualWidth * 0.15, this.ActualHeight * 0.82, this.ActualWidth * 0.65, 0);
            withoutDiacritics.Width = wood2.Width;
        }


        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            arrow.Margin = new Thickness(buttonHard.Margin.Left - 60, this.ActualHeight * 0.6, 0, 0);
            difficulty = "Hard";
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            arrow.Margin = new Thickness(buttonHard.Margin.Left - 60, this.ActualHeight * 0.71, 0, 0);
            difficulty = "Medium";
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            arrow.Margin = new Thickness(buttonHard.Margin.Left - 60, this.ActualHeight * 0.82, 0, 0);
            difficulty = "Easy";
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(difficulty, letters, this);
            mw.Left = 50;
            mw.Top = 50;
            mw.Show();
            this.Hide();
        }

        private void All_Click(object sender, RoutedEventArgs e)
        {
            letters = "A, Á, B, C, Č, D, Ď, E, É, F, G, H, I, Í, J, K, L, Ĺ, Ľ, M, N, Ň, O, Ó, P, Q, R, Ŕ, S, Š, T, Ť, U, Ú, V, W, X, Y, Ý, Z, Ž, a, á, ä, b, c, č, d, ď, e, é, f, g, h, i, í, j, k, l, ĺ, ľ, m, n, ň, o, ó, ô, p, q, r, ŕ, s, š, t, ť, u, ú, v, w, x, y, ý, z, ž";
            allLetters.Background = new SolidColorBrush(Colors.RosyBrown);
            uppercase.Background = new SolidColorBrush(Colors.SandyBrown);
            lowercase.Background = new SolidColorBrush(Colors.SandyBrown);
            withoutDiacritics.Background = new SolidColorBrush(Colors.SandyBrown);
        }

        private void Upper_Click(object sender, RoutedEventArgs e)
        {
            letters = "A, Á, B, C, Č, D, Ď, E, É, F, G, H, I, Í, J, K, L, Ĺ, Ľ, M, N, Ň, O, Ó, P, Q, R, Ŕ, S, Š, T, Ť, U, Ú, V, W, X, Y, Ý, Z, Ž";
            allLetters.Background = new SolidColorBrush(Colors.SandyBrown);
            uppercase.Background = new SolidColorBrush(Colors.RosyBrown);
            lowercase.Background = new SolidColorBrush(Colors.SandyBrown);
            withoutDiacritics.Background = new SolidColorBrush(Colors.SandyBrown);

        }

        private void Lower_Click(object sender, RoutedEventArgs e)
        {
            letters = "a, á, ä, b, c, č, d, ď, e, é, f, g, h, i, í, j, k, l, ĺ, ľ, m, n, ň, o, ó, ô, p, q, r, ŕ, s, š, t, ť, u, ú, v, w, x, y, ý, z, ž";
            allLetters.Background = new SolidColorBrush(Colors.SandyBrown);
            uppercase.Background = new SolidColorBrush(Colors.SandyBrown);
            lowercase.Background = new SolidColorBrush(Colors.RosyBrown);
            withoutDiacritics.Background = new SolidColorBrush(Colors.SandyBrown);
        }

        private void Without_Click(object sender, RoutedEventArgs e)
        {
            letters = "A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z";
            allLetters.Background = new SolidColorBrush(Colors.SandyBrown);
            uppercase.Background = new SolidColorBrush(Colors.SandyBrown);
            lowercase.Background = new SolidColorBrush(Colors.SandyBrown);
            withoutDiacritics.Background = new SolidColorBrush(Colors.RosyBrown);
        }

        private void Scores_Click(object sender, RoutedEventArgs e)
        {
            sort();

            string s = "";
            foreach(string sc in scores)
            {
                s += sc + "\n";
            }

            MessageBox.Show(s);
        }

        private void sort()
        {
            int swaps = 0;
            do
            {
                swaps = 0;
                for (int i = 0; i < scores.Count() -1; i++)
                {
                    if (Int32.Parse(scores[i + 1].Split(", ")[0]) > Int32.Parse(scores[i].Split(", ")[0]))
                    {
                        var temp = scores[i];
                        scores[i] = scores[i + 1];
                        scores[i + 1] = temp;
                        swaps++;
                    }
                }
            } while (swaps > 0);
        }

        public void addScore(int score, string diff)
        {
            scores.Add(score + ", difficulty: "  + diff);
        }
    }


}
