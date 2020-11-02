using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Slijterij_Sjonnie_Loper.Data;

namespace Slijterij_Sjonnie_Loper.Pages.Whiskey
{
    public class ReservationModel : PageModel
    {
        public Core.Whiskey Whiskey { get; set; }

        public void OnGet()
        {

        }
    }
}
