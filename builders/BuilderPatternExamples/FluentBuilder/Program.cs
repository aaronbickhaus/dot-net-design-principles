using System;

namespace FluentBuilder
{
    public class Person
    {
        public string Name, Position;

        public override string ToString()
        {
            return $"{nameof(Name)} : {Name}, {nameof(Position)} : {Position}";
        }

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();

    }

    public class PersonInforBuilder<SELF> : PersonBuilder where SELF : PersonInforBuilder<SELF>
    {
        

        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF) this;
        }
    }

    public abstract class PersonBuilder
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }
    public class PersonJobBuilder<SELF> : PersonInforBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorkAsA(string position)
        {
            return (SELF)this;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Person.New.Called("Aaron").WorkAsA("Software Engineer").Build());
        }
    }
}
