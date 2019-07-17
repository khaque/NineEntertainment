using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NineEntertainment.Models
{
    public class Hawaiian : Person
    {
        protected override double CalculateHeight()
        {
            return Math.Round((1.7 + ((Age + 2) * 0.23)), 2);
        }
    }
}