using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRoleRepository
    {
        List<Role> GetRoles();
        Role GetRoleById(string id);
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
    }
}
