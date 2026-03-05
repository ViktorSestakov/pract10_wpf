using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using prakt8_wpf.pages;
using prakt8_wpf;
using prakt8_wpf.classes;

namespace prakt8_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Login());
        }

        private void nas_click(object sender, RoutedEventArgs e)
        {
            tema.Visibility = Visibility.Visible;
        }

        private void tema_click(object sender, RoutedEventArgs e)
        {
            svet.Visibility = Visibility.Visible;
            temn.Visibility = Visibility.Visible;
        }

        private void svet_click(object sender, RoutedEventArgs e)
        {
            tema.Visibility = Visibility.Hidden;
            svet.Visibility = Visibility.Hidden;
            temn.Visibility = Visibility.Hidden;

            ThemeHelper.ToggleSvet();
        }

        private void temn_click(object sender, RoutedEventArgs e)
        {
            tema.Visibility = Visibility.Hidden;
            svet.Visibility = Visibility.Hidden;
            temn.Visibility = Visibility.Hidden;
            
            ThemeHelper.ToggleTemn();
        }
    }
}