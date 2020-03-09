using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UniversityManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string RegNumber { get; set; }
        [Required]
        public string Address { get; set; }

        public int DeptId { get; set; }
        public Department Department { get; set; }

    }
}
