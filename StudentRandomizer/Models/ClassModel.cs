using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Models
{
    public class ClassModel : BaseModel
    {
        private readonly Guid _id;
        private string _className;

        public override Guid Id { get { return _id; } }

        public string ClassName { get { return _className; } set => _className = value; }

        public ClassModel() : base() { _className = String.Empty; }
        public ClassModel(Guid id, string className) : base(id) { _className = className; }
        public ClassModel(string className) : base() { _className = className; }

        public override string ToString()
        {
            return $"{_id},{_className}";
        }
    }
}
