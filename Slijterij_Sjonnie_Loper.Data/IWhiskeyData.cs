﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Slijterij_Sjonnie_Loper.Core;

namespace Slijterij_Sjonnie_Loper.Data
{
    public interface IWhiskeyData
    {
        IEnumerable<Whiskey> Getall();
        IEnumerable<Whiskey> GetAllByFind(string searchname, int searchage, string searcharea,Core.Kind searchtype, int searchper);
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
                new Whiskey {Id = 3,Name = "highland Baron Blended Whiskey", Age = 5 , Area = "highlands, obviously", Kind = Kind.single_malt, Percentage = 90, Price = 99.99, Supply = 150, isDeleted = false},
                new Whiskey {Id = 4,Name = "Glen Talloch", Age = 46 , Area = "holland", Kind = Kind.bourbon, Percentage = 30, Price = 15.50, Supply = 25, isDeleted = false},
                new Whiskey {Id = 5,Name = "Jura journey", Age = 35 , Area = "Japan", Kind = Kind.bourbon, Percentage = 30, Price = 99.99, Supply = 150, isDeleted = false},
                new Whiskey {Id = 6,Name = "Ballentine´s", Age = 73 , Area = "America", Kind = Kind.blend, Percentage = 90, Price = 25.00, Supply = 34, isDeleted = false},
                new Whiskey {Id = 7,Name = "Grant´s", Age = 9 , Area = "Holland", Kind = Kind.single_malt, Percentage = 90, Price = 15.00, Supply = 28, isDeleted = false},
                new Whiskey {Id = 8,Name = "Johnnie Walker Red Label", Age = 100 , Area = "Lower France", Kind = Kind.single_malt, Percentage = 45, Price = 69.99, Supply = 93, isDeleted = false},
                new Whiskey {Id = 9,Name = "Talisker", Age = 62 , Area = "Britain", Kind = Kind.blend, Percentage = 45, Price = 12.00, Supply = 1, isDeleted = false},
                new Whiskey {Id = 10,Name = "Singleton Malt Master", Age = 93 , Area = "Japan", Kind = Kind.blend, Percentage = 30, Price = 7.99, Supply = 27, isDeleted = false},
                new Whiskey {Id = 11,Name = "Jameson Caskmates", Age = 140 , Area = "South Afrika", Kind = Kind.single_malt, Percentage = 45, Price = 99.99, Supply = 100, isDeleted = false},
                new Whiskey {Id = 12,Name = "Chivas Regal", Age = 12 , Area = "Britain", Kind = Kind.bourbon, Percentage = 45, Price = 250.00, Supply = 300, isDeleted = false}

            };
        }

        public IEnumerable<Whiskey> Getall()
        {
            return from r in whiskeys orderby r.Name select r;
        }

        public IEnumerable<Whiskey> GetAllByFind(string SearchName, int SearchAge, string SearchArea, Core.Kind SearchType, int SearchPercentage)
        {
            return from r in whiskeys where
                   (string.IsNullOrEmpty(SearchName) || r.Name.Contains(SearchName, StringComparison.OrdinalIgnoreCase)) &&
                   (SearchAge == 0 || r.Age == SearchAge) &&
                   (string.IsNullOrEmpty(SearchArea) || r.Area.Contains(SearchArea, StringComparison.OrdinalIgnoreCase)) &&
                   (SearchPercentage == 0 || r.Percentage == SearchPercentage) &&
                   (SearchType == 0 || r.Kind == SearchType)
                   orderby r.Name 
                   select r;
        }

    }
}
