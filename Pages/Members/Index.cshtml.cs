using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly Proiect.Data.ApplicationDbContext _context;

        public IndexModel(Proiect.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Member = await _context.Members
                .OrderBy(a => a.FirstName)
                .ToListAsync();
        }
    }
}
