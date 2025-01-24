using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect.Data;
using Proiect.Models;

namespace Proiect.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly Proiect.Data.ApplicationDbContext _context;

        public EditModel(Proiect.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments.FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }
            Appointment = appointment;

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(Appointment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.Id == id);
        }
    }
}
