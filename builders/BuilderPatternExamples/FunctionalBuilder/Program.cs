﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace FunctionalBuilder
{
    public class Person
    {
        public string Name, Position;
    }

    public abstract class FunctionalBuilder<TSubject, TSelf>
        where TSelf : FunctionalBuilder<TSubject, TSelf>
        where TSubject : new()
    {

        private readonly List<Func<Person, Person>> actions = new List<Func<Person, Person>>();

        public TSelf Do(Action<Person> action) => AddAction(action);

        public Person Build() => actions.Aggregate(new Person(), (p, f) => f(p));

        private TSelf AddAction(Action<Person> action)
        {
            actions.Add(p =>
            {
                action(p);

                return p;
            });
            return (TSelf) this;
        }
    }
    public sealed class PersonBuilder :FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name) => Do(p => p.Name = name);
    }

    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAs(this PersonBuilder builder, string position) => builder.Do(p => p.Position = position);
    }

    class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonBuilder()
                 .Called("Aaron B")
                 .WorksAs("Developer")
                 .Build();
            Console.WriteLine(person.Name + " " + person.Position);
        }
    }
}
