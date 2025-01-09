using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DrawAnimatedRainbowFlower();
        }

        private void DrawAnimatedRainbowFlower()
        {
            double centerX = 400, centerY = 400; // Canvas center
            double h = 0; // Hue for colors

            // Loop to create 16 groups of petals
            for (int i = 0; i < 16; i++)
            {
                // Inner loop for 18 petals in each group
                for (int j = 0; j < 18; j++)
                {
                    double radius = 150 - j * 6; // Radius decreases for inner petals
                    double angle = i * 22.5;    // Angle offset for each petal group

                    // HSV to RGB color
                    Color color = FromHSV(h * 360, 1, 1);
                    h += 0.005;

                    // Create the petal (circle segment)
                    var petal = new Ellipse
                    {
                        Width = radius * 2,
                        Height = radius * 2,
                        Stroke = new SolidColorBrush(color),
                        StrokeThickness = 1,
                        Fill = Brushes.Transparent
                    };

                    // Position the petal on the canvas
                    Canvas.SetLeft(petal, centerX - radius);
                    Canvas.SetTop(petal, centerY - radius);

                    // Rotate the petal to its position
                    petal.RenderTransform = new RotateTransform(angle, centerX, centerY);

                    // Add the petal to the canvas
                    MainCanvas.Children.Add(petal);

                    // Animate the drawing of the petal
                    AnimatePetal(petal, j);
                }
            }
        }

        private void AnimatePetal(Ellipse petal, int delayMultiplier)
        {
            // Opacity animation for smooth drawing effect
            var opacityAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromMilliseconds(200),
                BeginTime = TimeSpan.FromMilliseconds(delayMultiplier * 50), // Delayed start
            };

            // Apply the animation to the petal
            petal.BeginAnimation(OpacityProperty, opacityAnimation);
        }

        private Color FromHSV(double hue, double saturation, double value)
        {
            int hi = (int)(hue / 60) % 6;
            double f = hue / 60 - hi;
            double p = value * (1 - saturation);
            double q = value * (1 - f * saturation);
            double t = value * (1 - (1 - f) * saturation);

            double r = 0, g = 0, b = 0;

            switch (hi)
            {
                case 0: r = value; g = t; b = p; break;
                case 1: r = q; g = value; b = p; break;
                case 2: r = p; g = value; b = t; break;
                case 3: r = p; g = q; b = value; break;
                case 4: r = t; g = p; b = value; break;
                case 5: r = value; g = p; b = q; break;
            }

            return Color.FromRgb((byte)(r * 255), (byte)(g * 255), (byte)(b * 255));
        }
    }
}
