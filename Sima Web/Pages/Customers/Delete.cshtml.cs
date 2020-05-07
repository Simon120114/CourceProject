using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using Sima_Web.Models;


namespace Sima_Web.Pages.Customers
{
  public class DeleteModel : PageModel
  {
    private readonly SimaContext _context;

    [BindProperty]
    public Customer Customer { get; set; }

    public DeleteModel(SimaContext context) { _context = context; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null) return NotFound();

      Customer = await _context.Customers.FirstOrDefaultAsync(m => m.Id == id);

      if (Customer == null) return NotFound();
      return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null) return NotFound();

      Customer = await _context.Customers.FindAsync(id);

      if (Customer != null)
      {
        _context.Customers.Remove(Customer);
        await _context.SaveChangesAsync();
      }

      return RedirectToPage("./Index");
    }
  }
}
