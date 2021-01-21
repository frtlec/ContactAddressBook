using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.Entities.Concrete
{
    public class ContactInfo : IEntity
    {
        public int ContactInfoId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public int PersonId { get; set; }
        
        public virtual Person Persons { get; set; }
    }
    public class ContactInfoEntityConfiguration : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.HasKey(c => c.ContactInfoId);
            builder.Property(c => c.PhoneNumber).HasMaxLength(12).IsRequired();
            builder.Property(c => c.City).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(50).IsRequired();
            
        }

    }
}
