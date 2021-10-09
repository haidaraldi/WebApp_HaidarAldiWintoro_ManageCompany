using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp_HaidarAldiWintoro_ManageCompany.Data;

namespace WebApp_HaidarAldiWintoro_ManageCompany.Controllers
{
    [Produces("application/json")]
    [Route("api/Employees")]
    public class EmployeesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{index}")]
        public async Task<IActionResult> DeleteEmployees(int index)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employees = await _context.Employees.SingleOrDefaultAsync(m => m.Index == index);
            if (employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();
            TempData["MessageSuccess"] = "Delete data success.";
            return Json(new { success = true, message = "Delete success." });
        }
    }
}
