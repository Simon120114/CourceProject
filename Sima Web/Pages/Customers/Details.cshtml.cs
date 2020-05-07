using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using Sima_Web.Models;


namespace Sima_Web.Pages.Customers
{
  public class DetailsModel : PageModel
  {
    private readonly SimaContext _context;

    public Customer Customer { get; set; }

    public DetailsModel(SimaContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

      if (Customer == null) return NotFound();
      return Page();
    }
  }
}
