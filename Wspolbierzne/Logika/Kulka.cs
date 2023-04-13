using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Logika
{
        public class Kulka : INotifyPropertyChanged
        {
            private int x;
            private int y;

            public event PropertyChangedEventHandler PropertyChanged;

            public Kulka(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public int X 
            {
                get { return x; }
                set
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public int Y
            {
                get { return y; }
                set
                {
                    y = value;
                    OnPropertyChanged("Y");
                }
            }

        }
    }

