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
    public class ReservationModel : PageModel
    {
        private readonly IWhiskeyData whiskeyData;

        [BindProperty(SupportsGet = true)]
        public Core.Whiskey Whiskey { get; set; }
        [BindProperty]
        public ReservationOrder Order { get; set; }
        public IEnumerable<ReservationOrder> ReservationOrders { get; set; }

        //[BindProperty(SupportsGet = true)]
        //public int SearchId { get; set; }

        public ReservationModel(IWhiskeyData whiskeyData)
        {
            this.whiskeyData = whiskeyData;
        }

        public void OnGet(int WhiskeyId)
        {
            Whiskey = whiskeyData.GetById(WhiskeyId);
            ReservationOrders = whiskeyData.GetOrders();

            Order = new ReservationOrder();
        }

        public void OnPost(int WhiskeyId)
        {
            //Order.CustomerName = User.Identity.Name;
            //Order.Whiskey = whiskeyData.Getall().FirstOrDefault(a => a.Id == WhiskeyId);
            whiskeyData.AddOrder(Order);
            whiskeyData.Commit();
        }
    }
}
