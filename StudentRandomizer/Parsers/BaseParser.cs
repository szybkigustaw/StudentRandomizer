using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Parsers
{
    public abstract class BaseParser<BaseModel>
    {
        protected string _baseFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public abstract string FileName { get; set; }

        public abstract bool ParseToFile(List<BaseModel> models);

        public abstract List<BaseModel> ParseFromFile();

        public abstract bool Export(List<BaseModel> models, string path);

        public abstract List<BaseModel> Import(string path);
    }
}
