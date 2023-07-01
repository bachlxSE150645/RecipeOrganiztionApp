using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DTO
{
    public class AccountDTO
    {
        public Guid AccountID { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public Guid RoleID { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool Status { get; set; }

        public Role Role { get; set; }
    }
}