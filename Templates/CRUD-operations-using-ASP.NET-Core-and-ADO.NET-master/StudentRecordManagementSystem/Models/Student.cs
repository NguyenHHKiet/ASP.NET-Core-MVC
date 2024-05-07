using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentRecordManagementSystem.Models
{
    public class Student
    {
        public int Id { set; get; }
        [Required]
        public string FirstName { set; get; }
        [Required]
        public string LastName { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Mobile { set; get; }
        public string Address { set; get; }
    }
}
