using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Slijterij_Sjonnie_Loper.Core
{
    public class Whiskey
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        // public string Area { get; set; }
        public virtual location Area { get; set; }
        [Required]
        public double Percentage { get; set; }
        [Required]
        public Kind Kind { get; set; }

        //[Required]
        //public byte[] Imagedata { get; set; }

        [Required]
        public double Price { get; set; }
        [Required]
        public int Supply { get; set; }

        //customers
        [Required]
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
