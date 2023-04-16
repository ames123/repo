using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Dane
{
    public class Kulka : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double x;
        private double y;
        private double[] speed = new double[2];

        public Kulka(double x, double y)
        {
            this.x = x;
            this.y = y;
            double x2 = GenerujX();
            GenerujY(x2);
        }
        public double GenerujX()
        {
            Random random = new Random();
            double x2;
            do
            {
                x2 = random.NextDouble()*2;
            } while (x2 == 0);
            return x2;
        }
        public void GenerujY(double x2)
        {
            Random random = new Random();
            double y2 = Math.Sqrt(4 - (x2 * x2));
            //warunek ? wartość_gdy_prawda : wartość_gdy_falsz
            y2 = (random.Next(-1, 1) < 0) ? y2 : -y2;
            speed[0] = x2;
            speed[1] = y2;
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
        public void move()
        {
            X += x2;
            Y += y2;
            OnPropertyChanged("Position");
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

