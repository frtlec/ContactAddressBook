using ContactAddressBook.Business.Concrete;
using ContactAddressBook.DataAccessLayer.Abstract;
using ContactAddressBook.DataAccessLayer.Concrete.EntityFramework;
using ContactAddressBook.Entities.Concrete;
using Core.Utilities.Results;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ContactAddressBook.Business.xTest.ManagerTests
{
    public class PersonManagerTests
    {
        //private static Mock<IPersonDal> _personDalMock = new Mock<IPersonDal>();
      
        private Person _person { get; set; }
        public EfPersonDal _personDalMock { get; }
        private PersonManager _personManager { get; }
        public PersonManagerTests()
        {
            _person = new Person();
            _personDalMock = new EfPersonDal();
            _personManager = new PersonManager(_personDalMock);
        }
        [Fact]
        public void Person_Get_All_Check()
        {
                Assert.NotEmpty(_personManager.GetAllPersons().Data);
        }
        [Fact]
        public void Person_Add_Check()
        {

            IResult result = _personManager.AddPerson(_person);
            Assert.IsType<SuccessResult>(result);
        }
    }
}
