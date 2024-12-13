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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SliderGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private int currentProfile = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int index = (int)slider.Value;
            switch (index)
            {
                case 0:
                    grid0.Visibility = Visibility.Visible;
                    grid1.Visibility = Visibility.Hidden;
                    grid2.Visibility = Visibility.Hidden;
                    break;
                case 1:
                    grid0.Visibility = Visibility.Hidden;
                    grid1.Visibility = Visibility.Visible;
                    grid2.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    grid0.Visibility = Visibility.Hidden;
                    grid1.Visibility = Visibility.Hidden;
                    grid2.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            currentProfile--;
            if(currentProfile < 0)
            {
                currentProfile = 2;
            }
            slider.Value = currentProfile;
            slider_ValueChanged(slider, null);
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            currentProfile++;
            if (currentProfile > 2)
            {
                currentProfile = 0;
            }
            slider.Value = currentProfile;
            slider_ValueChanged(slider, null);
        }
    }
}
