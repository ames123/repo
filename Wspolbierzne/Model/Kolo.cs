using Logika;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Model
{
    public class Kolo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double x;
        private double y;

        public Kolo(KulkaLogika kulka)
        {
            this.x = kulka.X;
            this.y = kulka.Y;
            kulka.PropertyChanged += Aktualizuj;
        }

        public double X
        {
            get { return x; }
            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }

        private void Aktualizuj(object source, PropertyChangedEventArgs key)
        {
            KulkaLogika sKulka = (KulkaLogika)source;
            if(key.PropertyName == "X")
            {
                this.X = sKulka.X - 15;
            }

            if(key.PropertyName == "Y")
            {
                this.Y = sKulka.Y - 15;
            }

        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
