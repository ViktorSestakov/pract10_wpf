using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prakt8_wpf.classes
{ 
    public class Patient : INotifyPropertyChanged
    {
        public int _ID;
        public string _Name = "";
        public string _LastName = "";
        public string _MiddleName = "";
        public long _Number = 0;
        public string _Birthday = "";
        public string _LastAppointment = "";
        public int _LastDoctor;
        public string _Diagnosis = "";
        public string _Recomendations = "";
        public string Sover { get; set; }

        public int ID
        {
            get => _ID;
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _Name;
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get => _LastName;
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string MiddleName
        {
            get => _MiddleName;
            set
            {
                if (_MiddleName != value)
                {
                    _MiddleName = value;
                    OnPropertyChanged();
                }
            }
        }

        public long Number
        {
            get => _Number;
            set
            {
                if (_Number != value)
                {
                    _Number = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Birthday
        {
            get => _Birthday;
            set
            {
                if (_Birthday != value)
                {
                    _Birthday = value;
                    OnPropertyChanged();
                }
            }
        }

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

        private ObservableCollection<AppointmentStories> _AppointmentStories = new ObservableCollection<AppointmentStories>();
        public ObservableCollection<AppointmentStories> AppointmentStories
        {
            get => _AppointmentStories;
            set
            {
                if (_AppointmentStories != value)
                {
                    _AppointmentStories = value;
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
