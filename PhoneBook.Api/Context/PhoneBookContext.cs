using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Api.Context
{
    public class PhoneBookContext: DbContext
    {
        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        { }


        public DbSet<PhoneBookNumber> Phonebook { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<PhoneBookNumber>().ToTable("PhoneBook");
            modelbuilder.Entity<PhoneBookNumber>().HasKey(x => x.Id);
        }





    }
}
