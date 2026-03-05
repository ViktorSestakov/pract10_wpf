using prakt8_wpf.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Логика взаимодействия для Reception.xaml
    /// </summary>
    public partial class Reception : Page, INotifyPropertyChanged
    {
        public Doctor doctor { get; set; }
        public Patient patient { get; set; }
        public ObservableCollection<Patient> allPatients { get; set; }
        public AppointmentStories newAppointmentStories { get; set; } = new AppointmentStories();
        public Patient? SelectedPatient { get; set; }
        public string DoctorIdDisplay => doctor?._ID.ToString() ?? string.Empty;

        public Reception(Doctor DoctorInfo, Patient SelectedPacient, ObservableCollection<Patient> patients)
        {
            InitializeComponent();

            patient = SelectedPacient;
            doctor = DoctorInfo;
            allPatients = patients;
            DataContext = this;

            if (SelectedPacient.Diagnosis == "")
            {
                MessageBox.Show("Это первый прием пациента!\nПоставьте сегодняшнюю дату для приема.");
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ChangingPatient(patient, allPatients));
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (diag.Text == "" || doc.Text == "" || rec.Text == "")
            {
                MessageBox.Show("Для сохранения все поля должны быть заполнены!");
                return;
            } else
            {
                patient.AppointmentStories.Add(new AppointmentStories
                {
                    LastAppointment = newAppointmentStories.LastAppointment,
                    LastDoctor = doctor._ID,
                    Diagnosis = newAppointmentStories.Diagnosis,
                    Recomendations = newAppointmentStories.Recomendations
                });

                string fileName = $"P_{patient.ID}.json";
                patient.Diagnosis = newAppointmentStories.Diagnosis;
                patient.LastDoctor = doctor._ID;
                string jsonString = JsonSerializer.Serialize(patient);
                File.WriteAllText(fileName, jsonString);
                var index = allPatients.IndexOf(patient);
                if (index >= 0)
                {
                    allPatients[index] = patient;
                }

                newAppointmentStories = new AppointmentStories
                {
                    LastAppointment = DateTime.Now.ToString("dd.MM.yyyy"),
                    LastDoctor = doctor._ID
                };
                OnPropertyChanged(nameof(newAppointmentStories));
                OnPropertyChanged(nameof(DoctorIdDisplay));

                MessageBox.Show("Прием успешно сохранен!");
            }  
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
