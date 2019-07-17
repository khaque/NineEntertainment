using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NineEntertainment.Models
{
    public class Jutes : Person
    {
        protected override double CalculateHeight()
        {
            return Math.Round(((Age * 1.6) / 2), 2);
        }
    }
}