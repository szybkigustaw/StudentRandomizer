using StudentRandomizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Parsers
{
    public class StudentsParser : BaseParser<StudentModel>
    {
        private string _fileName = "students.txt";
        public override string FileName { get => _fileName; set => _fileName = value; }

        public override bool ParseToFile(List<StudentModel> models)
        {
            List<string> models_strings = new List<string>();
            foreach (var model in models)
            {
                models_strings.Add(model.ToString());
            }
            File.WriteAllLines(Path.Combine(_baseFilePath, _fileName), models_strings);
            return true;
        }

        public override List<StudentModel> ParseFromFile()
        {
            List<StudentModel> models = new List<StudentModel>();
            string[] models_strings = File.ReadAllLines(Path.Combine(_baseFilePath, _fileName));
            foreach (string model_string in models_strings)
            {
                string[] model_parts = model_string.Split(',');
                StudentModel model = new StudentModel(
                    Convert.ToInt32(model_parts[0]),
                    model_parts[1],
                    model_parts[2],
                    bool.Parse(model_parts[4]),
                    Convert.ToInt32(model_parts[5]),
                    model_parts[3]
                    );
                models.Add(model);
            }

            return models;
        }

        public override bool Export(List<StudentModel> models, string path)
        {
            throw new NotImplementedException();
        }

        public override List<StudentModel> Import(string path)
        {
            throw new NotImplementedException();
        }
    }
}
