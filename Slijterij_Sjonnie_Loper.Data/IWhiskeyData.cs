using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slijterij_Sjonnie_Loper.Core;

namespace Slijterij_Sjonnie_Loper.Data
{
    public interface IWhiskeyData
    {
        IEnumerable<Whiskey> Getall();
    }

    public class InMemoryWhiskeyData : IWhiskeyData
    {

        List<Whiskey> whiskeys;

        public InMemoryWhiskeyData()
        {
            whiskeys = new List<Whiskey>()
            {
                new Whiskey {Id = 1,Name = "The famous Grouse",Age = 30, Area = "lower france", Kind = Kind.blend, Percentage = 34, Price = 18.99, Supply = 50,isDeleted = false },
                new Whiskey {Id = 2,Name = "Jameson", Age = 120, Area = "britain", Kind = Kind.bourbon, Percentage = 40, Price = 39.99, Supply=12, isDeleted = false},
                new Whiskey {Id = 3,Name = "highland Baron Blended Whiskey", Age = 5 , Area = "highlands, obviously", Kind = Kind.single_malt, Percentage = 90, Price = 99.99, Supply = 150, isDeleted = false}
            };
        }

        public IEnumerable<Whiskey> Getall()
        {
            return from r in whiskeys orderby r.Name select r;
        }
    }
}
