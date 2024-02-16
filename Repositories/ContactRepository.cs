using Company_Address_Book.Models;
using Company_Address_Book.Models.ViewModels;

namespace Company_Address_Book.Repositories
{
    public class ContactRepository : IContactRepository
    {
        protected ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Contact> GetAllContacts => _context.Contacts.AsQueryable();

        public Contact AddContact(CreateContactViewModel contact)
        {
            Contact newContact = new Contact
            {
                ContactName = contact.ContactName,
                Age = contact.ContactAge,
                PhoneNumber = int.Parse(contact.ContactNumber),
                CompanyId = contact.CompanyId,
            };
            _context.Contacts.Add(newContact);
            _context.SaveChanges();
            return newContact;
        }
    }
}
