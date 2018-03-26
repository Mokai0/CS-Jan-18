using System;
using System.Linq;

namespace TreehouseDefense
{
    public class Path
    {
        private MapLocation[] _path;

        public Path(MapLocation[] pathLocations)
        {
            _path = pathLocations;
        }

        public bool IsOnPath(MapLocation mapLocation) => _path.Contains(mapLocation);
    }
}