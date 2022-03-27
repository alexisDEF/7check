using System;
using System.Collections.Generic;
using System.Text;

namespace _7Check.Models
{
    class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Tel { get; set; }
        public string LicenseNumber { get; set; }
    }
}
