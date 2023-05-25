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
    public class IndexModel : PageModel
    {
        private readonly WebLab.Data.Context _context;

        public IndexModel(WebLab.Data.Context context)
        {
            _context = context;
        }

        public IList<ContactForm> ContactForm { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FormContacts != null)
            {
                ContactForm = await _context.FormContacts.ToListAsync();
            }
        }
    }
}
