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
    public class EditStudentPopupViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private string originalFirstName;
        private string originalLastName;
        private string? originalClassName;
        private Guid originalId;
        private bool originalIsPresent;
        private int originalRollsSinceSelection;

        private string firstName;
        private string lastName;
        private ClassModel studentClass;
        private bool isPresent = true;

        private ClassesCollectionModel _classesCollectionModel;
        private StudentsCollectionModel _studentsCollectionModel;
        private StudentsParser _parser;
        public ICommand EditStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public string OriginalFirstName {  get => originalFirstName; set => SetProperty(ref originalFirstName, value); }
        public string OriginalLastName { get => originalLastName; set => SetProperty(ref originalLastName, value); }
        public string? OriginalClassName { get => originalClassName; set => SetProperty(ref originalClassName, value); }
        public Guid OriginalId { get => originalId; set => SetProperty(ref originalId, value); }
        public bool OriginalIsPresent { get => originalIsPresent; set => SetProperty(ref originalIsPresent, value); }
        public int OriginalRollsSinceSelection { get => originalRollsSinceSelection; set => SetProperty(ref originalRollsSinceSelection, value); }

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

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            //OriginalFirstName = query["FirstName"] as string;
            //OriginalLastName = query["LastName"] as string;
            //OriginalClassId = query["ClassId"] as Guid;
            OriginalId = (Guid) query["StudentId"];
            //OriginalIsPresent = query["IsPresent"] as Guid;

            var student = _studentsCollectionModel.GetItem(OriginalId);
            OriginalFirstName = student.FirstName;
            OriginalLastName = student.LastName;
            OriginalIsPresent = student.IsPresent;
            OriginalClassName = student.ClassName;
            OriginalRollsSinceSelection = student.RollsSinceSelection;

            if(OriginalClassName != null)
            {
                try
                {
                    studentClass = _classesCollectionModel.GetItem(OriginalClassName);
                }
                catch
                {
                    studentClass = null;
                }
            }
            FirstName = OriginalFirstName;
            LastName = OriginalLastName;
            IsPresent = OriginalIsPresent;
        }

        public async void EditStudent()
        {
            var originalStudent = _studentsCollectionModel.GetItem(OriginalId);
            var formedStudent = new StudentModel(
                    Guid.NewGuid(), firstName, lastName, isPresent, originalRollsSinceSelection, studentClass.ClassName
                );

            if(
                _studentsCollectionModel.Items.Where(item => item.FirstName == formedStudent.FirstName &&
                                                                item.LastName == formedStudent.LastName &&
                                                                item.ClassName == formedStudent.ClassName)
                    .Count() == 0
                )
            {
                _studentsCollectionModel.RemoveItem(originalStudent);
                _studentsCollectionModel.AddItem(formedStudent);

                _parser.ParseToFile(_studentsCollectionModel.Items.ToList());
                await Shell.Current.GoToAsync("///StudentsListPage");
            }
        }

        public async void DeleteStudent()
        {
            var originalStudent = _studentsCollectionModel.GetItem(OriginalId);
            _studentsCollectionModel.RemoveItem(originalStudent);
            _parser.ParseToFile(_studentsCollectionModel.Items.ToList());

            await Shell.Current.GoToAsync("///StudentsListPage");
        }

        public EditStudentPopupViewModel(ClassesCollectionModel classesModel, StudentsCollectionModel studentsModel, StudentsParser parser)
        {
            this._classesCollectionModel = classesModel;
            this._studentsCollectionModel = studentsModel;
            this._parser = parser;
            this.EditStudentCommand = new Command(EditStudent);
            this.DeleteStudentCommand = new Command(DeleteStudent);
        }
    }
}
