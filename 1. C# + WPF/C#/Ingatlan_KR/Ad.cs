using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace RealEstates
{
    public class Ad
    {
        public int Id { get; set; }
        public int Rooms { get; set; }
        public int Area { get; set; }
        public int Floors { get; set; }
        public Category Category { get; set; }
        public Seller Seller { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get {
                return String.Format($"{this.lat},${this.lon}");
            } 
            set
            {
                this.lat = Convert.ToDouble(value.Split(",")[0].Replace(".", ","));
                this.lon = Convert.ToDouble(value.Split(",")[1].Replace(".", ","));
            }
        }
        private double lat { get; set; }
        private double lon { get; set; }
        public DateTime CreateAt { get; set; }
        public bool FreeOfCharge { get; set; }

        public Ad()
        {

        }
        public Ad(string sor)
        {
            string[] adatok = sor.Split(";");
            this.Id = Convert.ToInt32(adatok[0]);
            this.Rooms = Convert.ToInt32(adatok[1]);
            this.LatLong = adatok[2];
            this.Floors = Convert.ToInt32(adatok[3]);
            this.Area = Convert.ToInt32(adatok[4]);
            this.Description = adatok[5];
            this.FreeOfCharge = adatok[6] == "1";
            this.ImageUrl = adatok[7];
            this.CreateAt = Convert.ToDateTime(adatok[8]);
            this.Seller = new Seller() { Id = Convert.ToInt32(adatok[9]), Name = adatok[10], Phone = adatok[11] };
            this.Category = new Category() { Id = Convert.ToInt32(adatok[12]), Name = adatok[13] };
        }

        public static IEnumerable<Ad> LoadFromCsv(string filename)
        {
            foreach(string sor in  File.ReadAllLines(filename).ToList().Skip(1) )
            {
                yield return new Ad(sor);
            }
        }

        public static IEnumerable<Ad> LoadFromJson(string filename)
        {
            return JsonConvert.DeserializeObject<Ad[]>(File.ReadAllText(filename));
        }

        public double DistanceTo(double lat, double lon)
        {
            double dx = Math.Abs(lat - this.lat);
            double dy = Math.Abs(lon - this.lon);
            return Math.Sqrt(Math.Pow(dx, 2)+Math.Pow(dy, 2));
        }
    }
}