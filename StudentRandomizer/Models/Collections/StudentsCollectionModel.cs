using CommunityToolkit.Maui.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Models.Collections
{
    public class StudentsCollectionModel : BaseCollectionModel<StudentModel>
    {
        private ObservableCollection<StudentModel> _items = new ObservableCollection<StudentModel>();

        public override ObservableCollection<StudentModel> Items { get { return _items; } set { _items = value; } }

        public override StudentModel GetItem(Guid id)
        {
            return Items.First(item => item.Id == id);
        }

        public override void RemoveItem(StudentModel item)
        {
            var deletedStudentIndexNumber = item.IndexNumber;
            base.RemoveItem(item);
        }

        private void SortStudents()
        {
            List<StudentModel> students = Items.OrderBy(student => student.IndexNumber).ToList();
            Items.Clear();
            foreach (var student in students)
            {
                Items.Add(student);
            }
        }

        public override void AddItem(StudentModel item)
        {
            base.AddItem(item);
            SortStudents();
        }

        public override void AddItems(IEnumerable<StudentModel> items)
        {
            base.AddItems(items);
            SortStudents();
        }

        public StudentsCollectionModel() : base()
        {
            Items.CollectionChanged += AdjustIndexes;
        }

        private void AdjustIndexes(object? sender, NotifyCollectionChangedEventArgs e)
        {
            var studentsList = Items.ToList();
            for (int i = 0; i < studentsList.Count(); i++) 
            {
                var student = studentsList[i];
                if(student.IndexNumber == i+1)
                {
                    continue;
                }

                student.IndexNumber--;
                studentsList[i] = student;
            }
            Items = studentsList.ToObservableCollection();
        }
    }
}
