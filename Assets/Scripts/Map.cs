using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Map {
    public Cell[,] cells;
    public Border[,][] borders;
    public Vertex[,][] vertices;

    public Map(int _width, int _height) {
        cells = new Cell[_width, _height];
        borders = new Border[_width, _height][];
        vertices = new Vertex[_width, _height][];
        for (int x = 0; x < _width; x++) {
            for (int y = 0; y < _height; y++) {
                borders[x, y] = new Border[3];
                vertices[x, y] = new Vertex[2];
            }
        }
    }
}
