using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.SchoolManagement.Entities
{
    public class Inscription
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
        public DateTime InscriptionDate { get; set; }
        public Inscription(int courseId, int studentId, DateTime inscriptionDate) { 
            CourseId = courseId;
            StudentId = studentId;
            InscriptionDate = inscriptionDate;
        }
    }
}
