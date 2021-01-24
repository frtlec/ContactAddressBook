using ContactAddressBook.Entities.Concrete;
using ContactAddressBook.Entities.Dtos;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.Business.Abstract
{
    public interface IPersonService
    {
        IDataResult<Person> GetPersonById(int personId);
        IDataResult<List<Person>> GetAllPersons();
        IDataResult<List<Person>> GetListByCompany(string company);
        IResult AddPerson(Person person);
        IResult RemovePerson(Person person);
        IResult UpdatePerson(Person person);
    }
}
