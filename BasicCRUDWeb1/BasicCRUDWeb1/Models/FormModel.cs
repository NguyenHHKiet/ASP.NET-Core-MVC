using System;
using System.ComponentModel.DataAnnotations;

namespace Telerik.Scaffolders.Models.Form
{
    public class FormModel
    {
        public int UserID
        {
            get;
            set;
        }

        [Required]
        public string UserName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName
        {
            get; set;
        }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName
        {
            get;
            set;
        }


        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-‌​]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$", ErrorMessage = "Email is not valid")]
        public string Email
        {
            get;
            set;
        }

        [Required]
        public string Password
        {
            get;
            set;
        }

        [Required]
        public bool Agree
        {
            get;
            set;
        }

        public DateTime? DateOfBirth { get; set; }

        public DateTime? HireDate { get; set; }

        public DateTime? RetireDate { get; set; }

        public string Company { get; set; }

        public string Feedback { get; set; }
    }
}

