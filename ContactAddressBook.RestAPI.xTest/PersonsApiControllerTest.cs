using ContactAddressBook.Business.Abstract;
using ContactAddressBook.Entities.Concrete;
using ContactAddressBook.RestAPI.Controllers;
using Core.Constants;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ContactAddressBook.RestAPI.xTest
{
    public class PersonsApiControllerTest
    {
        private readonly Mock<IPersonService> _personService;
        private readonly PersonsController _personsController;

        private Person _person;
        private List<Person> _personsList;

        public PersonsApiControllerTest()
        {
            _personService = new Mock<IPersonService>();
            _personsController = new PersonsController(_personService.Object);
            _personsList = new List<Person>();

            _person = new Person
                {
                    PersonFirstName="test3",
                    PersonLastName="test40",
                    PersonCompany="testComp",
                    ContactInfos=new List<ContactInfo> { new ContactInfo { City="istanbul",PhoneNumber="05319665817",Email="zafer.krk@hotmail.com"} }
                   
                };

            _personsList.Add(_person);
            _personsList.Add(_person);
        }
        [Fact]
        public void Add_Person_Check()
        {
            _personService.Setup(x => x.AddPerson(_person)).Returns(new SuccessResult(Messages.PersonAddedSuccess));
            var result=_personsController.Add(_person);
            var okResult = Assert.IsType<OkObjectResult>(result);
           Assert.Equal(okResult.Value.ToString(), Messages.PersonAddedSuccess);
        }
        [Fact]
        public void GetAll_Person_Check()
        {
            _personService.Setup(x => x.GetAllPersons()).Returns(new SuccessDataResult<List<Person>>(_personsList,""));
            var result = _personsController.GetAll();
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnPersons = Assert.IsType<List<Person>>(okResult.Value);

            Assert.Equal<int>(2, returnPersons.Count);
        }
    }
}
