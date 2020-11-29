using Assets.Scripts.Coords;
using NUnit.Framework;
using System;
using UnityEngine;

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

        [Test]
        public void NeighborsVertexesAreEqual(
            [Random(-9999, 9999, 3)] int axialX,
            [Random(-9999, 9999, 3)] int axialY,
            [NUnit.Framework.Range(0, 5)] int vertexIndex,
            [Values(0, 1)] int neighborIndexOffset)
        {
            var axial = new AxialCoord(axialX, axialY);
            var vertex = new VertexCoord(axialX, axialY, vertexIndex);
            var neighborAxial = axial.Neighbors[(vertexIndex - 1 + neighborIndexOffset + 6) % 6];
            var neighborVertexIndex = (vertexIndex + (2 - neighborIndexOffset * 4) + 6) % 6;
            var neighborVertexCoord = new VertexCoord(neighborAxial, neighborVertexIndex);

            Debug.Log(axial);
            Debug.Log(vertexIndex);
            Debug.Log(vertex);

            var strut = neighborIndexOffset.ToString();

            Debug.Log(neighborIndexOffset);
            Debug.Log(neighborAxial);
            Debug.Log(neighborVertexIndex);
            Debug.Log(neighborVertexCoord);

            Assert.True(vertex == neighborVertexCoord);
        }
    }
}