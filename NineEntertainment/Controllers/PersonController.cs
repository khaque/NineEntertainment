using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

using NineEntertainment.Bisiness_Interfaces;
using NineEntertainment.Business;
using NineEntertainment.Models;

namespace NineEntertainment.Controllers
{
    /// <summary>
    /// Person Controller
    /// </summary>
    public class PersonController : ApiController
    {
        private IPersonService _personService;
        private List<Person> _people;

        /// <summary>
        /// Initialization
        /// </summary>
        public PersonController()
        {
            //initialize service when using IOC it can be done through Constructor Injection
            _personService = new PersonService();
        }

        /// <summary>
        /// API end point to get total number of person
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("api/GetTotalPerson")]
        public IHttpActionResult GetTotalPersonCount()
        {
            try
            {
                _people = _personService.GetPersonList("Angles");
                var output = _people.Count();
                return Json(output);
            }
            catch (Exception ex)
            {
                //Write Log and Return Error Code
                return BadRequest("GetTotalPersonCount method error " + ex.Message);
            }
        }

        /// <summary>
        /// API end point to get average, maximum and minimum age
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetCalculatedAge")]
        public IHttpActionResult GetCalculatedAge()
        {
            try
            {
                var output = _personService.CalculateAge();
                return Json(output);
            }
            catch (Exception ex)
            {
                //Write Log 
                return BadRequest("GetCalculatedAge Method Error" + ex.Message);
            }
        }

        /// <summary>
        /// API end point to get list of person for each Race
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetPeopleByRace")]
        public IHttpActionResult GetPeopleByRace()
        {
            try
            {
                var output = _personService.GetPersonListByRace();
                return Json(output);
            }
            catch (Exception ex)
            {
                //Write Log 
                return BadRequest("GetPeopleByRace Method error " + ex.Message);
            }
        }

        /// <summary>
        /// API end point to get list of person for specific Race
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetPersonListByRace/{race}")]
        public IHttpActionResult GetPersonListByRace(string race)
        {
            try
            {
                var output = _personService.GetPersonList(race);
                return Json(output);
            }
            catch (Exception ex)
            {
                //Write Log 
                return BadRequest("GetPersonListByRace Method error " + ex.Message);
            }
        }
    }
}
