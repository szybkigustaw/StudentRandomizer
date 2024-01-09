using Android.Companion.Virtual;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Models
{
    public abstract class BaseModel
    {
        private readonly Guid _id;
        public virtual Guid Id { get => _id; }

        public BaseModel()
        {
            _id = Guid.NewGuid();
        }

        public BaseModel(Guid id)
        {
            _id = id;
        }
    }
}
