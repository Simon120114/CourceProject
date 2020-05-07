using System.Collections.Generic;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using Sima_Web.Models;


namespace Sima_Web.Pages.Areas
{
  public class IndexModel : PageModel
  {
    private readonly SimaContext _context;

    public IList<Area> Area { get; set; }

    public IndexModel(SimaContext context) { _context = context; }

    public async Task OnGetAsync() { Area = await _context.Areas.ToListAsync(); }
  }
}
