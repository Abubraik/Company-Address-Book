﻿using Company_Address_Book.Models;
using Microsoft.EntityFrameworkCore;

namespace Company_Address_Book.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        protected ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Company GetCompanyById(int id)
        {
            return _context.Companies.AsNoTracking().FirstOrDefault(x => x.CompanyId == id);
        }
        public Company GetCompanyByName(string name)
        {
            return _context.Companies.AsNoTracking().FirstOrDefault(x => x.CompanyName == name);
        }
        public void AddCompany(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
        }

        public IQueryable<Company> GetCompanies()
        {
            return _context.Companies.AsQueryable();
        }
    }
}
