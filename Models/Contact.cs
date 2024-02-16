using System.ComponentModel.DataAnnotations;

namespace Company_Address_Book.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ContactName { get; set; }
        [Required]
        [MaxLength(2)]
        public int Age { get; set; }

        [Required]
        public int PhoneNumber { get; set; }


        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}