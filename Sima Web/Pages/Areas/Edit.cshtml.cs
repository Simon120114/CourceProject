using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using Sima_Web.Models;


namespace Sima_Web.Pages.Areas
{
  public class EditModel : PageModel
  {
    private readonly SimaContext _context;

    [BindProperty]
    public Area Area { get; set; }

    public EditModel(SimaContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Area = await _context.Areas.FirstOrDefaultAsync(m => m.Id == id);

      if (Area == null) return NotFound();
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Attach(Area).State = EntityState.Modified;

      try { await _context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!AreaExists(Area.Id))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool AreaExists(int id) { return _context.Areas.Any(e => e.Id == id); }
  }
}
