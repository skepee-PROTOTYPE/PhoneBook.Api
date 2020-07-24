using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XUnitTestPhoneBook.Api
{
    public class PhoneBookContext: DbContext
    {
        protected DbContextOptions<PhoneBookContext> ContextOptions { get; }
        public DbSet<PhoneBookNumber> Phonebook { get; set; }

        public PhoneBookContext(DbContextOptions<PhoneBookContext> options) : base(options)
        {
            ContextOptions = options;           
        }

        public void Populate()
        {
            using var context = new PhoneBookContext(ContextOptions);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var address1 = new PhoneBookNumber()
            {
                Id = 1,
                FirstName = "Name1",
                LastName = "Surname1",
                HomeNumber = "020123456",
                PhoneNumber = "0204567989",
                WorkNumber = "+44123789"
            };


            var address2 = new PhoneBookNumber()
            {
                Id = 2,
                FirstName = "Name2",
                LastName = "Surname2",
                HomeNumber = "020223456",
                PhoneNumber = "0205567989",
                WorkNumber = "+44223789"
            };

            var address3 = new PhoneBookNumber()
            {
                Id = 3,
                FirstName = "Name3",
                LastName = "Surname3",
                HomeNumber = "020323456",
                PhoneNumber = "0206567989",
                WorkNumber = "+44323789"
            };


            context.AddRange(address1, address2, address3);

            context.SaveChanges();
        }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Filename=PhoneBook.db");
        //}

        //protected override void OnModelCreating(ModelBuilder modelbuilder)
        //{
        //    modelbuilder.Entity<PhoneBookNumber>().ToTable("PhoneBook");
        //    modelbuilder.Entity<PhoneBookNumber>().HasKey(x => x.Id);
        //}

    }
}
