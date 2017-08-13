using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace calculator
{
    class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            input = "";
        }
        private string input;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        public string Input
        {
            get => input;
            set
            {
                input = value;
                OnPropertyChanged("Input");
            }
        }
    }
}
