using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


using Sima_Web.Models;


namespace Sima_Web.Pages.Areas
{
  public class CreateModel : PageModel
  {
    private readonly SimaContext _context;

    [BindProperty]
    public Area Area { get; set; }

    public CreateModel(SimaContext context) { _context = context; }

    public IActionResult OnGet() { return Page(); }


    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid) return Page();

      _context.Areas.Add(Area);
      await _context.SaveChangesAsync();

      return RedirectToPage("./Index");
    }
  }
}
