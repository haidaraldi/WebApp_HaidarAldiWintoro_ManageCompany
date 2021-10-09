using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using WebApp_HaidarAldiWintoro_ManageCompany.Data;
using WebApp_HaidarAldiWintoro_ManageCompany.Models;
using WebApp_HaidarAldiWintoro_ManageCompany.ViewModels;
using WebApp_HaidarAldiWintoro_ManageCompany.ViewModels.Master;

namespace WebApp_HaidarAldiWintoro_ManageCompany.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompaniesController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _webHostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var companies = await _context.Companies.ToListAsync();

            return View(new MasterCompanyViewModel { ListCompanies = companies });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MasterCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);
                Companies companies = new Companies
                {
                    Name = model.CompaniesVM.Name,
                    Email = model.CompaniesVM.Email,
                    Logo = uniqueFileName,
                    Website = model.CompaniesVM.Website
                };

                _context.Add(companies);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companies = await _context.Companies.FindAsync(id);
            var companyViewModel = new CompanyViewModel()
            {
                Id = companies.Index,
                Name = companies.Name,
                Email = companies.Email,
                Website = companies.Website,
                ExistingImage = companies.Logo,
            };

            if (companies == null)
            {
                return NotFound();
            }
            return View(new MasterCompanyViewModel { CompaniesVM = companyViewModel });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, MasterCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var companies = await _context.Companies.FindAsync(model.CompaniesVM.Id);
                companies.Name = model.CompaniesVM.Name;
                companies.Email = model.CompaniesVM.Email;
                companies.Website = model.CompaniesVM.Website;

                if (model.CompaniesVM.CompanyLogo != null)
                {
                    if (model.CompaniesVM.ExistingImage != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, FileLocation.FileUploadFolder, model.CompaniesVM.ExistingImage);
                        System.IO.File.Delete(filePath);
                    }

                    companies.Logo = ProcessUploadedFile(model);
                }
                _context.Update(companies);
                await _context.SaveChangesAsync();
                TempData["MessageSuccess"] = "Update data success.";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var company = await _context.Companies
                .FirstOrDefaultAsync(m => m.Index == id);

            var companyViewModel = new CompanyViewModel()
            {
                Id = company.Index,
                Name = company.Name,
                Email = company.Email,
                Website = company.Website,
                ExistingImage = company.Logo
            };
            if (company == null)
            {
                return NotFound();
            }

            return View(companyViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companies = await _context.Companies.FindAsync(id);
            var CurrentImage = Path.Combine(Directory.GetCurrentDirectory(), FileLocation.DeleteFileFromFolder, companies.Logo);
            _context.Companies.Remove(companies);
            if (System.IO.File.Exists(CurrentImage))
            {
                System.IO.File.Delete(CurrentImage);
            }
            await _context.SaveChangesAsync();
            TempData["MessageSuccess"] = "Delete data success.";
            return RedirectToAction(nameof(Index));
        }

        private string ProcessUploadedFile(MasterCompanyViewModel model)
        {
            string uniqueFileName = null;

            if (model.CompaniesVM.CompanyLogo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, FileLocation.FileUploadFolder);
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.CompaniesVM.CompanyLogo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CompaniesVM.CompanyLogo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
