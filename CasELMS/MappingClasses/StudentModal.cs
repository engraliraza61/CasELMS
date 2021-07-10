using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasELMS.MappingClasses
{
    public class StudentModal
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public int PostalCode { get; set; }
        public string Class { get; set; }
    }
}
