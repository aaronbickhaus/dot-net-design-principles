using System;
using System.Collections.Generic;
using System.Linq;

//Dependency Inversion principle demo
namespace DependencyInversionPrinciple
{
    public enum Relationship
	{
        Parent,
        Child,
        Sibling
	}

    public class Person
    {
        public string Name;
    }

    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }

    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
           return relations.Where(x=>x.Item1.Name.Equals(name) && x.Item2 == Relationship.Parent).Select(r=>r.Item3);
        }

        public List<(Person, Relationship, Person)> Relations => relations;
    }

    class Program
    {

        public Program(IRelationshipBrowser browser)
        {
            foreach(var p in browser.FindAllChildrenOf("john"))
            {
                //get relationship here
            }

        }

        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);
        }
    }
}
