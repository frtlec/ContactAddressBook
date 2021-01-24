using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.Entities.Dtos
{
    public  class ReportDto
    {
        public List<CounterPersonByCityDto> CounterPersonByCityDto { get; set; }
        public List<CounterPhoneNumberByCityDto> CounterPhoneNumberByCityDto { get; set; }
    }
}
