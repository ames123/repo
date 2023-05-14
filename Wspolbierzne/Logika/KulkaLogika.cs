using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Logika
{
    public class KulkaLogika : INotifyPropertyChanged
    {
        private Kulka kulka;
        public event PropertyChangedEventHandler PropertyChanged;

        public KulkaLogika(Kulka kulka)
        {
            this.kulka = kulka;
            kulka.PropertyChanged += Aktualizuj;
        }
        public double X
        {
            get
            {
                return kulka.X;
            }
            set
            {
                kulka.X = value;
                OnPropertyChanged("X");
            }
        }
        public double Y
        {
            get
            {
                return kulka.Y;
            }
            set
            {
                kulka.Y = value;
                OnPropertyChanged("Y");
            }
        }
        private void Aktualizuj(object source, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "X")
            {
                OnPropertyChanged("X");
            }
            else if (e.PropertyName == "Y")
            {
                OnPropertyChanged("Y");
            }

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
