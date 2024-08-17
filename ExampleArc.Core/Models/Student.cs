using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExampleArc.Core.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = String.Empty;
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = String.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = String.Empty;
        [Required, Range(0, 100)]
        public int Age { get; set; }
    }
}
