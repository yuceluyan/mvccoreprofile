using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinkedInProfile.Model
{
    public class UserInfoModel
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
  
    }
}
