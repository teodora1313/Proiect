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
    public class DetailsModel : PageModel
    {
        private readonly Proiect.Data.ApplicationDbContext _context;

        public DetailsModel(Proiect.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Membership Membership { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var membership = await _context.Memberships
                .Include(m => m.Member)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (membership == null)
            {
                return NotFound();
            }
            else
            {
                Membership = membership;
            }
            return Page();
        }
    }
}
