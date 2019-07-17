using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NineEntertainment.Models
{
    /// <summary>
    /// Person Entity
    /// </summary>
    public abstract class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string Race { get; set; }
        public double Height
        {
            get => CalculateHeight();
        }
        //Abstract method to calculate height
        protected abstract double CalculateHeight();
    }
}