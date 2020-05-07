using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;


using Sima_Web.Models;


namespace Sima_Web.Pages.Homes
{
  public class CreateModel : PageModel
  {
    private readonly SimaContext _context;

    [BindProperty]
    public Quarter Quarter { get; set; }

    public CreateModel(SimaContext context) { _context = context; }

    public IActionResult OnGet()
    {
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

      _context.Quarters.Add(Quarter);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
