﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Slijterij_Sjonnie_Loper.Core
{
    public class ReservationOrder
    {
        public int ReservationId { get; set; }
        public int WhiskeyId { get; set; }
        public string CustomerName { get; set; }
        public int AmountBottles { get; set; }
    }
}