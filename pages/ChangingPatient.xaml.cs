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
using System.Diagnostics.Eventing.Reader;

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
            int prav = 0;

            if (name.Text == "")
            {
                name.BorderBrush = Brushes.Red;
                name_er.Visibility = Visibility.Visible;
                return;
            } else if (lastname.Text == "")
            {
                lastname.BorderBrush = Brushes.Red;
                name_er1.Visibility = Visibility.Visible;
                return;
            } else if (midname.Text == "")
            {
                midname.BorderBrush = Brushes.Red;
                name_er2.Visibility = Visibility.Visible;
                return;
            } else if (number.Text == "")
            {
                number.BorderBrush = Brushes.Red;
                name_er3.Visibility = Visibility.Visible;
                return;
            } else if (bd.Text == "")
            {
                bd.BorderBrush = Brushes.Red;
                name_er4.Visibility = Visibility.Visible;
                return;
            }

            /* ==1== */
            bool nepravvvod_name = false;

            for (int i = 0; i < name.Text.Length; i++)
            {
                if (char.IsDigit(name.Text[i]))
                {
                    nepravvvod_name = true;
                }
            }

            if (nepravvvod_name == true)
            {
                name.BorderBrush = Brushes.Red;
                name_er.Visibility = Visibility.Visible;
                name_er.Text = "Цифры не могут быть использованы в имени!";
            }
            else
            {
                prav++;
            }
            /* ==1== */

            /* ==2== */
            bool nepravvvod_lname = false;

            for (int i = 0; i < lastname.Text.Length; i++)
            {
                if (char.IsDigit(lastname.Text[i]))
                {
                    nepravvvod_lname = true;
                }
            }

            if (nepravvvod_lname == true)
            {
                lastname.BorderBrush = Brushes.Red;
                name_er1.Visibility = Visibility.Visible;
                name_er1.Text = "Цифры не могут быть использованы в фамилии!";
            }
            else
            {
                prav++;
            }
            /* ==2== */

            /* ==3== */
            bool nepravvvod_mname = false;

            for (int i = 0; i < midname.Text.Length; i++)
            {
                if (char.IsDigit(midname.Text[i]))
                {
                    nepravvvod_mname = true;
                }
            }

            if (nepravvvod_mname == true)
            {
                midname.BorderBrush = Brushes.Red;
                name_er2.Visibility = Visibility.Visible;
                name_er2.Text = "Цифры не могут быть использованы в отчестве!";
            }
            else
            {
                prav++;
            }
            /* ==3== */

            if (prav >= 3)
            {
                name.BorderBrush = Brushes.Black;
                lastname.BorderBrush = Brushes.Black;
                midname.BorderBrush = Brushes.Black;
                number.BorderBrush = Brushes.Black;
                bd.BorderBrush = Brushes.Black;

                name_er.Visibility = Visibility.Hidden;
                name_er1.Visibility = Visibility.Hidden;
                name_er2.Visibility = Visibility.Hidden;
                name_er3.Visibility = Visibility.Hidden;
                name_er4.Visibility = Visibility.Hidden;

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
