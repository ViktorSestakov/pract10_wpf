using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prakt8_wpf.classes
{
    public class Doctor : INotifyPropertyChanged
    {
        public bool login = false;
        public int _ID;
        public string _Name = "";
        public string _LastName = "";
        public string _MiddleName = "";
        public string _Specialisation = "";
        public string _Password = "";

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

        public string Specialisation
        {
            get => _Specialisation;
            set
            {
                if (_Specialisation != value)
                {
                    _Specialisation = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get => _Password;
            set
            {
                if (_Password != value)
                {
                    _Password = value;
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
