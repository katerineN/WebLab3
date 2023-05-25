using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebLab.Data;
using WebLab.Models;

namespace WebLab
{
    public class DeleteModel : PageModel
    {
        private readonly WebLab.Data.Context _context;

        public DeleteModel(WebLab.Data.Context context)
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

            var contactform = await _context.FormContacts.FirstOrDefaultAsync(m => m.ID == id);

            if (contactform == null)
            {
                return NotFound();
            }
            else 
            {
                ContactForm = contactform;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FormContacts == null)
            {
                return NotFound();
            }
            var contactform = await _context.FormContacts.FindAsync(id);

            if (contactform != null)
            {
                ContactForm = contactform;
                _context.FormContacts.Remove(ContactForm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
