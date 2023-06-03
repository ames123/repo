using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Dane
{
    public class Kulka : INotifyPropertyChanged
    {
        private double x;
        private double y;
        private double weight;
        private double[] speed = new double[2];

        public Kulka(double x, double y,double weight)
        {
            this.x = x;
            this.y = y;
            this.weight = weight;
            Random random = new Random();
            double x2 = 0;
            do
            {
                x2 = random.NextDouble() * 0.99;
            } while (x2 == 0);
            double y2 = Math.Sqrt(4 - (x2 * x2));
            y2 = (random.Next(-1, 1) < 0) ? y2 : -y2;
            this.speed[0] = x2;
            this.speed[1] = y2;
        }

        public double Weight
        {
            get { return weight; }
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

        public double x2
        {
            get { return speed[0]; }
            set { speed[0] = value; }
        }

        public double y2
        {
            get { return speed[1]; }
            set { speed[1] = value; }
        }


        public async void move()
        {
            X += x2;
            Y += y2;
            OnPropertyChanged("Position");
        }
        public event PropertyChangedEventHandler PropertyChanged;
        /*public double GenerujX()
        {

            return x2;
        }
        public double GenerujY()
        {
            return y2;
        }*/
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

