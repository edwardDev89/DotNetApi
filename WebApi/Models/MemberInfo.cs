using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class MemberInfo
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set;}
        [Column(TypeName = "int")]
        public int Age { get; set; }
        [Column(TypeName = "int")]
        public int Weight { get; set; }
        [Column(TypeName = "int")]
        public int Height { get; set; }
        [Column(TypeName = "int")]
        public int BodyFat { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public string IC { get; set; }

    }
}
