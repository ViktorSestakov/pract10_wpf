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
    /// Логика взаимодействия для CreatePatient.xaml
    /// </summary>
    public partial class CreatePatient : Page
    {
        public Patient patient = new Patient();

        public CreatePatient()
        {
            Random rnd = new Random();
            patient.ID = rnd.Next(1000000, 10000000);
            DataContext = patient;
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == "" || lastname.Text == "" || midname.Text == "" || number.Text == "" || bd.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            } else
            {
                string jsonString = JsonSerializer.Serialize(patient);
                File.WriteAllText($"P_{patient.ID}.json", jsonString);

                MessageBox.Show($"Регистрация успешна!");
                NavigationService.GoBack();
            } 
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
