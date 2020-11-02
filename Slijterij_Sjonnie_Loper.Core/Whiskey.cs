using System;
using System.Collections.Generic;
using System.Text;

namespace Slijterij_Sjonnie_Loper.Core
{
    public class Whiskey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Area { get; set; }
        public double Percentage { get; set; }
        public Kind Kind { get; set; }

        //public image
        public double Price { get; set; }
        public int Supply { get; set; }

        //customers
        public bool isDeleted { get; set; }
    }

    public enum Kind
    {
        blend,
        single_malt,
        bourbon

    }
}
