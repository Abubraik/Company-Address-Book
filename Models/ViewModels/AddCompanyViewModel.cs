using System.ComponentModel.DataAnnotations;

namespace Company_Address_Book.Models.ViewModels
{
    public class AddCompanyViewModel
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public int NumberOfContacts { get; set; }
        [Required,MaxLength(2)]
        public string ContactMaxAge { get; set; }
       
    }
}
