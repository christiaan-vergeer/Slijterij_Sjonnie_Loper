using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Slijterij_Sjonnie_Loper.Core;
using Slijterij_Sjonnie_Loper.Data;

namespace Slijterij_Sjonnie_Loper.Pages.Whiskey
{
    public class DeleteModel : PageModel
    {

        private readonly IConfiguration config;
        private readonly IWhiskeyData whiskeyData;
        public Core.Whiskey Whiskey { get; set; }
        public IEnumerable<location> Locations { get; set; }
        public string yes { get; set; }
        public string no { get; set; }

        public DeleteModel(IConfiguration config, IWhiskeyData whiskeyData)
        {

            this.config = config;
            this.whiskeyData = whiskeyData;
        }



        public IActionResult OnGet(int WhiskeyId)
        {
            Whiskey = whiskeyData.GetById(WhiskeyId);
            if(Whiskey == null)
            {
                return RedirectToPage("./Index");
            }
            return Page();
        }

        public IActionResult OnPost(int WhiskeyId)
        {
            var whiskey = whiskeyData.Delete(WhiskeyId);

            whiskeyData.Commit();

            if(whiskey == null)
            {
                return RedirectToPage("./Index");
            }
            TempData["message"] = $"{whiskey.Name} deleted";
            return RedirectToPage("./Index");
        }
    }
}
