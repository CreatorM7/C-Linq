using System;
using System.Collections.Generic;
using System.Linq;

namespace C_sharp_HT_Linq
{
    public static class CustomLinqMethod
    {
        public static T BeforeLast<T>(this IEnumerable<T> source)
        {
            T beforeLast = default;
            bool hasLast = false;

            foreach (T item in source)
            {
                if (hasLast)
                {
                    return beforeLast;
                }

                beforeLast = item;
                hasLast = true;
            }

            throw new InvalidOperationException("Empty");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Enumerable.Range(1, 100).ToArray();

            var oddNumbers = numbers.Where(n => n % 2 == 1);

            var squares = oddNumbers.Select(n => n * n);

            int sum = numbers.Sum();

            List<Person> people = new List<Person>();
            for (int i = 0; i < 20; i++)
            {
                people.Add(new Person("Person" + i, i + 1, i + 20));
            }

            var filteredPeople = people.Where(p => p.Age > 20);
            var filteredNames = filteredPeople.Select(p => p.Name);
            var filteredAnonymous = filteredPeople
                .Select(p => new { p.Id, p.Name })
                .OrderBy(p => p.Name);
            var groupedAnonymous = filteredPeople
                .GroupBy(p => p.Age)
                .ToDictionary(g => g.Key, g => g.Select(p => new { p.Id, p.Name }).ToList());

            var beforeLast = numbers.BeforeLast();
        }
    }


    class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }

        public Person(string name, int id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
    }
}
