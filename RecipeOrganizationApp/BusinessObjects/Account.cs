using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Account
    {
        [Key][Required] public Guid AccountID { get; set; }
        [MaxLength(50)] public string? UserName { get;set; }
        [MaxLength(50)] public string? Password { get; set; }
        [ForeignKey("Role")][Required] public Guid RoleID { get; set; }
        [MaxLength(50)] public string? Email { get; set; }
        [MaxLength(15)] public string? Phone { get; set; }
        [Required] public bool Status { get; set; }

        public Role Role { get; set; }
        
    }
}
