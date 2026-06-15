using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Repositories.ThuanVCT.DBContext;

namespace sealHkthon.RazorWebApp.ThuanVCT.Pages.EventsThuanVcts
{
    public class EditModel : PageModel
    {
        private readonly sealHkthon.Repositories.ThuanVCT.DBContext.PRN222_HACKATHONContext _context;

        public EditModel(sealHkthon.Repositories.ThuanVCT.DBContext.PRN222_HACKATHONContext context)
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

            var eventsthuanvct =  await _context.EventsThuanVcts.FirstOrDefaultAsync(m => m.EventThuanVctid == id);
            if (eventsthuanvct == null)
            {
                return NotFound();
            }
            EventsThuanVct = eventsthuanvct;
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

            _context.Attach(EventsThuanVct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventsThuanVctExists(EventsThuanVct.EventThuanVctid))
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

        private bool EventsThuanVctExists(int id)
        {
            return _context.EventsThuanVcts.Any(e => e.EventThuanVctid == id);
        }
    }
}
