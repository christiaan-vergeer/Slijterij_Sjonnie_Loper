using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Slijterij_Sjonnie_Loper.Core
{
    public class ReservationOrder
    {
        public int ReservationId { get; set; }
        public virtual Whiskey Whiskey { get; set; }
        //Customer Name
        public string CustomerName { get; set; }
        [Required]
        public int AmountBottles { get; set; }
    }
}
