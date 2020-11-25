using Assets.Scripts.Coords;
using NUnit.Framework;

namespace Assets.Tests.EditMode
{
    public class CoordinateTests
    {
        [TestCase(0, 0, 0, 0, true)]
        [TestCase(-1, 0, -1, -1, true)]
        [TestCase(1, 1, 1, 1, true)]
        [TestCase(0, 5, 0, 5, true)]
        [TestCase(2, 2, 2, 3, true)]
        [TestCase(0, 0, 0, 1000, false)]
        public void AxialAndOffsetEqual(int axialX, int axialY, int offsetX, int offsetY, bool expected)
        {
            var axial = new AxialCoord(axialX, axialY);
            var offset = new OffsetCoord(offsetX, offsetY);

            Assert.True(axial == offset == expected);
        }
    }
}