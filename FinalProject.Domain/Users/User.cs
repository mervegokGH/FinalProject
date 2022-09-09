using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinalProject.Domain.Users
{
    public class User
    {
        public User()
        {
            RegistrationDate = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [StringLength(20, ErrorMessage = "Username cannot exceed 20 characters!")]
        [Required(ErrorMessage = "Please enter your username!")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Password cannot exceed 20 characters!")]
        [Required(ErrorMessage = "Please enter your password!")]
        public string Password { get; set; }

        [StringLength(40, ErrorMessage = "E-mail address cannot exceed 20 characters!")]
        [Required(ErrorMessage = "Please enter your E-mail address!")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime RegistrationDate { get; private set; }

        public bool IsActive { get; set; } = false;

        public bool IsDeleted { get; set; } = false;
    }
}
