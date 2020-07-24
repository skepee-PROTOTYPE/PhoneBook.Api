using PhoneBook.Api.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.Api.Services
{
    public interface IPhoneBookRepository
    {
        public Task<IEnumerable<PhoneBookNumber>> GetPhoneBooks();
        public void AddPhoneBook(PhoneBookNumber phonebook);
        public void RemovePhoneBook(int id);
        public Task<PhoneBookNumber> UpdatePhoneBook(PhoneBookNumber phonebook);
    }
}
