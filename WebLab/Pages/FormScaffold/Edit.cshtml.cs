using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebLab.Data;
using WebLab.Models;

namespace WebLab
{
    public class EditModel : PageModel
    {
        private readonly WebLab.Data.Context _context;

        public EditModel(WebLab.Data.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactForm ContactForm { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FormContacts == null)
            {
                return NotFound();
            }

            var contactform =  await _context.FormContacts.FirstOrDefaultAsync(m => m.ID == id);
            if (contactform == null)
            {
                return NotFound();
            }
            ContactForm = contactform;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ContactForm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactFormExists(ContactForm.ID))
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

        private bool ContactFormExists(int id)
        {
          return (_context.FormContacts?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
