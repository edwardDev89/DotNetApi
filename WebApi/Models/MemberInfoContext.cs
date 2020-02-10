using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class MemberInfoContext:DbContext
    {
        public MemberInfoContext(DbContextOptions<MemberInfoContext> options):base(options)
        {

        }

        public DbSet<MemberInfo> MemberInfos { get; set; }
    }
}
