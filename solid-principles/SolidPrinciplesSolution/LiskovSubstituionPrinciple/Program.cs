using System;

//Demo for LiskovPrinciple which states you should be able to cast to your baseclass and things should still work correctly
namespace LiskovSubstituionPrinciple
{

    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

    }

    public class Square : Rectangle
    {
        public override int Width
        {
            set
            {
                base.Width = base.Height = value;
            }
        }

        public override int Height
        {
            set
            {
                base.Height = base.Width = value;
            }
        }
    }

    class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle();

            Console.WriteLine($"{rc} has area {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {Area(sq)}");
        }
    }
}
