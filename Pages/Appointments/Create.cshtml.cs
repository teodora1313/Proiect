using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Appointments
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
            var trainerList = _context.Trainers.Select(x => new
            {
                x.Id,
                TrainerName = x.FirstName + " " + x.LastName
            });
            ViewData["MemberId"] = new SelectList(memberList, "Id", "MemberName");
            ViewData["TrainerId"] = new SelectList(trainerList, "Id", "TrainerName");

            //ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
            //ViewData["TrainerId"] = new SelectList(_context.Trainers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Appointments.Add(Appointment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
