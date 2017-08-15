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
        private Model model;

        public ViewModel()
        {
            model = new Model();
            Input = "";
            Info = "";
        }

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
            model.PushInput(text);
            Input = model.ExpressionString;
            if (model.Error != null)
            {
                Info = "Error: " + model.Error;
            }
            else
            {
                Info = "";
            }
            
        }
        public void RemoveInput()
        {
            model.PopInput();
            Input = model.ExpressionString;
            if (model.Error != null)
            {
                Info = "Error: " + model.Error;
            }
            else
            {
                Info = "";
            }
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
