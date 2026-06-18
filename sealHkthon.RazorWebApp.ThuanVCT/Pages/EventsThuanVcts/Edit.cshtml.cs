using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Services.ThuanVCT;

namespace sealHkthon.RazorWebApp.ThuanVCT.Pages.EventsThuanVcts
{
    public class EditModel : PageModel
    {
        private readonly IEventsThuanVctService _eventThuanVct;
        private readonly IRoundsThuanVctService _roundThuanVct;

        public EditModel(IEventsThuanVctService eventThuanVct, IRoundsThuanVctService roundThuanVct)
        {
            _eventThuanVct = eventThuanVct;
            _roundThuanVct = roundThuanVct;
        }

        [BindProperty]
        public EventsThuanVct EventsThuanVct { get; set; } = default!;

        [BindProperty]
        public string? SelectedRoundName { get; set; }

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

            var rounds = await _roundThuanVct.GetAllAsync();
            if (SelectedRoundName == null)
            {
                SelectedRoundName = rounds.FirstOrDefault()?.RoundName;
            }

            ViewData["RoundName"] = new SelectList(rounds, "RoundName", "RoundName", SelectedRoundName);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var rounds = await _roundThuanVct.GetAllAsync();
                ViewData["RoundName"] = new SelectList(rounds, "RoundName", "RoundName", SelectedRoundName);
                return Page();
            }

            var result = await _eventThuanVct.UpdateAsync(EventsThuanVct);

            if (result > 0)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
