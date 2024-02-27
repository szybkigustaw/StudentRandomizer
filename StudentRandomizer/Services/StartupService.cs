using StudentRandomizer.Models.Collections;
using StudentRandomizer.Parsers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Services
{
    public class StartupService
    {
        private StudentsCollectionModel _studentsModel;
        private ClassesCollectionModel _classesModel;

        private StudentsParser _studentsParser;
        private ClassParser _classParser;

        private StudentsCountService _studentsCountService;
        private LuckyNumberService _luckyNumberService;

        public StartupService(
            StudentsCollectionModel studentsModel,
            ClassesCollectionModel classesModel,
            StudentsParser studentsParser,
            ClassParser classParser,
            StudentsCountService studentsCount,
            LuckyNumberService luckyNumber
            )
        {
            _studentsModel = studentsModel;
            _classesModel = classesModel;
            _studentsParser = studentsParser;
            _classParser = classParser;
            _studentsCountService = studentsCount;
            _luckyNumberService = luckyNumber;
        }

        public void LoadData()
        {
            var students = _studentsParser.ParseFromFile();
            var classes = _classParser.ParseFromFile();

            _studentsModel.AddItems(students);
            _classesModel.AddItems(classes);

#if DEBUG
            foreach( var student in _studentsModel.Items) 
            {
                Debug.WriteLine( student.Id );
            }
#endif

            _studentsCountService.UpdateMaxStudentsCount();
        }

        public void Init()
        {
            LoadData();
            _luckyNumberService.GenerateLuckyNumber();

#if DEBUG
            Debug.WriteLine($"Students' max count: {_studentsCountService.MaxStudentsCount}");
            Debug.WriteLine($"Lucky number: {_luckyNumberService.LuckyNumber}");
#endif
        }
    }
}
