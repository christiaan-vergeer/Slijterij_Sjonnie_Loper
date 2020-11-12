using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Slijterij_Sjonnie_Loper.Core;
using Slijterij_Sjonnie_Loper.Data;

namespace Slijterij_Sjonnie_Loper.Pages.Whiskey
{


    public class IndexModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IWhiskeyData whiskeyData;
        public IEnumerable<Core.Whiskey> Whiskeys { get; set; }  
        public IEnumerable<location> Locations { get; set; }
        public string message { get; set; }

        public string searchname { get; set; }
        public int searchage { get; set; }
        public int searcharea { get; set; }
        public int searchtype { get; set; }
        public int searchper { get; set; }

        public string agevalue { get; set; }
        public string pervalue { get; set; }



        public IndexModel(IConfiguration config, IWhiskeyData whiskeyData)
        {
           
            this.config = config;
            this.whiskeyData = whiskeyData;

          
        }

        public void OnGet(string searchname, int searchage, int searcharea, Core.Kind searchtype, int searchper)
        {

            message = config["message"];
            //Whiskeys = whiskeyData.Getall();
            Whiskeys = whiskeyData.GetAllByFind(searchname, searchage, searcharea, searchtype, searchper);
            Locations = whiskeyData.GetLocations();



            if (searchage == 0){agevalue = "";}
            else {agevalue = searchage.ToString();}
            if (searchper == 0){pervalue = "";}
            else{pervalue = searchper.ToString();
            }
        }
    }
}
