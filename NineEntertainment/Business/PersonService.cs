using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

using NineEntertainment.Models;
using NineEntertainment.Bisiness_Interfaces;

namespace NineEntertainment.Business
{
    /// <summary>
    /// Person Related Business Layer
    /// </summary>
    public class PersonService :IPersonService
    {
        /// <summary>
        /// Return All Person List
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPersonList()
        {
            return PopulatePersonList();
        }

        /// <summary>
        /// Get Person list for a specific race whose age is even
        /// </summary>
        /// <param name="race"></param>
        /// <returns></returns>
        public List<Person> GetPersonList(string race)
        {
            return PopulatePersonList().Where(r => r.Race == race && r.Age % 2 == 0).OrderBy(r => r.Age).ToList();
        }
        /// <summary>
        /// Populate Person List
        /// </summary>
        /// <returns></returns>
        private List<Person> PopulatePersonList()
        {
            List<Person> people = new List<Person>();

            Random rnd = new Random();
            

            for (int i = 0; i < 10000; i++)
            {

                var randomRace = rnd.Next(1, 5);//Get Random race
                Race race = (Race)randomRace;

                switch (race)
                {
                    case Race.Angles:

                        people.Add(new Angles()
                        {
                            Name = "Person #" + i.ToString(),
                            Age = rnd.Next(1, 99) + 1, //add 1 year,
                            Race = "Angles"
                        });

                        break;

                    case Race.Saxons:

                        people.Add(new Saxons()
                        {
                            Name = "Person #" + i.ToString(),
                            Age = rnd.Next(1, 99) + 1, //add 1 year,
                            Race = "Saxons"
                        });

                        break;

                    case Race.Jutes:

                        people.Add(new Jutes()
                        {
                            Name = "Person #" + i.ToString(),
                            Age = rnd.Next(1, 99) + 1, //add 1 year,
                            Race = "Jutes"
                        });

                        break;

                    case Race.Hawaiian:

                        people.Add(new Hawaiian()
                        {
                            Name = "Person #" + i.ToString(),
                            Age = rnd.Next(1, 99) + 1, //add 1 year
                            Race = "Hawaiian"
                        });

                        break;
                }
            }

            return people;
        }

        /// <summary>
        /// Find Average, Minimum and Maximum Age
        /// </summary>
        /// <returns></returns>
        public PersonAgeOutput CalculateAge()
        {
            var personList = PopulatePersonList();
            PersonAgeOutput output = new PersonAgeOutput();
            output.AvergeAge = Math.Round(personList.Average(x => x.Age),2);
            output.MaxAge = personList.Max(x => x.Age);
            output.MinAge = personList.Min(x => x.Age);

            return output;
        }

        /// <summary>
        /// Count number of person for each Race
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetPersonListByRace()
        {
            var personList = PopulatePersonList();
            var output = personList
                        .GroupBy(g => g.Race)
                        .Select(g => new
                           {
                               Race = g.Key,
                               Total = g.Count()
                           });

            return output;
        }
    }
}