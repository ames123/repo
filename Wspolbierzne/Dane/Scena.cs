using System;
using System.Collections.Generic;

namespace Dane
{
    public class Scena
    {
        private int width;
        private int height;
        private bool enabled = false;
        public int Width
        {
            get
            {
                return width;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
        }
        public bool Enabled
            {
                get 
            { 
                return enabled;
            }
                set 
            { 
                enabled = value; 
            }
            }


        private readonly List<Kulka> kulka = new List<Kulka>();
            public List<Kulka> Kulka
            {
                get 
            { 
                return kulka;
            }
            }

       public Scena(int width, int height, int ileKulek)
        {
            this.width = width;
            this.height = height;
            GenerujListeKulek(ileKulek);
        }
        int prom = 15;
        public Kulka GenerujKulki()
        {
            Random random = new Random();
            int x , y;
            x = random.Next(prom, width - prom);
            y = random.Next(prom, height - prom);
            return new Kulka(x, y);
        }
        public void GenerujListeKulek(int ileKulek)
        {
            for (int i = 0; i < ileKulek; i++)
            {
                Kulka k = GenerujKulki();
                this.kulka.Add(k);
            }
        }
    }
}
