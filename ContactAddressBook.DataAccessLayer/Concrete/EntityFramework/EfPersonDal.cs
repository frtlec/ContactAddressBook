using ContactAddressBook.DataAccessLayer.Abstract;
using ContactAddressBook.DataAccessLayer.Concrete.EntityFramework.Context;
using ContactAddressBook.Entities.Concrete;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.DataAccessLayer.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, ContactAddressBookDBContext>, IPersonDal
    {
    }
}
