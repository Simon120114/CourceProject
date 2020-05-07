using System.Collections.Generic;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using Sima_Web.Models;


namespace Sima_Web.Pages.Homes
{
  public class IndexModel : PageModel
  {
    private readonly SimaContext _context;

    public IList<Quarter> Quarter { get; set; }

    public IndexModel(SimaContext context) { _context = context; }

    public async Task OnGetAsync()
    {
      Quarter = await _context.Quarters.Include(q => q.AddressArea)
                              .Include(q => q.Owner)
                              .Include(q => q.TypeHouse)
                              .ToListAsync();
    }
  }
}
