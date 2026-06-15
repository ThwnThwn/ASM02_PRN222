using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Repositories.ThuanVCT.DBContext;
using sealHkthon.Services.ThuanVCT;

namespace sealHkthon.RazorWebApp.ThuanVCT.Pages.EventsThuanVcts
{
    public class DetailsModel : PageModel
    {
        private readonly IEventsThuanVctService _eventsThuanVctService;

        public DetailsModel(IEventsThuanVctService eventsThuanVctService)
        {
            _eventsThuanVctService = eventsThuanVctService;
        }

        public EventsThuanVct EventsThuanVct { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventsthuanvct = await _eventsThuanVctService.GetByIdAsync(id.Value);

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
    }
}
