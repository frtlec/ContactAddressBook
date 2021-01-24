using ContactAddressBook.DataAccessLayer.Abstract;
using ContactAddressBook.DataAccessLayer.Concrete.EntityFramework.Context;
using ContactAddressBook.Entities.Concrete;
using ContactAddressBook.Entities.Dtos;
using Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Extensions;

namespace ContactAddressBook.DataAccessLayer.Concrete.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, ContactAddressBookDBContext>, IPersonDal
    {


       
    }
}
