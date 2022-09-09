using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinalProject.Domain.Reservations
{
    public class Reservation
    {
        public Reservation()
        {
            TransactionDate = DateTime.Now;
        }
        public int Id { get; set; }
        [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters!")]
        [Required(ErrorMessage = "Please enter your name!")]
        public string Name { get; set; }

        [StringLength(20, ErrorMessage = "Surname cannot exceed 20 characters!")]
        [Required(ErrorMessage = "Please enter your surname!")]
        public string Surname { get; set; }

        [StringLength(40, ErrorMessage = "E-mail address cannot exceed 20 characters!")]
        [Required(ErrorMessage = "Please enter your e-mail address!")]
        public string Email { get; set; }

        //[Range(10,10, ErrorMessage = "Phone number should be 10 digit number!")]
        //[Required(ErrorMessage = "Please enter your Phone Number!")]
        [Required(ErrorMessage = "Please enter your phone number!")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Please enter valid phone number!")]
        public string Phone { get; set; }

        [StringLength(50)]
        public string Hotel { get; set; }

        [Display(Name="Reservation Date")]
        [DataType(DataType.Date)]
        public DateTime ReservationDate { get; set; }=DateTime.Now;

        public string ReservationNumber { get; set; }
        public string ReservationMessage { get; set; }
        public bool isSended { get; set; }=false;


        [Display(Name = "Transaction Date")]
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; private set; }
        public string cityName { get; set; }
    }
}
