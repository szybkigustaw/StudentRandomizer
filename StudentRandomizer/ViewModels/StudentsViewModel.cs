using StudentRandomizer.Models;
using StudentRandomizer.Models.Collections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.ViewModels
{
    public class StudentsViewModel : INotifyPropertyChanged
    {
        private StudentsCollectionModel _studentsCollectionModel;
        private ClassesCollectionModel _classesCollectionModel;

        private ObservableCollection<StudentModel> _models;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<StudentModel> Models
        {
            get => _models;
            set => SetProperty(ref _models, value, nameof(Models));
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        private bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            if(Object.Equals(property, value))
            {
                return false;
            }

            property = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public StudentsViewModel(StudentsCollectionModel studentsCollectionModel, ClassesCollectionModel classesCollectionModel)
        {
            this._studentsCollectionModel = studentsCollectionModel;
            this._classesCollectionModel = classesCollectionModel;
            this._models = _studentsCollectionModel.Items;
        }
    }
}
