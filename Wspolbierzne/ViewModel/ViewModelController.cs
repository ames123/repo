using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ViewModel
{
    public class ViewModelController : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<Kolo> kulkiLista;
        private AbstractModelApi modelApi;
        private int ileKulek = 0;
        public ICommand SignalEnable
        {
            get;
            set;
        }
        public ICommand SignalDisable
        {
            get;
            set;
        }
        public ViewModelController() : this(null) { }
        public ViewModelController(AbstractModelApi ModelApi = null)
        {
            SignalEnable = new Sygnal(Enable);
            SignalDisable = new Sygnal(Disable);
            if (ModelApi == null)
            {
                modelApi = AbstractModelApi.CreateApi();
            }
            else
            {
                modelApi = ModelApi;
            }
        }

        public string IleKulek
        {
            get
            {
                return Convert.ToString(ileKulek);
            }
            set
            {
                ileKulek = Convert.ToInt32(value);
                OnPropertyChanged("IleKulek");
            }
        }
        public ObservableCollection<Kolo> KulkiLista
        {
            get { return kulkiLista; }
            set
            {
                kulkiLista = value;
                OnPropertyChanged("KulkiLista");
            }
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool isEnabled = true;
        private bool isDisabled = false;
        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                isEnabled = value;
                isDisabled = !isEnabled;
                OnPropertyChanged("IsEnabled");
                OnPropertyChanged("IsDisabled");
            }
        }
        private void Enable()
        {
            modelApi.Enable(ileKulek);
            KulkiLista = modelApi.GetAllKola();
        }
        public bool IsDisabled
        {
            get
            {
                return isDisabled;
            }
        }

        private void Disable()
        {
            modelApi.Disable();
        }

    }
}
