using Eszaki_kozephegyseg_kilatoi;


internal class Program
{
    private static void Main(string[] args)
    {

        List<LocationModel> locations = new List<LocationModel>();
        List<ViewpointModel> viewpoints = new List<ViewpointModel>();

        locations = LocationModel.loadLocations("locations.csv");
        viewpoints = ViewpointModel.loadViewpoints("viewpoints.csv");

        // legmagasabb kilátó keresés
        ViewpointModel highestViewpoint = viewpoints[0];
        foreach (var viewpoint in viewpoints)
        {
            if (viewpoint.height > highestViewpoint.height)
            {
                highestViewpoint = viewpoint;
            }
        }
        string locationName = "";
        foreach (var location in locations)
        {
            if (location.id == highestViewpoint.location)
            {
                locationName = location.location;
            }
        }
        Console.WriteLine("6. feladat:");
        Console.WriteLine("\tMegnevezés: {0}", highestViewpoint.viewpointName);
        Console.WriteLine("\tHegy neve: {0}", highestViewpoint.mountain);
        Console.WriteLine("\tMagasság: {0}; Épült: {1}", highestViewpoint.height, highestViewpoint.built);
        Console.WriteLine("\tHegység neve: {0}", locationName);
    }
}