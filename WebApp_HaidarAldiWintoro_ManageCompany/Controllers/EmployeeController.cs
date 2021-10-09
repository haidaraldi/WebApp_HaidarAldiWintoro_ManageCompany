using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApp_HaidarAldiWintoro_ManageCompany.Data;
using WebApp_HaidarAldiWintoro_ManageCompany.Models;
using WebApp_HaidarAldiWintoro_ManageCompany.ViewModels;
using WebApp_HaidarAldiWintoro_ManageCompany.ViewModels.Master;

namespace WebApp_HaidarAldiWintoro_ManageCompany.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var listEmployee = await _context
           .Employees
           .Select(t => new EmployeesViewModel
           {
               Index = t.Index,
               FirstName = t.FirstName,
               LastName = t.LastName,
               Phone = t.Phone,
               CompanyName = t.Companies.Name,
               CompanyEmail = t.Companies.Email,
               CompanyWeb  = t.Companies.Website
           }).Distinct().ToListAsync();

            var companies = await _context
           .Companies
           .Select(t => new CompanyNameViewModel
           {
               IndexCompany = t.Index,
               CompanyName = t.Name
           }).Distinct().ToListAsync();


            return View(new MasterEmployeeViewModel { CompanyNames = companies, EmployeesVMs = listEmployee });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(MasterEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employees employees = new Employees
                {
                    FirstName = model.EmployeesVM.FirstName,
                    LastName = model.EmployeesVM.LastName,
                    Phone = model.EmployeesVM.Phone,
                    CompaniesIndex = model.EmployeesVM.IndexCompany
                };

                _context.Add(employees);
                await _context.SaveChangesAsync();
                TempData["MessageSuccess"] = "Add new data success.";
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int? index)
        {
            if (index == null)
            {
                return NotFound();
            }

            var companies = await _context
           .Companies
           .Select(t => new CompanyNameViewModel
           {
               IndexCompany = t.Index,
               CompanyName = t.Name
           }).Distinct().ToListAsync();

            var employees = await _context.Employees.FindAsync(index);
            var companyName = await _context.Companies.FindAsync(employees.CompaniesIndex);
            var employeViewModel = new EmployeesViewModel()
            {
                Index = employees.Index,
                FirstName = employees.FirstName,
                LastName = employees.LastName,
                Phone = employees.Phone,
                IndexCompany = employees.CompaniesIndex,
                CompanyName = companyName.Name
            };

            if (employees == null)
            {
                return NotFound();
            }
            return View(new MasterEmployeeViewModel { EmployeesVM = employeViewModel, CompanyNames = companies });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employees = await _context.Employees.FindAsync(model.EmployeesVM.Index);
                employees.FirstName = model.EmployeesVM.FirstName;
                employees.LastName = model.EmployeesVM.LastName;
                employees.Phone = model.EmployeesVM.Phone;
                employees.CompaniesIndex = model.EmployeesVM.IndexCompany;
          
                _context.Update(employees);
                await _context.SaveChangesAsync();
                TempData["MessageSuccess"] = "Update data success.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
