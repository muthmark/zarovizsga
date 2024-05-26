using System;
using System.Collections.Generic;
using System.Linq;

namespace Journeys
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<JourneyModel> journeys = JourneyModel.LoadFromCsv("journeys.csv").ToList();
            //List<JourneyModel> journeys = JourneyModel.LoadFromJson("journeys.json").ToList();

            Console.WriteLine("6. feladat: ");
            var legkorábbi = journeys.Where(j => j.Vehicle.Type == "repülőgép").OrderBy(j => j.Departure).First();
            foreach (JourneyModel journey in journeys.Where(j => j.Vehicle.Type == "repülőgép"))
            {
                if (journey == legkorábbi)
                {
                    Console.WriteLine($"\t{journey.Country} - legkorábbi ({journey.Departure.ToShortDateString()})");
                }
                else
                {
                    Console.WriteLine($"\t{journey.Country}");
                }
            }


            Console.WriteLine("7. feladat: ");
            foreach (var journey in journeys.GroupBy(x=>x.Vehicle.Type).Select(x=> new 
                    {
                        Vehicle = x.Key,
                        Count = x.Count(),
                        Independent = x.Any(y=>y.Capacity is null),
                        Sum = x.Sum(y=>y.Capacity),
                    }))
            {
                if (journey.Independent) { Console.WriteLine($"\t{journey.Vehicle} : {journey.Count} utazás, önálló szervezés"), continue; };
                
                Console.WriteLine($"\t{journey.Vehicle} : {journey.Count} utazás, férőhely összesen {journey.Sum} fő");
                
            }
            Console.ReadLine();
        }
    }
}
