using System;
using System.Collections.Generic;
using System.Text;

namespace Slijterij_Sjonnie_Loper.Core
{
    public class ReservationOrder
    {
        public int CustomerId { get; set; }
        public int ReservationId { get; set; }
        public int AmountBottles { get; set; }
    }
}
