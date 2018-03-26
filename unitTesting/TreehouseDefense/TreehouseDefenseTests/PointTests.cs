using Xunit;
using TreehouseDefense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreehouseDefense.Tests
{
    public class PointTests
    {
        [Fact()]
        public void PointTest()
        {
            int x = 5;
            int y = 6;
            var point = new Point(x, y);
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }

        [Fact()]
        public void DistanceToTest()
        {
            var point = new Point(6, 8);
            var target = new Point(3, 1);

            var expected = 7.62;
            var actual = target.DistanceTo(point);

            //Remember that decimals are floating point numbers and because of that they aren't exact. The third parameter here is used to guage the precision of this test.
            Assert.Equal(expected, actual, 2);
        }

        [Fact()]
        public void DistanceToTestPythagTriple()
        {
            var point = new Point(3, 4);
            var target = new Point(0, 0);

            var expected = 5.0;
            var actual = target.DistanceTo(point);

            //Remember that decimals are floating point numbers and because of that they aren't exact. The third parameter here is used to guage the precision of this test.
            Assert.Equal(expected, actual, 2);
        }

        [Fact()]
        public void DistanceTo_SamePoint()
        {
            var point = new Point(3, 4);
            var target = new Point(3, 4);

            var expected = 0;
            var actual = target.DistanceTo(point);

            //Remember that decimals are floating point numbers and because of that they aren't exact. The third parameter here is used to guage the precision of this test.
            Assert.Equal(expected, actual, 2);
        }
    }
}