using Assets.Scripts.Coords;
using System.Collections.Generic;

namespace Assets.Scripts
{
    internal class Validator
    {
        private int width;

        public int Width
        {
            get => width;
            private set => width = value;
        }

        private int height;

        public int Height
        {
            get => height;
            private set => height = value;
        }

        public Validator(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        //Checks if a coord or a list of coords is inside the playarea
        public bool IsValidCoord(OffsetCoord offset)
        {
            if (1 <= offset.X && offset.X <= width - 2
                              && 1 <= offset.Y && offset.Y <= height - 2)
            {
                return true;
            }

            return false;
        }

        //public bool IsValidCoord(AxialCoord axial)
        //{
        //    return IsValidCoord(Hex.CellCubeToOffset(axial));
        //}

        public bool IsValidCoord(List<AxialCoord> axials)
        {
            foreach (var axial in axials)
            {
                if (!IsValidCoord(axial))
                {
                    return false;
                }
            }
            return true;
        }

        //Checks a list of coords to see if it has one or more coords inside the playarea.
        public bool HasValidCoord(List<AxialCoord> axials)
        {
            foreach (var axial in axials)
            {
                if (IsValidCoord(axial))
                {
                    return true;
                }
            }
            return false;
        }
    }
}