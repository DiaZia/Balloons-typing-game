using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;

namespace semestralka
{

    internal class BalloonLetter
    {
        private System.Windows.Controls.Image image = new System.Windows.Controls.Image();
        private TextBlock textBlock = new TextBlock();
        private double positionX = 0;
        private double positionY = 0;
        private string[] letters;


        public BalloonLetter(string lett) 
        {
            letters = lett.Split(", ");

            Random random = new Random();
            int randomNumber = random.Next(1, 5);

            image.Source = new BitmapImage(new Uri("images/b" + randomNumber + ".png", UriKind.Relative));
            image.Width = 200;
            image.Height = 200;
            image.HorizontalAlignment = HorizontalAlignment.Left;
            image.VerticalAlignment = VerticalAlignment.Top;
            image.Margin = new Thickness(positionX, positionY, 0, 0);

            Random random2 = new Random();
            int randomNumber2 = random2.Next(0, letters.Count());
            textBlock.Text = letters[randomNumber2];
            textBlock.FontFamily = new FontFamily("Cambria");
            textBlock.FontSize = 40;
            textBlock.Width = 40;
            textBlock.Height = 55;
            textBlock.HorizontalAlignment = HorizontalAlignment.Left;
            textBlock.VerticalAlignment = VerticalAlignment.Top;
            textBlock.Margin = new Thickness(positionX + 65, positionY +35, 0, 0);
        }


        public System.Windows.Controls.Image Image
        {
            get { return image; }
        }

        public TextBlock TextBlock 
        { 
            get { return textBlock; }
        }

        public (double, double) Position
        {
            get
            {
                return (positionX, positionY);
            }
            set
            {
                positionX = value.Item1;
                positionY = value.Item2;
                image.Margin = new Thickness(positionX, positionY, 0, 0);
                textBlock.Margin = new Thickness(positionX+ 65, positionY +35, 0, 0);
            }
        }

        public void Up(double speed)
        {
            positionY -= speed;
            image.Margin = new Thickness(positionX, positionY, 0, 0);
            textBlock.Margin = new Thickness(positionX + 65, positionY +35, 0, 0);
        }

        public void Hide()
        {
            image.Visibility = Visibility.Collapsed;
            textBlock.Visibility = Visibility.Collapsed;
        }
    }
}
