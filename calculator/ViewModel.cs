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
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

        private string input;
        public string Input
        {
            get => input;
            private set
            {
                input = value;
                OnPropertyChanged("Input");
            }
        }
        public void AddInput(string text)
        {
            Input += text;
        }
        public void RemoveInput()
        {
            string text = Input;
            Input = text.Substring(0, text.Length - 1);
        }

        private string info;
        public string Info
        {
            get => info;
            set
            {
                info = value;
                OnPropertyChanged("Info");
            }
        }
    }
}
