using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VeriparkTask.Models
{
    public class SpecialDay
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Country")]
        public int CountryId { get; set; }

        [Display(Name = "Special Date")]
        [Required(ErrorMessage = "Please Enter Special Date")]
        public DateTime SpecialDate { get; set; }
    }
}