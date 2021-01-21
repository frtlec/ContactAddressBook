using ContactAddressBook.Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.DataAccessLayer.Abstract
{
    public interface IContactInfoDal : IEntityRepository<ContactInfo>
    {
    }
}
