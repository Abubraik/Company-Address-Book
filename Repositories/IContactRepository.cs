using Company_Address_Book.Models;
using Company_Address_Book.Models.ViewModels;

namespace Company_Address_Book.Repositories
{
    public interface IContactRepository
    {
        IQueryable<Contact> GetAllContacts { get; }
        Contact AddContact(CreateContactViewModel contact);

    }
}
