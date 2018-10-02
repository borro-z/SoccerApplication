using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerApplication.Models
{
    [Table("AspNetRoles")]
    public class ApplicationRole : IdentityRole<string>
    {
        public string Description { get; set; }
    }
}
