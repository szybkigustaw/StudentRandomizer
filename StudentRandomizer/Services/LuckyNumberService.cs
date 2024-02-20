using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRandomizer.Services
{
    public class LuckyNumberService
    {
        private int lucky_number;
        private StudentsCountService students_count;

        public int LuckyNumber { get => lucky_number; set => lucky_number = value; }
        public LuckyNumberService(StudentsCountService studentsCountService)
        {
            this.students_count = studentsCountService;
        }

        public void GenerateLuckyNumber()
        {
            var random_num = Random.Shared.Next(students_count.MaxStudentsCount) + 1;
            LuckyNumber = random_num;
        }
    }
}
