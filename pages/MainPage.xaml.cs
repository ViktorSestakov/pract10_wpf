using prakt8_wpf.classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace prakt8_wpf.pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public Doctor DoctorInfo { get; set; }
        public ObservableCollection<Patient> Patients { get; set; } = new ObservableCollection<Patient>();
        public Patient? SelectedPatient { get; set; }

        public Doctor doctorLogin = new Doctor();
        private string Sover { get; set; }
        public MainPage(Doctor doctor)
        {
            InitializeComponent();
            DoctorInfo = doctor;
            LoadPatient();
        }

        public void LoadPatient()
        {
            Patients.Clear();
            var patientFiles = Directory.GetFiles(".", "P_*.json");
            foreach (var file in patientFiles)
            {
                string jsonString = File.ReadAllText(file);
                Patient patient = JsonSerializer.Deserialize<Patient>(jsonString);
                if (patient != null)
                {
                    Patients.Add(patient);
                }

                DateTime dt = DateTime.Parse(patient.Birthday);
                int year = dt.Year;

                if (year < 2008)
                {
                    patient.Sover = "Совершеннолетний";
                } else
                {
                    patient.Sover = "Не совершеннолетний";
                }
            }
            DataContext = this;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreatePatient createPage = new CreatePatient();
            NavigationService.Navigated += NavigationService_Navigated;

            NavigationService.Navigate(createPage);
        }

        private void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
            if (e.Content == this)
            {
                LoadPatient();
                NavigationService.Navigated -= NavigationService_Navigated;
            }
        }

        private void Reseption_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient != null)
            {
                NavigationService.Navigate(new Reception(DoctorInfo, SelectedPatient, Patients));
            }
            else
            {
                MessageBox.Show("Выберите пациента для приема!");
            }
        }

        private void Сhange_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient != null)
            {

                NavigationService.Navigate(new ChangingPatient(SelectedPatient, Patients));
            }
            else
            {
                MessageBox.Show("Выберите пациента для редактирования!");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var patientFile = $"P_{SelectedPatient.ID}.json";

            if (File.Exists(patientFile))
            {
                File.Delete(patientFile);
            }

            Patients.Clear();
            var patientFiles = Directory.GetFiles(".", "P_*.json");
            foreach (var file in patientFiles)
            {
                string jsonString = File.ReadAllText(file);
                Patient patient = JsonSerializer.Deserialize<Patient>(jsonString);
                if (patient != null)
                {
                    Patients.Add(patient);
                }
            }
            DataContext = this;
        }
    }
}
