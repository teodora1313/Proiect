using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Memberships
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ApplicationDbContext _context;

        public IndexModel(Proiect.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Membership> Membership { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Membership = await _context.Memberships
                .Include(m => m.Member)
                .OrderBy(m => m.Type)
                .OrderBy(m => m.EndDate)
                .ToListAsync(); 
        }
    }
}
