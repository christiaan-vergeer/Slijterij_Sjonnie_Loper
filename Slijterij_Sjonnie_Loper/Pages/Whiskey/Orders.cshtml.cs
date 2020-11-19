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
    public class OrdersModel : PageModel
    {
        private readonly IWhiskeyData whiskeyData;

        [BindProperty]
        public IEnumerable<ReservationOrder> ReservationOrders { get; set; }
        public ReservationOrder Order { get; set; }
        public Core.Whiskey Whiskey { get; set; }

        public OrdersModel(IWhiskeyData whiskeyData)
        {
            this.whiskeyData = whiskeyData;
        }

        public void OnGet()
        {
            ReservationOrders = whiskeyData.GetOrders();
        }
    }
}
