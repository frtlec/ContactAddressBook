using ContactAddressBook.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.Business.ValidationRules.FluentValidation
{
    public class PersonValidation:AbstractValidator<Person>
    {
        public PersonValidation()
        {
            RuleFor(p => p.PersonFirstName).NotEmpty();
            RuleFor(p => p.PersonFirstName).NotNull();
            RuleFor(p => p.PersonFirstName).Length(1, 49);
            RuleFor(p => p.PersonLastName).NotEmpty();
            RuleFor(p => p.PersonLastName).Length(1, 49);
            RuleFor(p => p.PersonCompany).NotEmpty();
            RuleFor(p => p.PersonCompany).Length(1, 49);

        }
    }
}
