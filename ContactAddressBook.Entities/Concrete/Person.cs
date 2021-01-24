using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactAddressBook.Entities.Concrete
{
  
    [Serializable]
    public class Person:IEntity
    {
        public int PersonId { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public string PersonCompany { get; set; }

        
        public DateTime PersonCreatedDate { get; set; }
        public DateTime PersonLastUpdateDate{ get; set; }

        public List<ContactInfo> ContactInfos { get; set; }
    }
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(p => p.PersonId);
            builder.Property(p=> p.PersonFirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PersonLastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PersonCompany).HasMaxLength(50).IsRequired();
            builder.Property(p => p.PersonCreatedDate).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.PersonLastUpdateDate).IsRequired().HasDefaultValueSql("GETDATE()");

            builder.HasMany(c => c.ContactInfos)
                    .WithOne(e => e.Persons);
        }

    }
}
