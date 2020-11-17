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
    public class DetailsModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IWhiskeyData whiskeyData;

        public Core.Whiskey Whiskey { get; set; }
        public IEnumerable<location> Locations { get; set; }
        public string ImagePath { get; set; }
        public string no { get; set; }



        public DetailsModel(IConfiguration config, IWhiskeyData whiskeyData)
        {

            this.config = config;
            this.whiskeyData = whiskeyData;
        }


        public void OnGet(int WhiskeyId)
        {
            //ImagePath = "Img_1.png";


            Whiskey = whiskeyData.GetById(WhiskeyId);
        }

        public void OnPost()
        {
        }
    }
}
