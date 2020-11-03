using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Slijterij_Sjonnie_Loper.Data;
using Slijterij_Sjonnie_Loper.Core;

namespace Slijterij_Sjonnie_Loper.Pages.Whiskey
{
    public class CreateModel : PageModel
    {
        private readonly IWhiskeyData whiskeyData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Core.Whiskey Whiskey { get; set; }
        public IEnumerable<SelectListItem> Kinds { get; set; }

        public CreateModel(IWhiskeyData whiskeyData, 
                           IHtmlHelper htmlHelper)
        {
            this.whiskeyData = whiskeyData;
            this.htmlHelper = htmlHelper;
        }

        public void OnGet()
        {
            Kinds = htmlHelper.GetEnumSelectList<Kind>();

            Whiskey = new Core.Whiskey();
        }

        public IActionResult OnPost(int whiskeyId)
        {
            Whiskey = whiskeyData.GetById(whiskeyId);
            if (!ModelState.IsValid)
            {
                Kinds = htmlHelper.GetEnumSelectList<Kind>();
                return Page();
            }
            whiskeyData.Add(Whiskey);
            whiskeyData.Commit();
            return RedirectToPage("./Whiskey");
        }
    }
}
