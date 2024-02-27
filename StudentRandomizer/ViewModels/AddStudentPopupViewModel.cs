using StudentRandomizer.Models;
using StudentRandomizer.Models.Collections;
using StudentRandomizer.Parsers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentRandomizer.ViewModels
{
    public class AddStudentPopupViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private ClassModel studentClass;
        private bool isPresent = true;

        private ClassesCollectionModel _classesCollectionModel;
        private StudentsCollectionModel _studentsCollectionModel;
        private StudentsParser _parser;
        public ICommand AddStudentCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName { get => firstName; set => SetProperty(ref firstName, value); }
        public string LastName { get => lastName; set => SetProperty(ref lastName, value); }
        public ClassModel StudentClass { get => studentClass; set => SetProperty(ref studentClass, value); }
        public bool IsPresent { get => isPresent; set => SetProperty(ref isPresent, value); }

        public ObservableCollection<ClassModel> Classes { get => _classesCollectionModel.Items; }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        
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

        public void AddStudent()
        {
            var classesStudents = _studentsCollectionModel.Items.Where(student => student.ClassName == studentClass.ClassName).ToList();
            var newIndexNumber = classesStudents.Count() > 0 ? classesStudents.Max(student => student.IndexNumber) + 1 : 1;

            var formedStudent = new StudentModel(
                    newIndexNumber, firstName, lastName, isPresent, 0, studentClass.ClassName
                );

                _studentsCollectionModel.AddItem(formedStudent);

                _parser.ParseToFile(_studentsCollectionModel.Items.ToList());

                FirstName = String.Empty;
                LastName = String.Empty;
                IsPresent = true;
                StudentClass = null;
        }
        public AddStudentPopupViewModel(ClassesCollectionModel classesModel, StudentsCollectionModel studentsModel, StudentsParser parser)
        {
            this._classesCollectionModel = classesModel;
            this._studentsCollectionModel = studentsModel;
            this._parser = parser;
            this.AddStudentCommand = new Command(AddStudent);
        }
    }
}
