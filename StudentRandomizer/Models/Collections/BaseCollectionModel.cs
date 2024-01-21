using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Models.Collections
{
    public abstract class BaseCollectionModel<BaseModel>
    {
        public abstract ObservableCollection<BaseModel> Items { get; }

        public virtual void AddItem(BaseModel item)
        {
            Items.Add(item);
        }

        public virtual void RemoveItem(BaseModel item)
        {
            Items.Remove(item);
        }

        public abstract BaseModel GetItem(Guid id);

        public virtual void AddItems(IEnumerable<BaseModel> items)
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
