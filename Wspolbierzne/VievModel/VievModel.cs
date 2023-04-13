using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Model;

namespace VievModel
{
    public class VievModel : INotifyPropertyChanged
    {
        private int IleKulek = 1;
        // Model model;
        //private ObservableCollection<Kulka> KulkiList;
        /*public ObservableCollection<Kulka> KulkiList
        {
            get { return KulkiList; }
            set
            {
                if (value.Equals(this.KulkiList)) return;
                KulkiList = value;
                OnPropertyChanged("kulkiList");
            }
        }*/

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        public ICommand Enable
        {
            get;
            set;
        }
        public ICommand Disable
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

    
