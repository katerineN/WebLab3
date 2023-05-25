using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebLab.Data;
using WebLab.Models;

namespace WebLab
{
    public class CreateModel : PageModel
    {
        private readonly WebLab.Data.Context _context;

        public CreateModel(WebLab.Data.Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ContactForm ContactForm { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FormContacts == null || ContactForm == null)
            {
                return Page();
            }

            _context.FormContacts.Add(ContactForm);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
