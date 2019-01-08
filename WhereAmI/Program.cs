using System;
using System.Device.Location;

namespace WhereAmI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting GeoCoordinate Watcher...");

            var watcher = new GeoCoordinateWatcher();

            watcher.StatusChanged += (sender, eventArgs) => {
                Console.WriteLine($"GeoCoordinateWatcher:StatusChanged:{eventArgs.Status}");
            };

            watcher.PositionChanged += (sender, eventArgs) => {
                Console.WriteLine($"GeoCoodinateWatcher:PositionChanged:{eventArgs.Position.Location}");
            };

            watcher.MovementThreshold = 100; //100 meters of change in position is required for the event to be triggered

            watcher.Start();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
