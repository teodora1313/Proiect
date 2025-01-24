using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Memberships
{
    public class CreateModel : PageModel
    {
        private readonly Proiect.Data.ApplicationDbContext _context;

        public CreateModel(Proiect.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var memberList = _context.Members.Select(x => new
            {
                x.Id,
                MemberName = x.FirstName + " " + x.LastName
            });
            ViewData["MemberId"] = new SelectList(memberList, "Id", "MemberName");

            return Page();
        }

        [BindProperty]
        public Membership Membership { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Memberships.Add(Membership);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
