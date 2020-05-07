using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using Sima_Web.Models;


namespace Sima_Web.Pages.Areas
{
  public class DeleteModel : PageModel
  {
    private readonly SimaContext _context;

    [BindProperty]
    public Area Area { get; set; }

    public DeleteModel(SimaContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Area = await _context.Areas.FirstOrDefaultAsync(m => m.Id == id);

      if (Area == null) return NotFound();
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null) return NotFound();

      Area = await _context.Areas.FindAsync(id);

      if (Area != null)
      {
        _context.Areas.Remove(Area);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
