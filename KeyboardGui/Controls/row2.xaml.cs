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

namespace KeyboardGui.Controls
{
    /// <summary>
    /// Interaction logic for row2.xaml
    /// </summary>
    public partial class row2 : UserControl
    {
        public row2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(@"C:\Learnings\WPF\KeyboardGui\Sounds\s1.mp3", UriKind.Relative));
            mediaPlayer.Play();
        }
    }
}
