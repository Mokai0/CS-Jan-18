using System;

namespace TreehouseDefense
{
    public class Path
    {
        private MapLocation[] pathLocations;

        public Path(MapLocation[] pathLocations)
        {
            this.pathLocations = pathLocations;
        }

        public bool IsOnPath(MapLocation mapLocation)
        {
            return Array.IndexOf(pathLocations, mapLocation) >= 0;
        }
    }
}