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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Slijterij_Sjonnie_Loper.Pages.Whiskey
{
    public class CreateModel : PageModel
    {
        private readonly IWhiskeyData whiskeyData;
        private readonly IHtmlHelper htmlHelper;
        public IWebHostEnvironment IWebHostEnvironment { get; }
        public string FileName { get; set; }

        [BindProperty]
        public Core.Whiskey Whiskey { get; set; }
        public IEnumerable<SelectListItem> Kinds { get; set; }
        [BindProperty(SupportsGet = true)]
        public IEnumerable<location> Locations { get; set; }
        [BindProperty]
        public int AreaId { get; set; }

        public CreateModel(IWhiskeyData whiskeyData, 
                           IHtmlHelper htmlHelper,
                           IWebHostEnvironment IWebHostEnvironment)
        {
            this.whiskeyData = whiskeyData;
            this.htmlHelper = htmlHelper;
            this.IWebHostEnvironment = IWebHostEnvironment;
        }

        public IActionResult OnGet()
        {
            Kinds = htmlHelper.GetEnumSelectList<Kind>();
            Locations = whiskeyData.GetLocations();

            Whiskey = new Core.Whiskey();
            return Page();
        }

        public IActionResult OnPost(IFormFile photo)
        {
            var path = Path.Combine(IWebHostEnvironment.WebRootPath, "Images", photo.FileName);
            var stream = new FileStream(path, FileMode.Create);
            photo.CopyToAsync(stream);
            FileName = photo.FileName;
            Whiskey.Imagedata = photo.FileName;

            if (!ModelState.IsValid)
            {
                Kinds = htmlHelper.GetEnumSelectList<Kind>();
                Locations = whiskeyData.GetLocations();

                return Page();
            }

            Whiskey.Area = whiskeyData.GetLocations().FirstOrDefault(a => a.Id == AreaId);
            whiskeyData.Add(Whiskey);
            whiskeyData.Commit();
            return RedirectToPage("./Index");
        }
    }
}
