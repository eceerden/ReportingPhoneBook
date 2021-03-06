﻿
using Confluent.Kafka;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhoneBookSide.API.Models.DTO;
using PhoneBookSide.API.Models.ORM;
using PhoneBookSide.API.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBookSide.API.Controllers
{

    [ApiController]
    public class ValuesController : Controller
    {

        private readonly PhoneBookContext _phonecontext;
        private ProducerConfig _config;

        public ValuesController(ProducerConfig config, PhoneBookContext phonecontext)      {
            this._config = config;
            _phonecontext = phonecontext;

        }



        [Route("list")]
    public List<PersonAddDTO> GetList()
    {
            //List<Person> people = _phonecontext.people.Where(q => q.IsDeleted == false).ToList();
                 
            List<PersonAddDTO> people = _phonecontext.people.Where(q => q.IsDeleted == false).Select(q => new PersonAddDTO()
            {
                ID = q.ID,
                Name = q.Name,
                Surname = q.Surname,
                Company = q.Company,
                Infos = q.Infos.Where(q => q.IsDeleted == false).ToList()

            }).ToList();

            return people;
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

                person.ID = newperson.ID;



            return Ok(person);
        }
        else
        {
            return BadRequest(ModelState.Values);

        }
    }

        [Route("delete")]
        [HttpPost]
        public IActionResult Delete([FromForm] PersonDeleteDTO personDelete)
        {

            Person deletedperson = _phonecontext.people.Find(personDelete.ID);

            if (deletedperson != null)
            {
                deletedperson.IsDeleted = true;
                _phonecontext.SaveChanges();

                return Ok(deletedperson);
            }
            else
            {
                return BadRequest("This ID is not valid!!");
            }

        }
        [Route("Add")]
        [HttpPost]
        public IActionResult Add([FromForm] ConnectionInfoAddDTO model)
        {
            if (ModelState.IsValid)
            {
                ConnectionInfo info = new ConnectionInfo();
                info.Phone = model.Phone;
                info.Email = model.Email;
                info.Location = model.Location;
                info.PersonID = model.PersonID;
                info.context = model.context;
                _phonecontext.connectionInfos.Add(info);
                _phonecontext.SaveChanges();


                return Ok(model);

            }
            else
            {
                return BadRequest("This ID is not valid!!");
            }

        }

        
        [Route("detail/{id}")]
        [HttpGet]
        public IActionResult GetDetail(int id)
        {
            Person person = _phonecontext.people.Find(id);

            if (person != null)
            {
                DetailedPersonDTO detailedPerson = _phonecontext.people.Where(q => q.IsDeleted == false).Select(q => new DetailedPersonDTO()
                {
                     ID = q.ID,
                    Name = q.Name,
                    Surname = q.Surname,
                    Company = q.Company,
                    details = _phonecontext.connectionInfos.Where(q=>q.IsDeleted == false && q.PersonID == id ).Select(q=> new ConnectionInfoDTO()
                    {
                        Phone=q.Phone,
                        Email = q.Email,
                        Location =q.Location,
                        context = q.context

                    }).ToList()
                    
                    
                }).FirstOrDefault(x => x.ID == id);

                return Ok(detailedPerson);
            }
            else
            {
                return BadRequest("This ID is not valid!!");
            }

        }


        [HttpPost("Send")]
        public async Task<IActionResult> Get(string topic)
        {
            var detailedlist = GetList();
            string serializedPerson = JsonConvert.SerializeObject(detailedlist);
            using (var producer = new ProducerBuilder<Null, string>(_config).Build())
            {
                await producer.ProduceAsync(topic, new Message<Null, string> { Value = serializedPerson });
                producer.Flush(TimeSpan.FromSeconds(10));
                return Ok("Your send request is in progress");
            }
        }

    }
}
