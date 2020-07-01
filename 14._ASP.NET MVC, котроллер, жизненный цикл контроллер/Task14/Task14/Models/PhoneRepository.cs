using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task14.Models
{
    public class PhoneRepository
    {
        List<Phone> phones = new List<Phone>
        {
        new Phone { Name = "Ilya", Phone_number = "1234512" },
        new Phone { Name = "Artemy", Phone_number = "6431488"},
        new Phone { Name = "Swatar", Phone_number = "6401337"}
        };

        public List<Phone> GetAllPhones() => phones;
    }
}