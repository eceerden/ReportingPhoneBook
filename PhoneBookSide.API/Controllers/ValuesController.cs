using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBookSide.API.Models.DTO;
using PhoneBookSide.API.Models.ORM;
using PhoneBookSide.API.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookSide.API.Controllers
{
    //[route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly PhoneBookContext _phonecontext;
    public ValuesController(PhoneBookContext phonecontext)
    {
        _phonecontext = phonecontext;
    }
    [Route("list")]
    public IActionResult Index()
    {
        List<Person> people = _phonecontext.people.Where(q => q.IsDeleted == false).ToList();
        return Ok(people);
    }

    [Route("create")]
    [HttpPost]
    public IActionResult CreatePerson([FromForm] PersonDTO person)
    {
        if (ModelState.IsValid)
        {
            Person newperson = new Person();
            newperson.Name = person.Name;
            newperson.Surname = person.Surname;
            newperson.Company = person.Company;


            _phonecontext.people.Add(newperson);
            _phonecontext.SaveChanges();



            return Ok(person);
        }
        else
        {
            return BadRequest(ModelState.Values);

        }
    }




    }
}
