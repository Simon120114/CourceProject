using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using Sima_Web.Models;


namespace Sima_Web.Pages.Homes
{
  public class DetailsModel : PageModel
  {
    private readonly SimaContext _context;

    public Quarter Quarter { get; set; }

    public DetailsModel(SimaContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Quarter = await _context.Quarters.Include(q => q.AddressArea)
                              .Include(q => q.Owner)
                              .Include(q => q.TypeHouse)
                              .FirstOrDefaultAsync(m => m.Id == id);

      if (Quarter == null) return NotFound();
      return Page();
    }
  }
}
