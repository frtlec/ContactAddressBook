using ContactAddressBook.Business.Abstract;
using ContactAddressBook.Business.ValidationRules.FluentValidation;
using ContactAddressBook.DataAccessLayer.Abstract;
using ContactAddressBook.Entities.Concrete;
using Core.Aspects.Autofac.Validation;
using Core.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactAddressBook.Business.Concrete
{
    public class ContactInfoManager:IContactInfoService
    {
        private IContactInfoDal _contactInfoDal;

        public ContactInfoManager(IContactInfoDal contactInfoDal)
        {
            _contactInfoDal = contactInfoDal;
        }

        public IResult RemoveAllContactByPersonId (int personId)
        {
            List<ContactInfo> contactsInDB = GetListContactInfosByPersonId(personId);
            IResult result = BusinessRules.Run(CheckIfContactExists(contactsInDB));
            if (result != null)
            {
                return result;
            }
            foreach (var item in contactsInDB)
            {
                _contactInfoDal.Delete(item);
            }
           
            return new SuccessResult(Messages.PersonRemoveSuccess);
        }
        private IResult CheckIfContactExists(List<ContactInfo> person)
        {
            if (person == null || person.Count < 1)
            {
                return new ErrorResult(Messages.PersonNotExist);
            }
            return new SuccessResult();
        }
        private List<ContactInfo> GetListContactInfosByPersonId(int personId)
        {
            return _contactInfoDal.GetList(p => p.PersonId == personId).ToList();
        }
        public IResult RemoveContactByContactInfoId(int contactId )
        {
             ContactInfo contactInDB = GetContactInfoByPersonId(contactId);
            IResult result = BusinessRules.Run(CheckIfContactExists(contactInDB));
            if (result != null)
            {
                return result;
            }
            _contactInfoDal.Delete(contactInDB);

            return new SuccessResult(Messages.ContactRemoveSuccess);
        }
        private IResult CheckIfContactExists(ContactInfo contactInfo)
        {
            if (contactInfo == null )
            {
                return new ErrorResult(Messages.ContactNotExist);
            }
            return new SuccessResult();
        }
        private ContactInfo GetContactInfoByPersonId(int personId)
        {
            return _contactInfoDal.Get(p => p.PersonId == personId);
        }

        [ValidationAspect(typeof(ContactInfoValidation), Priority = 1)]
        public IResult AddContactInfo(ContactInfo contactInfo)
        {
            IResult result = BusinessRules.Run(CheckIfPhoneNumberExists(contactInfo.PhoneNumber));
            if (result != null)
            {
                return result;
            }
            _contactInfoDal.Add(contactInfo);
            return new SuccessResult(Messages.ContactAddedSuccess);
        }
        private IResult CheckIfPhoneNumberExists(string phoneNumber)
        {
            var person = _contactInfoDal.GetList(c=>c.PhoneNumber == phoneNumber);
            if ( person.Count>0)
            {
                return new ErrorResult(Messages.ContactPhoneNumberExit);
            }
            return new SuccessResult();
        }
    }
}
