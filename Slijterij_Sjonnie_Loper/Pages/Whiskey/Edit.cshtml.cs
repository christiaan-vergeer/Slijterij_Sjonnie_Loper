using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Slijterij_Sjonnie_Loper.Core;
using Slijterij_Sjonnie_Loper.Data;

namespace Slijterij_Sjonnie_Loper.Pages.Whiskey
{
    public class EditModel : PageModel
    {

        private readonly IConfiguration config;
        private readonly IWhiskeyData whiskeyData;
        public IWebHostEnvironment IWebHostEnvironment { get; }
        
        public string FileName { get; set; }
        public Core.Whiskey Whiskey { get; set; }
        public IEnumerable<location> Locations { get; set; }
        public int searcharea { get; set; }

        public EditModel(IConfiguration config, IWhiskeyData whiskeyData, IWebHostEnvironment IWebHostEnvironment)
        {

            this.config = config;
            this.whiskeyData = whiskeyData;
            this.IWebHostEnvironment = IWebHostEnvironment;
        }



        public void OnGet(int WhiskeyId)
        {
            Whiskey = whiskeyData.GetById(WhiskeyId);
            Locations = whiskeyData.GetLocations();
            searcharea = Whiskey.Area.Id;
        }

        public IActionResult OnPost(Core.Whiskey whiskey, int searcharea, IFormFile photo)
        {
            if (photo != null)
            {
                var path = Path.Combine(IWebHostEnvironment.WebRootPath, "Images", whiskey.Imagedata);
                System.IO.File.Delete(path);

                path = Path.Combine(IWebHostEnvironment.WebRootPath, "Images", photo.FileName);
                var stream = new FileStream(path, FileMode.Create);
                photo.CopyToAsync(stream);                
                FileName = photo.FileName;
                whiskey.Imagedata = photo.FileName;
                //stream.Close();
            }

            whiskeyData.Edit(whiskey, searcharea);
            return RedirectToPage("./Index");

        }
    }
}
