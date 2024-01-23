using StudentRandomizer.Models.Collections;
using StudentRandomizer.Parsers;
using System;
using System.Collections.Generic;
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

        public StartupService(
            StudentsCollectionModel studentsModel, 
            ClassesCollectionModel classesModel,
            StudentsParser studentsParser,
            ClassParser classParser
            )
        {
            _studentsModel = studentsModel;
            _classesModel = classesModel;
            _studentsParser = studentsParser;
            _classParser = classParser;
        }

        public void LoadData()
        {
            var students = _studentsParser.ParseFromFile();
            var classes = _classParser.ParseFromFile();

            _studentsModel.AddItems(students);
            _classesModel.AddItems(classes);
        }
    }
}
