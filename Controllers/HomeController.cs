using Company_Address_Book.Models;
using Company_Address_Book.Models.ViewModels;
using Company_Address_Book.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Company_Address_Book.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICompanyRepository _companyRepository;
        private readonly IContactRepository _contactRepository;
        public HomeController(ILogger<HomeController> logger,ICompanyRepository companyRepository,IContactRepository contactRepository)
        {
            _logger = logger;
            _companyRepository = companyRepository;
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            return View(_companyRepository.GetCompanies().ToList());
        }
        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }

        public IActionResult ReadFile(IFormFile file)
        {
            var companies = new List<Company>();
            if (file != null && file.Length > 0)
            {

                using (var stream = file.OpenReadStream())
                using (var reader = new StreamReader(stream))
                {
                    string line;
                    string specialCharacters = @"§®™©ʬ@";
                    Regex specialCharWithDigitPattern = new Regex(@"\d[" + Regex.Escape(specialCharacters) + "]");

                    while ((line = reader.ReadLine()) != null)
                    {
                        var columns = line.Split(new[] { "\t\t" }, StringSplitOptions.None);
                        if (columns.Length == 3 && specialCharWithDigitPattern.IsMatch(columns[0]))
                        {
                            var company = new Company
                            {
                                CompanyName = columns[0],
                                NumberOfContacts = int.Parse(columns[1]),
                                ContactMaxAge = int.Parse(columns[2])
                            };
                            companies.Add(company);
                        }
                    }
                }
                foreach (var company in companies)
                {
                    if(_companyRepository.GetCompanyByName(company.CompanyName) == null)
                    _companyRepository.AddCompany(company);
                }
            }
                return RedirectToAction("Index");  
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactViewModel newContact)
        {
            if (ModelState.IsValid)
            {
                var company = _companyRepository.GetCompanyById(newContact.CompanyId);
                if (company != null)
                {
                    var contactsNum = _contactRepository.GetAllContacts.Where(c => c.CompanyId == company.CompanyId).Count();
                    if(contactsNum +1 <= company.NumberOfContacts && newContact.ContactAge <= company.ContactMaxAge)
                    {
                        _contactRepository.AddContact(newContact);
                    }
                }

            }
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
