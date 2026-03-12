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
using System.Runtime.CompilerServices;

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
            int prav = 0;
            
            if (name.Text == "")
            {
                name.BorderBrush = Brushes.Red;
                name_er.Visibility = Visibility.Visible;
                name_er.Text = "Поле не может быть пустым!";
                return;
            }
            else if (lastname.Text == "")
            {
                lastname.BorderBrush = Brushes.Red;
                name_er1.Visibility = Visibility.Visible;
                name_er1.Text = "Поле не может быть пустым!";
                return;
            }
            else if (midname.Text == "")
            {
                midname.BorderBrush = Brushes.Red;
                name_er2.Visibility = Visibility.Visible;
                name_er2.Text = "Поле не может быть пустым!";
                return;
            }
            else if (number.Text == "")
            {
                number.BorderBrush = Brushes.Red;
                name_er3.Visibility = Visibility.Visible;
                name_er3.Text = "Поле не может быть пустым!";
                return;
            }
            else if (bd.Text == "")
            {
                bd.BorderBrush = Brushes.Red;
                name_er4.Visibility = Visibility.Visible;
                name_er4.Text = "Поле не может быть пустым!";
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
            } else
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
            } else
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
            } else
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
