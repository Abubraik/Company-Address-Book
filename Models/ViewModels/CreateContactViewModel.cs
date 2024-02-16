using System.ComponentModel.DataAnnotations;

namespace Company_Address_Book.Models.ViewModels
{
    public class CreateContactViewModel
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "The contact number must be 11 characters long.", MinimumLength = 11)]
        [RegularExpression("^01[0-9]{9}$", ErrorMessage = "The contact number must start with '01' and be 11 digits in length.")]
        public string ContactNumber { get; set; }

        [Required]
        public string ContactName { get; set; }
        [Required]
        public int ContactAge { get; set; }
    }
}
