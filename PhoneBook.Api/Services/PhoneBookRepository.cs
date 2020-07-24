using Microsoft.EntityFrameworkCore;
using PhoneBook.Api.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Api.Services
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        private readonly PhoneBookContext phoneBookContext;

        public PhoneBookRepository(PhoneBookContext _phoneBookContext)
        {
            phoneBookContext = _phoneBookContext;
        }

        public async Task<IEnumerable<PhoneBookNumber>> GetPhoneBooks()
        {
            var res = await phoneBookContext.Phonebook.ToListAsync();
            return res;
        }

        public void AddPhoneBook(PhoneBookNumber phonebook)
        {
            phoneBookContext.Phonebook.Add(phonebook);
            phoneBookContext.SaveChanges();
        }

        public void RemovePhoneBook(int id)
        {
            var res = phoneBookContext.Phonebook.FirstOrDefault(x => x.Id == id);

            if (res != null)
            {
                phoneBookContext.Phonebook.Remove(res);
                phoneBookContext.SaveChanges();
            }
        }

        public async Task<PhoneBookNumber> UpdatePhoneBook(PhoneBookNumber phonebook)
        {
            var res = await phoneBookContext.Phonebook.FirstOrDefaultAsync(x => x.Id == phonebook.Id);

            if (res != null)
            {
                res.FirstName = phonebook.FirstName;
                res.LastName = phonebook.LastName;
                res.HomeNumber = phonebook.HomeNumber;
                res.WorkNumber = phonebook.WorkNumber;
                res.PhoneNumber = phonebook.PhoneNumber;

                phoneBookContext.Phonebook.Update(res);
                phoneBookContext.SaveChanges();
            }
            return res;
        }


    }
}
