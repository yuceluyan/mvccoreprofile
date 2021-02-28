using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinkedInProfile.Model
{
    public class EducationModel
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [MaxLength(50)]
        public string HighScool { get; set; }

        [MaxLength(50)]
        public string University { get; set; }

        [MaxLength(50)]
        public string Master { get; set; }
    }
}
