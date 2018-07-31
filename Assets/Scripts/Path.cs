using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public struct Path {
    public int[] dirs;

    public Path(int start, int end) {
        dirs = new int[2];
        dirs[0] = start;
        dirs[1] = end;
        return;
    }

    public Path(int[] _dirs) {
        dirs = _dirs;
    }



    public static bool operator ==(Path a, Path b) {
        return (a[0] == b[0] && a[1] == b[1]);
    }

    public static bool operator !=(Path a, Path b) {
        return (a[0] != b[0] || a[1] != b[1]);
    }


    //This is Bad
    public override bool Equals(object o) {
        return true;
    }

    public override int GetHashCode() {
        return 0;
    }
    //End of badness



    public int Start {
        get { return dirs[0]; }
        set { dirs[0] = value; }
    }

    public int End {
        get { return dirs[1]; }
        set { dirs[1] = value; }
    }

    public int this[int index] {
        get { return dirs[index]; }
        set { dirs[index] = value; }
    }

    public bool IsStraight {
        get {
            return Math.Abs(dirs[1] - dirs[0]) == 3 ? true : false;
        }
        private set { }
    }

    public bool IsValid {
        get {
            int difference = AbsDifference;
            if (1 < difference && difference < 5)
                return true;
            else
                return false;

        }
        private set { }
    }

    public Path Sorted {
        get {

            int[] sortedDirs = dirs;
            Array.Sort(sortedDirs);
            return new Path(sortedDirs);
        }
        private set { }
    }

    public int Difference {
        get { return (dirs[1] - dirs[0]); }
        private set { }
    }
    public int AbsDifference {
        get { return Math.Abs(dirs[1] - dirs[0]); }
        private set { }
    }
}

