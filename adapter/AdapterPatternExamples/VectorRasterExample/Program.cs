using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VectorRasterExample
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Line
    {
        public Point Start, End;
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
    }

    public class VectorObject : Collection<Line>
    {

    }

    public class Rectangle : VectorObject
    {
        public Rectangle(int x, int y, int width, int height)
        {
            Add(new Line(new Point(x, y), new Point(x + width, y)));
        }
    }

    public class LineToPointAdapter : Collection<Point>
    {
        private static int count;

        public LineToPointAdapter(Line line)
        {
            Console.WriteLine($"{++count}: {line.Start.X}  {line.Start.Y}");
        }
    }

    class Program
    {
        private static readonly List<VectorObject> vectorObjects = new List<VectorObject>()
        {
            new Rectangle(1,1,10,10),
            new Rectangle(1,1,10,10)
        };
       

        public static void DrawPoint(Point p)
        {
            Console.WriteLine(".");
        }

        static void Main(string[] args)
        {
           
        }
    }
}
