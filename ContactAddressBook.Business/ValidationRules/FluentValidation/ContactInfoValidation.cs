using ContactAddressBook.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.Business.ValidationRules.FluentValidation
{
    public class ContactInfoValidation : AbstractValidator<ContactInfo>
    {
        public ContactInfoValidation()
        {
            RuleFor(c => c.PersonId).NotEmpty();

            RuleFor(c => c.City).NotEmpty();
            RuleFor(c => c.City).Length(1, 99);

            RuleFor(c => c.PhoneNumber).NotEmpty();
            RuleFor(c => c.PhoneNumber).Length(1, 12);

            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Email).Length(1, 50);
            RuleFor(c => c.Email).EmailAddress();

        }
    }
}
