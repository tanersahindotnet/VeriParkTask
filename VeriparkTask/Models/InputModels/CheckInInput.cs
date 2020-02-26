using System;
using System.ComponentModel.DataAnnotations;

namespace VeriparkTask.Models.InputModels
{
    public class CheckInInput
    {
        public CheckInInput()
        {
            BookCheckIn = DateTime.Now;
            BookReceived = DateTime.Now;
        }

        [Display(Name = "Book Check In")]
        [Required(ErrorMessage = "Please Enter BookCheckIn Date")]
        public DateTime BookCheckIn { get; set; }

        [Display(Name = "Book Received")]
        [Required(ErrorMessage = "Please Enter Book Received Date")]
        public DateTime BookReceived { get; set; }

        public int CountryId { get; set; }
    }
}