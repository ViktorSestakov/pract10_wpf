using prakt8_wpf.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ChangingPatient.xaml
    /// </summary>
    public partial class ChangingPatient : Page
    {
        Patient PacientChanging;
        private ObservableCollection<Patient> _patients;

        public ChangingPatient(Patient pacientChanging, ObservableCollection<Patient> patients)
        {
            InitializeComponent();
            PacientChanging = pacientChanging;
            _patients = patients;
            DataContext = PacientChanging;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (name.Text == "" || lastname.Text == "" || midname.Text == "" || number.Text == "" || bd.Text == "")
            {
                MessageBox.Show("Все поля должны быть заполнены!");
                return;
            } else
            {
                string jsonString = JsonSerializer.Serialize(PacientChanging);
                File.WriteAllText($"P_{PacientChanging.ID}.json", jsonString);

                var existingPatient = _patients.FirstOrDefault(p => p.ID == PacientChanging.ID);
                if (existingPatient != null)
                {
                    existingPatient.Name = PacientChanging.Name;
                    existingPatient.LastName = PacientChanging.LastName;
                    existingPatient.MiddleName = PacientChanging.MiddleName;
                    existingPatient.Number = PacientChanging.Number;
                    existingPatient.Birthday = PacientChanging.Birthday;
                    existingPatient.LastAppointment = PacientChanging.LastAppointment;
                    existingPatient.LastDoctor = PacientChanging.LastDoctor;
                    existingPatient.Diagnosis = PacientChanging.Diagnosis;
                    existingPatient.Recomendations = PacientChanging.Recomendations;
                    existingPatient.AppointmentStories = PacientChanging.AppointmentStories;

                    int index = _patients.IndexOf(existingPatient);
                    _patients[index] = existingPatient;
                }

                MessageBox.Show($"Данные успешно изменены!");
                NavigationService.GoBack();
            } 
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
