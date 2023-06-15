using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Role
    {
        [Key][Required] public Guid RoleID { get; set; }
        [MaxLength(10)] public string RoleName { get; set; }
    }
}
