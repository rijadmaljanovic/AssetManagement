using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Model
{
    public class CreateUserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int ZipCode { get; set; }
    }
}
