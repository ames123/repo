using System.Collections.Generic;
using System.Collections.ObjectModel;
using Logika;

namespace Model
{
    public abstract class AbstractModelApi
    {
        public static AbstractModelApi CreateApi(AbstractLogicApi abstractLogicApi = null)
        {
            return new ModelApi();
        }

        public abstract ObservableCollection<Kolo> GetAllKola();

        public abstract void Enable(int ilosc);

        public abstract void Disable();

        public abstract bool IsEnabled();

        public sealed class ModelApi : AbstractModelApi
        {
            private AbstractLogicApi logicApi = AbstractLogicApi.CreateApi(null);

            private ObservableCollection<Kolo> kola = new ObservableCollection<Kolo>();

            public ObservableCollection<Kolo> Kola
            {
                get { return kola; }
                set { kola = value; }
            }

            internal ModelApi(AbstractLogicApi abstractLogicApi = null)
            {
                if (abstractLogicApi == null)
                {
                    logicApi = AbstractLogicApi.CreateApi(null);
                }
                else
                {
                    logicApi = abstractLogicApi;
                }
            }

            public override void Enable(int ilosc)
            {
                logicApi.Enable(763, 515, ilosc);
            }

            public override ObservableCollection<Kolo> GetAllKola()
            {
                List<KulkaLogika> kola = logicApi.GetKulki();
                Kola.Clear();
                foreach (KulkaLogika kolo in kola)
                {
                    Kola.Add(new Kolo(kolo));
                }
                return Kola;
            }

            public override void Disable()
            {
                logicApi.Disable();
            }

            public override bool IsEnabled()
            {
                return logicApi.IsEnabled();
            }
        }
    }
}
