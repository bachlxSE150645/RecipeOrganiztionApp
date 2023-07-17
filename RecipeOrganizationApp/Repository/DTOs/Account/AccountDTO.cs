using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Repository.DTOs.Account
{
    public class AccountDTO
    {
        public Guid AccountID { get; set; }
        public string? UserName { get; set; }
        [JsonIgnore] public string? Password { get; set; }
        public Guid RoleID { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool Status { get; set; }

        
    }
}
