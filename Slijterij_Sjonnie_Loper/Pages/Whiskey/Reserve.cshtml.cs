using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Slijterij_Sjonnie_Loper.Data;
using Slijterij_Sjonnie_Loper.Core;

namespace Slijterij_Sjonnie_Loper.Pages.Whiskey
{
    public class ReserveModel : PageModel
    {
        private readonly IWhiskeyData whiskeyData;

        public Core.Whiskey Whiskey { get; set; }
        public IEnumerable<location> Locations { get; set; }


        public ReserveModel(IWhiskeyData whiskeyData)
        {
            this.whiskeyData = whiskeyData;
        }

        public void OnGet(int WhiskeyId)
        {
            Whiskey = whiskeyData.GetById(WhiskeyId);
        }
    }
}
