using ContactAddressBook.Entities.Concrete;
using ContactAddressBook.Entities.Dtos;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.Business.Abstract
{
    public interface IContactInfoService
    {
        IResult RemoveAllContactByPersonId(int personId);
        IResult RemoveContactByContactInfoId(int contactId);
        IResult AddContactInfo(ContactInfo contactInfo);
        IDataResult<ReportDto> GetReport();
    }
}
