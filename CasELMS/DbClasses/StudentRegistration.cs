using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasELMS.DbClasses
{
    public class StudentRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string StudentPhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public string City  { get; set; }
        public string Countru  { get; set; }
        public int PostalCode  { get; set; }
        public short Status { get; set; }
        public DateTime InsertionDate { get; set; }
        public DateTime DeactivateDate { get; set; }
        public DateTime ActivateDate { get; set; }
    }
}
