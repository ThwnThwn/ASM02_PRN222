using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Repositories.ThuanVCT.DBContext;
using sealHkthon.Services.ThuanVCT;

namespace sealHkthon.RazorWebApp.ThuanVCT.Pages.EventsThuanVcts
{
    public class CreateModel : PageModel
    {
        private readonly IEventsThuanVctService _eventThuanVct;
        private readonly IRoundsThuanVctService _roundThuanVct;

        public CreateModel(IEventsThuanVctService eventThuanVct, IRoundsThuanVctService roundThuanVct)
        {
            _eventThuanVct = eventThuanVct;
            _roundThuanVct = roundThuanVct;
        }

        public async Task<IActionResult> OnGet()
        {
            ViewData["RoundName"] = new SelectList((await _roundThuanVct.GetAllAsync()), "RoundName", "RoundName");

            if (EventsThuanVct == null)
            {
                EventsThuanVct = new EventsThuanVct
                {
                    PublishDate = DateTime.Now,
                    IsActive = true
                };
            }

            return Page();
        }   

        [BindProperty]
        public EventsThuanVct EventsThuanVct { get; set; } = default!;

        [BindProperty]
        public string? SelectedRoundName { get; set; }

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["RoundName"] = new SelectList((await _roundThuanVct.GetAllAsync()), "RoundName", "RoundName", SelectedRoundName);
                return Page();
            }

            //_context.EventsThuanVcts.Add(EventsThuanVct);
            //await _context.SaveChangesAsync();

            var result = await _eventThuanVct.CreateAsync(EventsThuanVct);

            if (result > 0)
            {
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
