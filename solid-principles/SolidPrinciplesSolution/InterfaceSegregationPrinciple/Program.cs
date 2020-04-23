using System;

//Demo for Intergration Segregation Principle
namespace InterfaceSegregationPrinciple
{

    public class Document
    {

    }

    public interface IMachine : IPrinter, IScanner, IFaxer
    {

    }
    public interface IPrinter
    {
        public void Print(Document d);
    }

    public interface IFaxer
    {
        public void Fax(Document d);
    }

    public interface IScanner
    {
        public void Scan(Document d);

        public class OldFashionedPrinter : IPrinter
        {

            public void Print(Document d)
            {
                throw new NotImplementedException();
            }
        }

        public class MultiFunctionPrinter : IMachine
        {
            public void Fax(Document d)
            {
                throw new NotImplementedException();
            }

            public void Print(Document d)
            {
                throw new NotImplementedException();
            }

            public void Scan(Document d)
            {
                throw new NotImplementedException();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
            }
        }
    }
}
