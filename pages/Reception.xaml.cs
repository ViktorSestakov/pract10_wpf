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

            if (SelectedPacient.LastAppointment == null || SelectedPacient.LastAppointment == "")
            {
                last.Content = $"Это первый прием пациента!";
            } else 
            {
                DateTime dt = DateTime.Parse(SelectedPacient.LastAppointment);
                DateTime dt1 = DateTime.Now;
                int day = dt.Day;
                int month = dt.Month;

                int dayto = dt1.Day;
                int daymoth = dt1.Month;

                int proshlo = 0;

                if (daymoth == month && dayto == day)
                {
                    proshlo = 0;
                }

                if (daymoth == month)
                {
                    proshlo = dayto - daymoth;
                }
                else
                {
                    proshlo = (dayto - daymoth) + 30;
                }

                last.Content = $"Последняя встреча была {proshlo} дней";

            }

            DateTime dtp = DateTime.Parse(SelectedPacient.Birthday);
            int year = dtp.Year;

            if (year < 2008)
            {
                SelectedPacient.Sover = "Совершеннолетний";
            }
            else
            {
                SelectedPacient.Sover = "Не совершеннолетний";
            }

            int pollet = 2026 - year;
            bd.Content = $"Полных лет: {pollet} | {SelectedPacient.Sover}";
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
            if (diag.Text == "")
            {
                diag.BorderBrush = Brushes.Red;
                name_er1.Visibility = Visibility.Visible;
                return;
            } else if (doc.Text == "")
            {
                doc.BorderBrush = Brushes.Red;
                name_er2.Visibility = Visibility.Visible;
                return;
            } else if (rec.Text == "")
            {
                rec.BorderBrush = Brushes.Red;
                name_er3.Visibility = Visibility.Visible;
                return;
            } else if (date.Text == "")
            {
                date.BorderBrush = Brushes.Red;
                name_er.Visibility = Visibility.Visible;
                return;
            }
            else
            {
                diag.BorderBrush = Brushes.Black;
                doc.BorderBrush = Brushes.Black;
                rec.BorderBrush = Brushes.Black;
                date.BorderBrush = Brushes.Black;

                name_er.Visibility = Visibility.Hidden;
                name_er1.Visibility = Visibility.Hidden;
                name_er2.Visibility = Visibility.Hidden;
                name_er3.Visibility = Visibility.Hidden;

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
                patient.LastAppointment = date.ToString();

                last.Content = $"Последняя встреча была {date.ToString()}";

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
