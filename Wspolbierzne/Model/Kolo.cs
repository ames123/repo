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
            x = kulka.X;
            y = kulka.Y;
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

        private void Aktualizuj(object source, PropertyChangedEventArgs e)
        {
            KulkaLogika sKulka = (KulkaLogika)source;
            if (e.PropertyName == "X")
            {
                X = sKulka.X - 15;
            }

            if (e.PropertyName == "Y")
            {
                Y = sKulka.Y - 15;
            }

        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
