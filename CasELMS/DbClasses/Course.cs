using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasELMS.DbClasses
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseFee { get; set; }
        public string TeacherName { get; set; }
        public string CourseDiscription { get; set; }
        public DateTime CourseStartDate { get; set; }
        public string CoursePicture { get; set; }
        public string Status { get; set; }
    }
}
