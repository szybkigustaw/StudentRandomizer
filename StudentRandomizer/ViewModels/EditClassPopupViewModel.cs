using StudentRandomizer.Models.Collections;
using StudentRandomizer.Parsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentRandomizer.ViewModels
{
    public class EditClassPopupViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private ClassesCollectionModel _model;
        private ClassParser _parser;
        private string _className;
        private string _originalClassName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ClassName
        {
            get => _className;
            set => SetProperty(ref _className, value);
        }

        public string OriginalClassName
        {
            get => _originalClassName;
            set => SetProperty(ref _originalClassName, value);
        }

        public ICommand EditClassCommand { get; set; }
        public ICommand DeleteClassCommand { get; set; }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            OriginalClassName = query["classname"] as string ?? String.Empty;
            ClassName = OriginalClassName;
            OnPropertyChanged(nameof(OriginalClassName));
#if DEBUG
            Debug.WriteLine($"classname = {OriginalClassName}");
#endif
        }

        private void EditClass()
        {
            if (_model.Items.Where(item => item.ClassName == ClassName).Count() == 0)
            {
                var classobj = _model.Items.Where(item => item.ClassName == _originalClassName).First();
                _model.RemoveItem(classobj);
                classobj.ClassName = ClassName;
                _model.AddItem(classobj);
                _parser.ParseToFile(_model.Items.ToList());
            }
        }

        private async void DeleteClass()
        {
            var classobj = _model.Items.Where(item => item.ClassName == ClassName).First();
            _model.RemoveItem(classobj);
            _parser.ParseToFile(_model.Items.ToList());
            await Shell.Current.GoToAsync("///ClassesListPage"); 
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

        public EditClassPopupViewModel(ClassesCollectionModel model, ClassParser parser) 
        {
            this._model = model;
            this._parser = parser;
            EditClassCommand = new Command(EditClass);
            DeleteClassCommand = new Command(DeleteClass);
        }
    }
}
