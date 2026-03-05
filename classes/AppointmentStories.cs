using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prakt8_wpf.classes
{
    public class AppointmentStories : INotifyPropertyChanged
    {
        public string _LastAppointment = "";
        public int _LastDoctor;
        public string _Diagnosis = "";
        public string _Recomendations = "";

        public string LastAppointment
        {
            get => _LastAppointment;
            set
            {
                if (_LastAppointment != value)
                {
                    _LastAppointment = value;
                    OnPropertyChanged();
                }
            }
        }

        public int LastDoctor
        {
            get => _LastDoctor;
            set
            {
                if (_LastDoctor != value)
                {
                    _LastDoctor = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Diagnosis
        {
            get => _Diagnosis;
            set
            {
                if (_Diagnosis != value)
                {
                    _Diagnosis = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Recomendations
        {
            get => _Recomendations;
            set
            {
                if (_Recomendations != value)
                {
                    _Recomendations = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}