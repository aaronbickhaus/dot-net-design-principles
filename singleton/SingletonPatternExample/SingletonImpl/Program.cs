using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace SingletonImpl
{
    public interface IDatabase
    {
        int GetPopulationDatabase(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        public int GetPopulationDatabase(string name)
        {
            return capitals[name];
        }

        private SingletonDatabase() => capitals =
            File
            .ReadAllLines("capitals.txt")
            .Batch(2)
            .ToDictionary(
                list => list.ElementAt(0).Trim(),
                list => int.Parse(list.ElementAt(1))
                );
            

        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var db = SingletonDatabase.Instance;
            db.GetPopulationDatabase("China");
        }
    }
}
