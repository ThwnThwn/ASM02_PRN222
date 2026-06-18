using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using sealHkthon.Entities.ThuanVCT.Models;
using sealHkthon.Services.ThuanVCT;

namespace sealHkthon.RazorWebApp.ThuanVCT.Pages.EventsThuanVcts
{
    public class IndexModel : PageModel
    {
        private readonly IEventsThuanVctService _eventsThuanVct;

        [BindProperty(SupportsGet = true)]
        public string eventName { get; set; } = default;

        [BindProperty(SupportsGet = true)]
        public string roundName { get; set; } = default;

        [BindProperty(SupportsGet = true)]
        public int status { get; set; } = default;

        public IndexModel(IEventsThuanVctService eventsThuanVct)
        {
            _eventsThuanVct = eventsThuanVct;
        }

        public IList<EventsThuanVct> EventsThuanVct { get; set; } = default!;

        public async Task OnGetAsync()
        {
            EventsThuanVct = await _eventsThuanVct.SearchAsync(eventName, roundName, status);
        }
    }
}
