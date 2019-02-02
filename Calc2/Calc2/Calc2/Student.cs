using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebApplication1
{
    public class Student
    {
        
        public string InternalStudentId { get; set; }
        public string Name { get; set; }
        public int RollNo { get; set; }

        public List<SemesterScore> MarkList { get; set; } = new List<SemesterScore>();
    }
}
