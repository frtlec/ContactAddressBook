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
    public class EfContactInfoDal : EfEntityRepositoryBase<ContactInfo, ContactAddressBookDBContext>, IContactInfoDal
    {
        public List<CounterPhoneNumberByCityDto> CounterPhoneNumberGroupByCities()
        {
            //illerde kayıtlı telefon numaralarının sayısı

            using (var context = new ContactAddressBookDBContext())
            {
                var result = from infos in context.ContactInfos
                             group infos by infos.City into grouped
                             orderby grouped.Count() descending
                             select new CounterPhoneNumberByCityDto
                             {
                                 CityName = grouped.Key,
                                 CounterPhoneNumber = grouped.Count()
                             };

                return result.ToList();
            }
        }
        public List<CounterPersonByCityDto> CounterPersonGroupByCities()
        {

            using (var context = new ContactAddressBookDBContext())
            {
                //İllerde kayıtlı kişi sayılarını döndürür 

                var result = from infos in context.ContactInfos.AsEnumerable()
                             group infos by infos.City into grouped
                             orderby grouped.Select(x => x.PersonId).Distinct().Count() descending
                             select new CounterPersonByCityDto
                             {
                                 CityName = grouped.Key,
                                 NumberOfPerson = grouped.Select(x => x.PersonId).Distinct().Count()
                             };

                return result.ToList();
            }
        }
    }
}
