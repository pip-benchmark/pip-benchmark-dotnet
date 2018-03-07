using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace PipBenchmark.StandardBenchmarks.WPF.Controls
{
    public class DataItem : INotifyPropertyChanged
    {
        private string _name;
        private int _age;
        private double _randomNumber;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public double RandomNumber
        {
            get { return _randomNumber; }
            set
            {
                _randomNumber = value;
                OnPropertyChanged("RandomNumber");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion
    }
}
