using prakt8_wpf.classes;
using System.Configuration;
using System.Data;
using System.Windows;

namespace prakt8_wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ThemeHelper.ApplySaved();
        }
    }
}
