using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dane
{
    public abstract class AbstractDataApi
    {
        public abstract void CreateScena(int width, int height, int ileKulek);


        public abstract List<Kulka> GetKulki();
        public abstract void Disable();

        public abstract Scena Scene { get; }
        public static AbstractDataApi CreateApi()
        {
            return new DataApi();
        }

        internal sealed class DataApi : AbstractDataApi
        {

            private bool enabled = false;
            private Scena scene;
            private readonly object locked = new object();
            private Logger logger;

            public bool Enabled
            {
                get { return enabled; }
                set { enabled = value; }
            }

            public override Scena Scene
            {
                get { return scene; }
            }

            public override void CreateScena(int width, int height, int ileKulek)
            {
                scene = new Scena(width, height, ileKulek);
                Enabled = true;
                List<Kulka> kulki = GetKulki();
                logger = new Logger(kulki);
                foreach (Kulka kulka in kulki)
                {
                    //tworzy wątki
                    Thread t = new Thread(() => {
                        while (Enabled)
                        {
                            //blokuje, aby wiele wątków nie mogło jednocześnie zmienić położenia kuli
                            lock (locked)
                            {
                                kulka.move();
                            }
                            Thread.Sleep(11);
                            //Task.Delay(20).GetAwaiter().GetResult();
                            //await Task.Delay(14);
                        }
                    });
                    t.Start();
                }
            }

            public override List<Kulka> GetKulki()
            {
                return Scene.Kulka;
            }

            public override void Disable()
            {
                Enabled = false;
                logger.stop();
            }
        }
    }
}

