using StudentRandomizer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Parsers
{
    public class ClassParser : BaseParser<ClassModel>
    {
        private string _fileName = "classes.txt";
        public override string FileName { get => _fileName; set => _fileName = value; }

        public override bool ParseToFile(List<ClassModel> models)
        {
            List<string> models_strings = new List<string>();
            foreach (var model in models)
            {
                models_strings.Add(model.ToString());
            }
            File.WriteAllLines(Path.Combine(_baseFilePath, _fileName), models_strings);
            return true;
        }

        public override List<ClassModel> ParseFromFile()
        {
            List<ClassModel> models = new List<ClassModel>();
            string[] models_strings = File.ReadAllLines(Path.Combine(_baseFilePath, _fileName));
            foreach (string model_string in models_strings)
            {
                string[] model_parts = model_string.Split(',');
                ClassModel model = new ClassModel(
                    model_parts[0]
                    );
                models.Add(model);
            }

            return models;
        }

        public override bool Export(List<ClassModel> models, string path)
        {
            throw new NotImplementedException();
        }

        public override List<ClassModel> Import(string path)
        {
            throw new NotImplementedException();
        }
    }
}
