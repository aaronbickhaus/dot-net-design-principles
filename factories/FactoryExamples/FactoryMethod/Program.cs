using System;

namespace FactoryMethod
{
    public class Point {

        private double x, y;

        //factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        //Factory method
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho*Math.Cos(theta), rho*Math.Sin(theta));
        }

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var point = Point.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(point);
        }
    }
}
