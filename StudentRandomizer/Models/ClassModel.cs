using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ClassModel() : base() { 
            _id = Guid.NewGuid(); 
            _className = String.Empty;
#if DEBUG
            Debug.WriteLine($"Generated class' GUID: {_id}");
#endif
        }
        public ClassModel(Guid id, string className) : base(id) {
            _id = id; 
            _className = className; 
#if DEBUG
            Debug.WriteLine($"Generated class' GUID: {_id}");
#endif
        }
        public ClassModel(string className) : base() {
            _id = Guid.NewGuid();
            _className = className;
#if DEBUG
            Debug.WriteLine($"Generated class' GUID: {_id}");
#endif
        }

        public override string ToString()
        {
            return $"{_className}";
        }
    }
}
