using prakt8_wpf.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
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
using System.IO;

namespace prakt8_wpf.pages
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Doctor doctor = new Doctor();
        public Registration()
        {
            InitializeComponent();

            DataContext = doctor;
        }

        private void Regestration_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            
            if (name.Text == "" || lastname.Text == "" || middlename.Text == "" || spec.Text == "" || pass.Text == "" || pass_rep.Text == "")
            {
                MessageBox.Show("Должны быть заполнены все поля!");
                return;
            } else if (pass.Text != pass_rep.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            } else
            {
                doctor._ID = rnd.Next(0, 10000);
                try
                {
                    string jsonString = JsonSerializer.Serialize(doctor);

                    File.WriteAllText($"Doctor\\D_{doctor._ID}.json", jsonString);

                    MessageBox.Show($"Регистрация успешна.\nID:{doctor._ID}");
                    NavigationService.GoBack();
                }
                catch { }
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
