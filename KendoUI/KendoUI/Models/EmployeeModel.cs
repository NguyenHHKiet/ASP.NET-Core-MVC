
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Telerik.Scaffolders.Models.Grid
{
    public class EmployeeModel
    {
        [Key]
        [Required]
        [DisplayName("Mã nhân viên")]
        [Editable(false)]
        public string UserID { get; set; }
        [Required]
        [DisplayName("Tên nhân viên")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("Mật khẩu")]
        public string Password { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("Số điện thoại")]
        public string Tel { get; set; }
        [Required]
        public byte Disable { get; set; }

        internal bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Use MailAddress class to validate email
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

