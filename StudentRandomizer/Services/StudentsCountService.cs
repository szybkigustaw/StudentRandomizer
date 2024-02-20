using StudentRandomizer.Models.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Services
{
    public class StudentsCountService : INotifyPropertyChanged
    {
        private StudentsCollectionModel _studentsModel;
        private ClassesCollectionModel _classesModel;
        private int _max_students_count;

        public int MaxStudentsCount { get => _max_students_count; set => SetProperty(ref _max_students_count, value); }
        public StudentsCountService(StudentsCollectionModel studentsModel, ClassesCollectionModel classesModel) 
        {
            this._studentsModel = studentsModel;
            this._classesModel = classesModel;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) 
            => this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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

        public void UpdateMaxStudentsCount()
        {
            IList<int> classesCounts = new List<int>();

            foreach (var item in _classesModel.Items)
            {
                classesCounts.Add(
                    _studentsModel.Items.Where(student => student.ClassId == item.Id).Count()
                    );
            }

            int max_count = classesCounts.Max();
            MaxStudentsCount = max_count;
        }
    }
}
