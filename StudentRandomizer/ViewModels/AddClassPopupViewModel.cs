using StudentRandomizer.Models.Collections;
using StudentRandomizer.Parsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentRandomizer.ViewModels
{
    public class AddClassPopupViewModel : INotifyPropertyChanged
    {
        private ClassesCollectionModel _model;
        private ClassParser _parser;
        private string _className;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ClassName
        {
            get => _className;
            set => SetProperty(ref _className, value);
        }

        public ICommand AddClassCommand { get; set; }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void AddClass()
        {
            if(_model.Items.Where(item => item.ClassName == ClassName).Count() == 0)
            {
                _model.AddItem(
                new Models.ClassModel(ClassName)
                );

                _parser.ParseToFile(_model.Items.ToList());

                ClassName = String.Empty;
            }
        }

        private bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = null)
        {
            if(Object.Equals(property, value))
            {
                return false;
            }

            property = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public AddClassPopupViewModel(ClassesCollectionModel model, ClassParser parser) 
        {
            this._model = model;
            this._parser = parser;
            AddClassCommand = new Command(AddClass);
        }
    }
}
