using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Repositories.ThuanVCT.DBContext;

namespace sealHkthon.RazorWebApp.ThuanVCT.Pages.EventsThuanVcts
{
    public class DeleteModel : PageModel
    {
        private readonly sealHkthon.Repositories.ThuanVCT.DBContext.PRN222_HACKATHONContext _context;

        public DeleteModel(sealHkthon.Repositories.ThuanVCT.DBContext.PRN222_HACKATHONContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventsThuanVct EventsThuanVct { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsthuanvct = await _context.EventsThuanVcts.FirstOrDefaultAsync(m => m.EventThuanVctid == id);

            if (eventsthuanvct == null)
            {
                return NotFound();
            }
            else
            {
                EventsThuanVct = eventsthuanvct;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsthuanvct = await _context.EventsThuanVcts.FindAsync(id);
            if (eventsthuanvct != null)
            {
                EventsThuanVct = eventsthuanvct;
                _context.EventsThuanVcts.Remove(EventsThuanVct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
