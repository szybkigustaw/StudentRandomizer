using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Models
{
    public class StudentModel : BaseModel
    {
        private readonly Guid _id;
        private string _firstName;
        private string _lastName;
        private Guid? _classId;
        private bool _isPresent;
        private bool _hasBeenSelected;


        public override Guid Id { get => _id; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public Guid? ClassId { get => _classId; set => _classId = value; }
        public bool IsPresent { get => _isPresent; set => _isPresent = value; }
        public bool HasBeenSelected { get => _hasBeenSelected; set => _hasBeenSelected = value; }

        public StudentModel() : base()
        {
            _firstName = "Jan";
            _lastName = "Kowalski";
            IsPresent = true;
            HasBeenSelected = false;
        }

        public StudentModel(Guid id, string firstName, string lastName, bool isPresent, bool hasBeenSelected, Guid? classId) : base(id)
        {
            _firstName = firstName;
            _lastName = lastName;
            _classId = classId;
            _isPresent = isPresent;
            _hasBeenSelected = hasBeenSelected;
        }
        public StudentModel(string firstName, string lastName, bool isPresent, bool hasBeenSelected, Guid? classId) : base()
        {
            _firstName = firstName;
            _lastName = lastName;
            _classId = classId;
            _isPresent = isPresent;
            _hasBeenSelected = hasBeenSelected;
        }
    }
}
