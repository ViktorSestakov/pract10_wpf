using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
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
using prakt8_wpf.classes;

namespace prakt8_wpf.pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Doctor doctor = new Doctor();
        public Login()
        {
            InitializeComponent();

            DataContext = doctor;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Должны быть заполнены все поля!");
                return;
            } else
            {
                string[] mas = Directory.GetFiles("Doctor", $"D_*.json");
                foreach (var i in mas)
                {
                    string json = File.ReadAllText(i);
                    Doctor? doc = JsonSerializer.Deserialize<Doctor>(json);

                    if (pass.Text == doc.Password)
                    {
                        MessageBox.Show($"Добро пожаловать, {doc.Name} {doc.MiddleName}!");
                        NavigationService.Navigate(new MainPage(doc));
                        break;
                    }
                }
            }    
        }

        private void Redistr_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
