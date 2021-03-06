﻿using ContactAddressBook.Entities.Concrete;
using ContactAddressBook.Entities.Dtos;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.DataAccessLayer.Abstract
{
    public interface IContactInfoDal : IEntityRepository<ContactInfo>
    {
        List<CounterPersonByCityDto> CounterPersonGroupByCities();
        List<CounterPhoneNumberByCityDto> CounterPhoneNumberGroupByCities();
    }
}
