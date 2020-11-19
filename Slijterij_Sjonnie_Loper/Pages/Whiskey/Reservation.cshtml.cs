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

        [BindProperty]
        public Core.Whiskey Whiskey { get; set; }
        [BindProperty]
        public ReservationOrder Order { get; set; }
        [BindProperty]
        public IEnumerable<ReservationOrder> ReservationOrders { get; set; }
        [BindProperty]
        public string AreaName { get; set; }

        public int NewSupply;

        public ReservationModel(IWhiskeyData whiskeyData)
        {
            this.whiskeyData = whiskeyData;
        }

        public IActionResult OnGet(int WhiskeyId)
        {
            Whiskey = whiskeyData.GetById(WhiskeyId);
            ReservationOrders = whiskeyData.GetOrders();
            AreaName = Whiskey.Area.Name;

            Order = new ReservationOrder();
            return Page();
        }

        public IActionResult OnPost(int WhiskeyId)
        {
            Order.CustomerName = User.FindFirst("fullname").Value;
            Order.Whiskey = whiskeyData.Getall().FirstOrDefault(a => a.Id == WhiskeyId);
            Whiskey = whiskeyData.GetById(WhiskeyId);

            NewSupply = Whiskey.Supply - Order.AmountBottles;
            whiskeyData.AddOrder(Order);
            whiskeyData.Update(Order.Whiskey, NewSupply);
            whiskeyData.Commit();
            TempData["Message"] = "Your order is placed!";

            return RedirectToPage("./Index");
        }
    }
}
