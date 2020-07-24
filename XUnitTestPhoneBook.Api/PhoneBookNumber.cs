using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XUnitTestPhoneBook.Api
{
    public class PhoneBookNumber
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomeNumber { get; set;}
        public string WorkNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
