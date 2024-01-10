using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Models.Collections
{
    public class StudentsCollectionModel : BaseCollectionModel<StudentModel>
    {
        private ObservableCollection<StudentModel> _items = new ObservableCollection<StudentModel>();

        public override ObservableCollection<StudentModel> Items { get { return _items; } }

        public override StudentModel GetItem(Guid id)
        {
            return Items.First(item => item.Id == id);
        }
    }
}
