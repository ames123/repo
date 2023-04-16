using Dane;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Logika
{
    public abstract class AbstractLogicApi
    {
        public abstract List<KulkaLogika> GetKulki();
        public abstract void Disable();
        public abstract void Enable(int width, int height, int ileKulek);
         public static AbstractLogicApi CreateApi()
        {
            throw new NotImplementedException();
        }

        public abstract bool IsEnabled();
        public static AbstractLogicApi CreateApi(AbstractDataApi abstractDataApi)
        {
            return new LogikaApi(abstractDataApi);
        }

        internal sealed class LogikaApi : AbstractLogicApi
        {
            private AbstractDataApi DataApi;

            private List<KulkaLogika> kulki = new List<KulkaLogika>();

            bool enabled = false;

            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
            }
                        public override void Disable()
            {
                DataApi.Disable();
                kulki.Clear();
            }
            internal LogikaApi(AbstractDataApi abstractDataApi)
            {
                if (abstractDataApi == null)
                {
                    DataApi = AbstractDataApi.CreateApi();
                }
                else
                {
                    DataApi = abstractDataApi;
                }
            }

            public override bool IsEnabled()
            {
                return enabled;
            }


            public override List<KulkaLogika> GetKulki()
            {
                return kulki;
            }
 
            public override void Enable(int width, int height, int ileKulek)
            {
               
                DataApi.CreateScena(width, height, ileKulek);
                foreach (Kulka kulka in DataApi.GetKulki())
                {
                    kulki.Add(new KulkaLogika(kulka));
                    kulka.PropertyChanged += Aktualizuj;
                }
            }

            private void Aktualizuj(object sender, PropertyChangedEventArgs ev)
            {
                Kulka kulka = (Kulka)sender;
                if (ev.PropertyName == "Position")
                {
                    Sprawdz(kulka);
                }

            }

            private void Sprawdz(Kulka kulka)
            {
                if ((kulka.Y - 15) <= 0)
                {
                    kulka.x2 = kulka.GenerujX();
                    kulka.GenerujY(kulka.x2);
                    kulka.Y = 15;
                }
                if ((kulka.X - 15) <= 0)
                {
                    kulka.x2 = -kulka.x2;
                    kulka.GenerujY(kulka.x2);
                    kulka.X = 15;
                }
                if ((kulka.X + 15) >= DataApi.Scene.Width)
                {
                    kulka.x2 = -kulka.x2;
                    kulka.GenerujY(kulka.x2);
                    kulka.X = DataApi.Scene.Width - 15;
                }
                if ((kulka.Y + 15) >= DataApi.Scene.Height)
                {
                    kulka.x2=kulka.GenerujX();
                    kulka.GenerujY(kulka.x2);
                    kulka.Y = DataApi.Scene.Height - 15;
                }

            }

     
            
        }
    }
}
