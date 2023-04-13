using System.ComponentModel;
using Logika;

namespace Model
{
    public class Kolo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int x;
        public int y;

        public Kolo()
        {
            this.x = Kulka.X;
        }
    }
}
