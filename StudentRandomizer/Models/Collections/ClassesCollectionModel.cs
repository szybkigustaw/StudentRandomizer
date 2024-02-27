using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Models.Collections
{
    public class ClassesCollectionModel : BaseCollectionModel<ClassModel>
    {
        private ObservableCollection<ClassModel> _items = new ObservableCollection<ClassModel>();

        public override ObservableCollection<ClassModel> Items { get { return _items; } }

        public override ClassModel GetItem(Guid id)
        {
            return Items.First(x => x.Id == id);
        }

        public ClassModel GetItem(string className)
        {
            return Items.First(x => x.ClassName == className);
        }
    }
}
