using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamleArc.Db.Models
{
    public class StudentEntity
    {
        public int StudentId { get; set; }
       
        public string Name { get; set; } = String.Empty;
       
        public string FirstName { get; set; } = String.Empty;
       
        public string LastName { get; set; } = String.Empty;
     
        public int Age { get; set; }
    }
}
