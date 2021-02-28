using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinkedInProfile.Model
{
    public class UserRepoContext : DbContext
    {
        public  UserRepoContext(DbContextOptions<UserRepoContext> options) : base(options)   {  }

        public DbSet<UserInfoModel> UserInfos { get; set; }
        public DbSet<EducationModel> Educations { get; set; }
    }
}
