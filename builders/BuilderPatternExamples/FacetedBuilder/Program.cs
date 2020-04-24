using System;

namespace FacetedBuilder
{
    public class Person
    {
        //address
        public string StreetAddress, Postcode, City;

        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{StreetAddress}, {Postcode}, {City},  {CompanyName}, {Position}, {AnnualIncome}";
        }
    }

    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.Person = person;
        }

{        public PersonAddressBuilder At(string streetAddress)
        {
            Person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postcode)
        {
            Person.Postcode = postcode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            Person.City = city;
            return this;
        }
    }

    public class PersonBuilder //facade
    {
        //reference
        protected Person Person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(Person);
        public PersonAddressBuilder Lives => new PersonAddressBuilder(Person);
    }

    public class PersonJobBuilder : PersonBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.Person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            Person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
             Person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            Person.AnnualIncome = amount;
            return this;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
           var pb = new PersonBuilder();
            var person = pb
                .Lives
                .At("123 street")
                .In("Denver")
                .WithPostCode("123456")
                .Works
                .At("Heap Wolf")
                .AsA("Engineer")
                .Earning(100000);

            Console.WriteLine(pb.ToString());
        }
    }
}
