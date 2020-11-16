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

        public DeleteModel(IConfiguration config, IWhiskeyData whiskeyData)
        {

            this.config = config;
            this.whiskeyData = whiskeyData;
        }



        public void OnGet(int WhiskeyId)
        {
            Whiskey = whiskeyData.GetById(WhiskeyId);
        }

        public IActionResult OnPost(int WhiskeyId)
        {
            var whiskey = whiskeyData.Delete(WhiskeyId);
            return RedirectToPage("./Index");
        }
    }
}
