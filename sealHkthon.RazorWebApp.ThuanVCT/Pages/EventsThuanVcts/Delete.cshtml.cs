using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Services.ThuanVCT;

namespace sealHkthon.RazorWebApp.ThuanVCT.Pages.EventsThuanVcts
{
    public class DeleteModel : PageModel
    {
        private readonly IEventsThuanVctService _eventThuanVct;

        public DeleteModel(IEventsThuanVctService eventThuanVct)
        {
            _eventThuanVct = eventThuanVct;
        }

        [BindProperty]
        public EventsThuanVct EventsThuanVct { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsthuanvct = await _eventThuanVct.GetByIdAsync(id.Value);

            if (eventsthuanvct == null)
            {
                return NotFound();
            }

            EventsThuanVct = eventsthuanvct;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _eventThuanVct.DeleteAsync(id.Value);

            return RedirectToPage("./Index");
        }
    }
}
