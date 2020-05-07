using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


using Sima_Web.Models;


namespace Sima_Web.Pages.Homes
{
  public class EditModel : PageModel
  {
    private readonly SimaContext _context;

    [BindProperty]
    public Quarter Quarter { get; set; }

    public EditModel(SimaContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Quarter = await _context.Quarters.Include(q => q.AddressArea)
                              .Include(q => q.Owner)
                              .Include(q => q.TypeHouse)
                              .FirstOrDefaultAsync(m => m.Id == id);

      if (Quarter == null) return NotFound();
      ViewData["AddressAreaId"] = new SelectList(_context.Areas, "Id", "Name");
      ViewData["OwnerId"]       = new SelectList(_context.Customers, "Id", "AddressStreet");
      ViewData["TypeHouseId"]   = new SelectList(_context.TypeHouses, "Id", "Name");
      return Page();
    }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Attach(Quarter).State = EntityState.Modified;

      try { await _context.SaveChangesAsync(); }
      catch (DbUpdateConcurrencyException)
      {
        if (!QuarterExists(Quarter.Id))
          return NotFound();
        throw;
      }

      return RedirectToPage("./Index");
    }

    private bool QuarterExists(int id) { return _context.Quarters.Any(e => e.Id == id); }
  }
}
