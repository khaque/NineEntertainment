using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NineEntertainment.Models
{
    public class Saxons : Person
    {
        protected override double CalculateHeight()
        {
            return Math.Round((1.5 + (Age * 0.45)), 2);
        }
    }
}