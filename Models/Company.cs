using System.ComponentModel.DataAnnotations;

namespace Company_Address_Book.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [Required]
        public int NumberOfContacts { get; set; }
        [Required]
        public int ContactMaxAge { get; set; }


        public List<Contact> Contact { get; set; }
    }
}
