using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Slijterij_Sjonnie_Loper.Core
{
    public class Whiskey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
       // public string Area { get; set; }
        public virtual location Area { get; set; }
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
        [Display(Name = "Blend")]
        blend = 1,
        [Display(Name = "Single Malt")] 
        single_malt = 2,
        [Display(Name = "Bourbon")]
        bourbon = 3

    }
}
