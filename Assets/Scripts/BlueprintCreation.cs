using Assets.Scripts.Coords;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public static class BlueprintCreation
    {
        public static Blueprint CreateRectangularBlueprint(int width, int height)
        {
            var bluePrint = ScriptableObject.CreateInstance<Blueprint>();

            var axialCoords = new List<AxialCoord>();

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    axialCoords.Add(new OffsetCoord(x, y));

            int[] arr = Enumerable.Range(0, 6).ToArray();

            bluePrint.cellInfoList = axialCoords.Select(PieceInfoFactory.CreateCellInfo).ToList();
            bluePrint.borderInfoList = axialCoords.SelectMany(ac => arr.Select(i => new BorderCoord(ac,
                    i)))
                .Distinct()
                .Select(PieceInfoFactory.CreateBorderInfo)
                .ToList();

            bluePrint.vertexInfoList = axialCoords.SelectMany(ac => arr.Select(i => new VertexCoord(ac,
                    i)))
                .Distinct()
                .Select(PieceInfoFactory.CreateVertexInfo)
                .ToList();

            return bluePrint;
        }
    }
}