using CommunityToolkit.Maui.Core.Extensions;
using StudentRandomizer.Models;
using StudentRandomizer.Models.Collections;
using StudentRandomizer.Parsers;
using StudentRandomizer.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentRandomizer.ViewModels
{
    public class RollStudentsPageViewModel : INotifyPropertyChanged, IQueryAttributable
    {
        private string _rolledText;
        private ClassModel _rolledClass;
        private ObservableCollection<StudentModel> _studentsList;
        private StudentsCollectionModel _studentsModel;
        private ClassesCollectionModel _classesModel;
        private LuckyNumberService _luckyNumber;
        private StudentsParser _studentsParser;
        public event PropertyChangedEventHandler PropertyChanged;

        public string RolledText
        {
            get => _rolledText;
            set => SetProperty(ref _rolledText, value);
        }
        public ClassModel RolledClass
        {
            get => _rolledClass;
            set => SetProperty(ref _rolledClass, value);
        }

        public ObservableCollection<StudentModel> StudentsList
        {
            get => _studentsList;
            set => SetProperty(ref _studentsList, value);
        }

        public int LuckyNumber
        {
            get => _luckyNumber.LuckyNumber;
        }

        public ICommand RollStudentCommand { get; set; }

        public void OnPropertyChanged([CallerMemberName] string propertyName=null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Guid classid = (Guid)query["ClassId"];
            RolledClass = _classesModel.GetItem(classid);
            StudentsList = _studentsModel.Items.Where(item => item.ClassName == RolledClass.ClassName).ToObservableCollection();
            StudentsList.CollectionChanged += StudentsList_CollectionChanged;
        }

        private void StudentsList_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            List<StudentModel> modifiedStudents = StudentsList.ToList();
            foreach(var student in modifiedStudents)
            {
                var modifiedStudent = _studentsModel.GetItem(student.Id);
                _studentsModel.RemoveItem(modifiedStudent);
                _studentsModel.AddItem(student);
            }
            _studentsParser.ParseToFile(_studentsModel.Items.ToList());
        }

        private bool SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName=null)
        {
            if(Object.Equals(property, value))
            {
                return false;
            }

            property = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void RollStudent()
        {
            int studentsCount = StudentsList.Count();
            int rolledIndex = 0;
            int tries = 0;
            while(tries <= 10)
            {
                tries++;
#if DEBUG
                Debug.WriteLine("New rolling round initialized!");
#endif
                if(StudentsList.Where(student => student.RollsSinceSelection == 2).Count() == 0 || tries == 10)
                {
                    RolledText = "No student qualified for rolling. Try rolling a few more times.";
                    break;
                }

                rolledIndex = Random.Shared.Next(0, studentsCount) + 1;
                
                if(rolledIndex == LuckyNumber)
                {
                    continue;
                }

                var rolledStudent = StudentsList.First(student => student.IndexNumber == rolledIndex);
                if(!rolledStudent.IsPresent || rolledStudent.RollsSinceSelection < 2)
                {
                    continue;
                }

                RolledText = $"{rolledStudent.FirstName} {rolledStudent.LastName}";
                break;
            }

            var copiedList = new List<StudentModel>();
            foreach(var student in StudentsList)
            {
                if(student.IndexNumber == rolledIndex)
                {
                    student.RollsSinceSelection = 0;
                    copiedList.Add(student);
                }
                else if(student.RollsSinceSelection < 2 && student.IndexNumber != LuckyNumber)
                {
                    student.RollsSinceSelection++;
                    copiedList.Add(student);
                }
                else
                {
                    copiedList.Add(student);
                }
            }

            StudentsList.Clear();
            foreach(var student in copiedList)
            {
                StudentsList.Add(student);
            }
        }

        public RollStudentsPageViewModel(StudentsCollectionModel studentsModel, ClassesCollectionModel classesModel, LuckyNumberService luckyNumberService, StudentsParser parser)
        {
            _studentsModel = studentsModel;
            _classesModel = classesModel;
            _luckyNumber = luckyNumberService;
            _studentsParser = parser;

            RollStudentCommand = new Command(RollStudent);
        }
    }
}
