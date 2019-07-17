using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NineEntertainment.Models;

namespace NineEntertainment.Bisiness_Interfaces
{
    public interface IPersonService
    {
        List<Person> GetPersonList();
        List<Person> GetPersonList(string race);
        PersonAgeOutput CalculateAge();
        IEnumerable<object> GetPersonListByRace();
    }
}
