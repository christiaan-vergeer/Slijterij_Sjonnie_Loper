using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Slijterij_Sjonnie_Loper.Data;
using Slijterij_Sjonnie_Loper.Core;
using Microsoft.AspNetCore.Mvc.Routing;

namespace Slijterij_Sjonnie_Loper.Pages.Whiskey
{
    public class CreateModel : PageModel
    {
        private readonly IWhiskeyData whiskeyData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Core.Whiskey Whiskey { get; set; }
        public IEnumerable<SelectListItem> Kinds { get; set; }
        public IEnumerable<location> Locations { get; set; }
        public int searchArea { get; set; }

        public CreateModel(IWhiskeyData whiskeyData, 
                           IHtmlHelper htmlHelper)
        {
            this.whiskeyData = whiskeyData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet()
        {
            Kinds = htmlHelper.GetEnumSelectList<Kind>();
            Locations = whiskeyData.GetLocations();

            Whiskey = new Core.Whiskey();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Kinds = htmlHelper.GetEnumSelectList<Kind>();
                //Locations = whiskeyData.GetLocations();

                return Page();
            }
            
            Whiskey.Area.Id = searchArea;
            whiskeyData.Add(Whiskey);
            whiskeyData.Commit();
            return RedirectToPage("./Index");
        }
    }
}
