using System;
using System.Collections.Generic;
using System.Text;

namespace Slijterij_Sjonnie_Loper.Core
{
    public class location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Whiskey> Whiskeys {get;set;}

    }
}
