using System;
using Xunit;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace XUnitTestPhoneBook.Api
{
    public class UnitTestPhoneBookApi
    {
        [Fact]
        public void Test_ReadAll()
        {
            string dbName = Guid.NewGuid().ToString();
            DbContextOptions<PhoneBookContext> options = new DbContextOptionsBuilder<PhoneBookContext>().UseInMemoryDatabase(databaseName: dbName).Options;

            using var context = new PhoneBookContext(options);
            context.Populate();
            var items = context.Phonebook.ToList();

            Assert.Equal(3, items.Count);
            Assert.Equal("Name1", items[0].FirstName);
            Assert.Equal("Name2", items[1].FirstName);
            Assert.Equal("Name3", items[2].FirstName);
        }

        [Fact]
        public void Test_ReadFiltered()
        {
            string dbName = Guid.NewGuid().ToString();
            DbContextOptions<PhoneBookContext> options = new DbContextOptionsBuilder<PhoneBookContext>().UseInMemoryDatabase(databaseName: dbName).Options;

            using var context = new PhoneBookContext(options);
            context.Populate();
            var item = context.Phonebook.FirstOrDefault(x=>x.Id==2);

            Assert.NotEqual("Name1", item.FirstName);
            Assert.NotEqual("Name3", item.FirstName);
            Assert.Equal("Name2", item.FirstName);
        }


        [Fact]
        public void Test_Add()
        {
            string dbName = Guid.NewGuid().ToString();
            DbContextOptions<PhoneBookContext> options = new DbContextOptionsBuilder<PhoneBookContext>().UseInMemoryDatabase(databaseName: dbName).Options;

            using var context = new PhoneBookContext(options);
            var item = new PhoneBookNumber()
            {
                Id = 10,
                FirstName = "Name10",
                LastName = "Surname10",
                HomeNumber = "Homenumber10",
                PhoneNumber = "PhoneNumber10",
                WorkNumber = "WorkNumber10"
            };

            context.Phonebook.Add(item);
            context.SaveChanges();

            var res = context.Phonebook.ToList();

            Assert.Single(res);
            Assert.Equal("Name10", res[0].FirstName);
        }


        [Fact]
        public void Test_Remove()
        {
            string dbname = Guid.NewGuid().ToString();
            DbContextOptions<PhoneBookContext> options= new DbContextOptionsBuilder<PhoneBookContext>().UseInMemoryDatabase(databaseName: dbname).Options;

            using var context = new PhoneBookContext(options);
            context.Populate();

            var res = context.Phonebook.FirstOrDefault(x => x.Id == 1);

            context.Phonebook.Remove(res);
            context.SaveChanges();

            var list = context.Phonebook.ToList();

            Assert.Equal(2, list.Count);
        }


        [Fact]
        public void Test_Update()
        {
            string dbname = Guid.NewGuid().ToString();
            DbContextOptions<PhoneBookContext> options = new DbContextOptionsBuilder<PhoneBookContext>().UseInMemoryDatabase(databaseName: dbname).Options;

            using var context = new PhoneBookContext(options);
            context.Populate();

            var res = context.Phonebook.FirstOrDefault(x => x.Id == 1);
            res.FirstName = "Name1Mod";

            context.SaveChanges();
            var resupd = context.Phonebook.FirstOrDefault(x => x.Id == 1);

            Assert.Equal("Name1Mod", resupd.FirstName);
        }



    }
}
