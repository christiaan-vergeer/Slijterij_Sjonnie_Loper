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
        IEnumerable<Whiskey> GetAllByFind(string searchname, int searchage, int SearchArea, Core.Kind SearchType, int SearchPercentage);
        IEnumerable<location> GetLocations();
        Whiskey GetById(int id);
        Whiskey Add(Whiskey newWhiskey);
        Whiskey Edit(Whiskey editwhiskey, int searcharea);
        Whiskey Delete(int id);
        Whiskey RevDelete(int id);
        int Commit();
        ReservationOrder AddOrder(ReservationOrder newOrder);
        IEnumerable<ReservationOrder> GetOrders();
    }

    public class InMemoryWhiskeyData : IWhiskeyData
    {
        List<location> locations;

        List<Whiskey> whiskeys;

        List<ReservationOrder> orders;

        //List<staff> staffs;

        public InMemoryWhiskeyData()
        {
            locations = new List<location>()
            {
                new location {Id = 1, Name = "Lower France"},
                new location {Id = 2, Name = "Britain"},
                new location {Id = 3, Name = "Japan"},
                new location {Id = 4, Name = "Holland"},
                new location {Id = 5, Name = "America"},
                new location {Id = 6, Name = "South Afrika"}
            };

            whiskeys = new List<Whiskey>()
            {
                new Whiskey {Id = 1,Name = "The famous Grouse",Age = 30, Area = locations.FirstOrDefault(r => r.Id == 1), Kind = Kind.blend, Percentage = 34, Price = 18.99, Supply = 50,isDeleted = false },
                new Whiskey {Id = 2,Name = "Jameson", Age = 120, Area = locations.FirstOrDefault(r => r.Id == 2),Kind = Kind.bourbon, Percentage = 40, Price = 39.99, Supply=12, isDeleted = false},
                new Whiskey {Id = 3,Name = "highland Baron Blended Whiskey", Age = 5 ,Area = locations.FirstOrDefault(r => r.Id == 3), Kind = Kind.single_malt, Percentage = 90, Price = 99.99, Supply = 150, isDeleted = false},
                new Whiskey {Id = 4,Name = "Glen Talloch", Age = 46 , Area = locations.FirstOrDefault(r => r.Id == 4), Kind = Kind.bourbon, Percentage = 30, Price = 15.50, Supply = 25, isDeleted = false},
                new Whiskey {Id = 5,Name = "Jura journey", Age = 35 , Area = locations.FirstOrDefault(r => r.Id == 3), Kind = Kind.bourbon, Percentage = 30, Price = 99.99, Supply = 150, isDeleted = false},
                new Whiskey {Id = 6,Name = "Ballentine´s", Age = 73 , Area = locations.FirstOrDefault(r => r.Id == 5), Kind = Kind.blend, Percentage = 90, Price = 25.00, Supply = 34, isDeleted = false},
                new Whiskey {Id = 7,Name = "Grant´s", Age = 9 , Area = locations.FirstOrDefault(r => r.Id == 4), Kind = Kind.single_malt, Percentage = 90, Price = 15.00, Supply = 28, isDeleted = false},
                new Whiskey {Id = 8,Name = "Johnnie Walker Red Label", Age = 100 , Area = locations.FirstOrDefault(r => r.Id == 1), Kind = Kind.single_malt, Percentage = 45, Price = 69.99, Supply = 93, isDeleted = false},
                new Whiskey {Id = 9,Name = "Talisker", Age = 62 , Area = locations.FirstOrDefault(r => r.Id == 2), Kind = Kind.blend, Percentage = 45, Price = 12.00, Supply = 1, isDeleted = false},
                new Whiskey {Id = 10,Name = "Singleton Malt Master", Age = 93 , Area = locations.FirstOrDefault(r => r.Id == 3), Kind = Kind.blend, Percentage = 30, Price = 7.99, Supply = 27, isDeleted = false},
                new Whiskey {Id = 11,Name = "Jameson Caskmates", Age = 140 , Area = locations.FirstOrDefault(r => r.Id == 6), Kind = Kind.single_malt, Percentage = 45, Price = 99.99, Supply = 100, isDeleted = false},
                new Whiskey {Id = 12,Name = "Chivas Regal", Age = 12 , Area = locations.FirstOrDefault(r => r.Id == 2), Kind = Kind.bourbon, Percentage = 45, Price = 250.00, Supply = 300, isDeleted = false}

            };

            orders = new List<ReservationOrder>()
            {
                new ReservationOrder {ReservationId = 1, Whiskey = whiskeys.FirstOrDefault(r => r.Id == 8), AmountBottles = 2}
            };

        }

        public IEnumerable<Whiskey> Getall()
        {
            return from r in whiskeys orderby r.Name select r;
        }

        public IEnumerable<location> GetLocations()
        {
            return from r in locations orderby r.Id select r;
        }

        public IEnumerable<Whiskey> GetAllByFind(string SearchName, int SearchAge, int SearchArea, Core.Kind SearchType, int SearchPercentage)
        {
            return from r in whiskeys where
                   (string.IsNullOrEmpty(SearchName) || r.Name.Contains(SearchName, StringComparison.OrdinalIgnoreCase)) &&
                   (SearchAge == 0 || r.Age == SearchAge) &&
                   (SearchArea == 0 || r.Area.Id == SearchArea) &&
                   //(string.IsNullOrEmpty(SearchArea) || r.Area.Contains(SearchArea, StringComparison.OrdinalIgnoreCase)) &&
                   (SearchPercentage == 0 || r.Percentage == SearchPercentage) &&
                   (SearchType == 0 || r.Kind == SearchType)
                   orderby r.Name 
                   select r;
        }

        public Whiskey GetById(int id)
        {
            return whiskeys.SingleOrDefault(r => r.Id == id);
        }

        public Whiskey Add(Whiskey newWhiskey)
        {
            whiskeys.Add(newWhiskey);
            newWhiskey.Id = whiskeys.Max(r => r.Id) + 1;
            newWhiskey.isDeleted = false;
            return newWhiskey;
        }

        public Whiskey Edit(Whiskey editwhiskey, int searcharea)
        {
            int ID = editwhiskey.Id;
            editwhiskey.Area = locations.FirstOrDefault(i => i.Id == searcharea);
            whiskeys.Remove(whiskeys.FirstOrDefault(o => o.Id == ID));
            whiskeys.Add(editwhiskey);
            return editwhiskey;
        }

        public Whiskey Delete(int id)
        {
            var wiskey = GetById(id);
            wiskey.isDeleted = true;
            whiskeys.Remove(whiskeys.FirstOrDefault(o => o.Id == id));
            whiskeys.Add(wiskey);
            return wiskey;
        }

        public Whiskey RevDelete(int id)
        {
            var wiskey = GetById(id);
            wiskey.isDeleted = false;
            whiskeys.Remove(whiskeys.FirstOrDefault(o => o.Id == id));
            whiskeys.Add(wiskey);
            return wiskey;
        }

        public int Commit()
        {
            return 0;
        }

        public ReservationOrder AddOrder(ReservationOrder newOrder)
        {
            orders.Add(newOrder);
            newOrder.ReservationId = orders.Max(r => r.ReservationId) + 1;
            return newOrder;
        }

        public IEnumerable<ReservationOrder> GetOrders()
        {
            return from r in orders
                   orderby r.ReservationId
                   select r;
        }
    }
}
