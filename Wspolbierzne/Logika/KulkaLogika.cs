using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logika
{
    public class KulkaLogika : INotifyPropertyChanged
    {
        
        private Kulka kulka;

        public event PropertyChangedEventHandler PropertyChanged;

        public KulkaLogika(Kulka kulka)
        {
            this.kulka = kulka;
            kulka.PropertyChanged += Update;
        }
        private void Update(object source, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "XP")
            {
                OnPropertyChanged("X");
            }
            else if (e.PropertyName == "Y")
            {
                OnPropertyChanged("Y");
            }

        }
        public int X
        {
            get { return kulka.X; }
            set
            {
                kulka.X = value;
                OnPropertyChanged("X");
            }
        }
        public int Y
        {
            get { return kulka.Y; }
            set
            {
                kulka.Y = value;
                OnPropertyChanged("Y");
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
