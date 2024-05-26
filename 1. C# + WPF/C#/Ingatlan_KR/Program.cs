using System;
using System.Linq;
using System.Collections.Generic;

namespace RealEstates
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Ingatlanok";

            //List<Ad> hirdetések = Ad.LoadFromRestApi("http://localhost:5000/api/ingatlan").ToList();
            List<Ad> hirdetések = Ad.LoadFromCsv("realestates.csv").ToList();
            //List<Ad> hirdetések = Ad.LoadFromJson("realestates.json").ToList();
            Console.WriteLine("1. Földszinti ingatlanok átlagos alapterülete: " +
                                $"{hirdetések.Where(x => x.Floors == 0).Average(x => x.Area):F2} m2");


            var adat = hirdetések.Where(x => x.FreeOfCharge).OrderBy(x => x.DistanceTo(47.4164220114023, 19.066342425796986)).First();
            Console.WriteLine("2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai: ");
            Console.WriteLine($"\tEladó neve     : {adat.Seller.Name}");
            Console.WriteLine($"\tEladó telefonja: {adat.Seller.Phone}");
            Console.WriteLine($"\tAlapterület    : {adat.Area}");
            Console.WriteLine($"\tSzobák száma   : {adat.Rooms}");



            Console.ReadKey();
        }
    }
}
