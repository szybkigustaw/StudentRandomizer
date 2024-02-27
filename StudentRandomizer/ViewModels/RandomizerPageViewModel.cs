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
    public class RandomizerPageViewModel : INotifyPropertyChanged
    {
        private ClassesCollectionModel _classesModel;
        private ObservableCollection<ClassModel> _classesList;
        private ClassModel selectedClass;
        public event PropertyChangedEventHandler PropertyChanged;

        public ClassModel SelectedClass
        {
            get => selectedClass;
            set => SetProperty(ref selectedClass, value);
        }

        public ObservableCollection<ClassModel> ClassesList
        {
            get => _classesList;
            set => SetProperty(ref _classesList, value);
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

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public async void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if(selectedIndex != -1)
            {
                SelectedClass = ClassesList[selectedIndex];
                var navigationParameter = new Dictionary<string, object>
                {
                    {"ClassId", SelectedClass.Id}
                };

                await Shell.Current.GoToAsync("///RollStudentPage", navigationParameter);
            }
        }

        public RandomizerPageViewModel(ClassesCollectionModel classesModel)
        {
            _classesModel = classesModel;
            _classesList = _classesModel.Items;
        }
    }
}
