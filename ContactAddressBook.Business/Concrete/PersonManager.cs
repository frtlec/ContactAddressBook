using ContactAddressBook.Business.Abstract;
using ContactAddressBook.Business.ValidationRules.FluentValidation;
using ContactAddressBook.DataAccessLayer.Abstract;
using ContactAddressBook.Entities.Concrete;
using ContactAddressBook.Entities.Dtos;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Constants;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactAddressBook.Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private IPersonDal _personDal;
        private IContactInfoDal _contactInfoDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        [CacheAspect( duration: 20)]
        public IDataResult<List<Person>> GetAllPersons()
        {
            var result = new SuccessDataResult<List<Person>>(_personDal.GetList(null, pi1 => pi1.ContactInfos));
            return result;
        }

     
        public IDataResult<List<Person>> GetListByCompany(string company)
        {
            return new SuccessDataResult<List<Person>>(_personDal.GetList(p=>p.PersonCompany==company, pi1 => pi1.ContactInfos));
        }
        public IDataResult<Person> GetPersonById(int personId)
        {
            return new SuccessDataResult<Person>(
                _personDal.Get(p=>p.PersonId==personId,
                                pi1=>pi1.ContactInfos));
        }
        #region add
        [ValidationAspect(typeof(PersonValidation), Priority =0)]
        [CacheRemoveAspect(pattern: "*IPersonService*",Priority =2)]
        public IResult AddPerson(Person person)
        {
            IResult result = BusinessRules.Run(
                CheckIfPersonFullNameExists(person.PersonFirstName, person.PersonLastName));
            if (result != null)
            {
                return result;
            }
            _personDal.Add(person);
            return new SuccessResult(Messages.PersonAddedSuccess);
        }
        private IResult CheckIfPersonFullNameExists(string personFirstName, string personLastName)
        {
            var person = _personDal.Get(p => p.PersonFirstName == personFirstName && p.PersonLastName == personLastName);
            if (person != null)
            {
                return new ErrorResult(Messages.PersonNameAlreadyExists);
            }
            return new SuccessResult();
        }
        #endregion

        #region remove
        public IResult RemovePerson(Person person)
        {
            Person personInDB = GetPerson(person.PersonId);
            IResult result = BusinessRules.Run(CheckIfPersonExists(personInDB));
            if (result != null)
            {
                return result;
            }
            _personDal.Delete(person);
            return new SuccessResult(Messages.PersonRemoveSuccess);
        }


        #endregion
        #region update
        [ValidationAspect(typeof(PersonValidation), Priority = 1)]
        public IResult UpdatePerson(Person person)
        {
            Person personInDB = GetPerson(person.PersonId);
            IResult result = BusinessRules.Run(CheckIfPersonExists(personInDB));
            if (result != null)
            {
                return result;

            }
            person.PersonCreatedDate = personInDB.PersonCreatedDate;
            person.PersonLastUpdateDate = DateTime.Now;
            _personDal.Update(person);
            return new SuccessResult(Messages.PersonUpdateSuccess);
          
        }

        #endregion
       
        private IResult CheckIfPersonExists(Person person)
        {
            if (person == null)
            {
                return new ErrorResult(Messages.PersonNotExist);
            }
            return new SuccessResult();
        }
        private Person GetPerson(int personId)
        {
            return _personDal.Get(p => p.PersonId == personId);
        }

    }
}
