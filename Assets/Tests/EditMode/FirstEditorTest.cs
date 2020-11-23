using Assets.Scripts.Coords;
using NUnit.Framework;

namespace Assets.Tests.EditMode
{
    public class FirstEditorTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void AxialAndOffsetEqual()
        {
            var axial = new AxialCoord(0, 0);
            var offset = new OffsetCoord(0, 0);

            Assert.True(axial == offset);
        }
    }
}