using System;
using System.Collections.Generic;

namespace SingleResponsibility
{
   //Seperate Journal and Persistence to enforce single responsibility principle

    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count} : { text }");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }
    }

    public class Persistence
    {
        public void SaveToFile()
        {

        }

        public void DeleteFile()
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("testing");
            j.AddEntry("ello");


            var p = new Persistence();
           
        }
    }
}
