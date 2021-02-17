using Confluent.Kafka;
using NUnit.Framework;
using PhoneBookSide.API.Controllers;
using PhoneBookSide.API.Models.DTO;
using PhoneBookSide.API.Models.ORM;
using PhoneBookSide.API.Models.ORM.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingPhoneBook.Test.PhoneBookSide.API.ControllersTest
{
    class ValuesControllerTests
    {
        [Test]
        public void GetListTest()
        {
            PhoneBookContext _phonecontext = new PhoneBookContext();
            ProducerConfig _config = new ProducerConfig();
            ValuesController valuesController = new ValuesController(_config,_phonecontext);
            var result = valuesController.GetList();

            Assert.IsTrue(result.Count > 0);

        }

        [Test]
        public void CreatePersonTest()
        {
            PhoneBookContext _phonecontext = new PhoneBookContext();
            ProducerConfig _config = new ProducerConfig();
            ValuesController valuesController = new ValuesController(_config, _phonecontext);

            PersonDTO person = new PersonDTO();
            var result = valuesController.CreatePerson(person);

            Assert.IsNotNull(result);
            

        }

        [Test]
        public void DeleteTest()
        {
            PhoneBookContext _phonecontext = new PhoneBookContext();
            ProducerConfig _config = new ProducerConfig();
            ValuesController valuesController = new ValuesController(_config, _phonecontext);

            var personDelete = new PersonDeleteDTO();
         
            //var id = personDelete.ID;

            var result = valuesController.Delete(personDelete);

            Assert.IsNotNull(result);
                    
        }

        [Test]
        public void AddTest()
        {
            PhoneBookContext _phonecontext = new PhoneBookContext();
            ProducerConfig _config = new ProducerConfig();
            ValuesController valuesController = new ValuesController(_config, _phonecontext);

            var model = new ConnectionInfoAddDTO();

            //var id = personDelete.ID;

            var result = valuesController.Add(model);

            Assert.IsNotNull(result);
        }

        [Test]
        public void GetDetailTest()
        {
            PhoneBookContext _phonecontext = new PhoneBookContext();
            ProducerConfig _config = new ProducerConfig();
            ValuesController valuesController = new ValuesController(_config, _phonecontext);

            var detail = valuesController.GetDetail(3);

            //var id = personDelete.ID;

            Assert.IsNotNull(detail);
        }








    }
}
