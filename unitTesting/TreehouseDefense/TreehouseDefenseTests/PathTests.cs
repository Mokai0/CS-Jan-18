using Xunit;

namespace TreehouseDefense.Tests
{
    public class PathTests
    {
        [Fact]
        public void MapLoactionIsOnPath()
        {
            var map = new Map(3, 3);

            MapLocation[] pathLocations =
            {
                new MapLocation(0,1,map),
                new MapLocation(1,1,map),
                new MapLocation(2,1,map)
            };

            var target = new Path(pathLocations);

            Assert.True(target.IsOnPath(new MapLocation(0, 1, map)));
        }
    }
}
