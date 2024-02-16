using Company_Address_Book.Models;

namespace Company_Address_Book.Repositories
{
    public interface ICompanyRepository
    {
        Company GetCompanyById(int id);
        IQueryable<Company> GetCompanies();
        Company AddCompany(Company company);
        Company GetCompanyByName(string name);
        //Company DeleteCompany(int id);
    }
}
