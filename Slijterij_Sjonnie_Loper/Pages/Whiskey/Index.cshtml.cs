using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Slijterij_Sjonnie_Loper.Data;

namespace Slijterij_Sjonnie_Loper.Pages.Whiskey
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IWhiskeyData whiskeyData;
        public IEnumerable<Core.Whiskey> Whiskeys { get; set; }  
       // public Core.Kind Kind { get; set; }
        public string message { get; set; }
        public string searchname { get; set; }
        public int searchage { get; set; }
        public string searcharea { get; set; }
        public int searchtype { get; set; }
        public int searchper { get; set; }
        

        public IndexModel(IConfiguration config, IWhiskeyData whiskeyData)
        {
            this.config = config;
            this.whiskeyData = whiskeyData;
        }

        public void OnGet(string searchname, int searchage, string searcharea,int searchtype, int searchper)
        {

            message = config["message"];
            //Whiskeys = whiskeyData.Getall();
            Whiskeys = whiskeyData.GetAllByFind(searchname, searchage, searcharea, searchtype, searchper);
        }
    }
}
