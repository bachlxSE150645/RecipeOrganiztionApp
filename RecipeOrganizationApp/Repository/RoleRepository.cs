using BusinessObjects;
using DataAccess;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RoleRepository : IRoleRepository
    {

        public RoleRepository(AppDBContext dbContext)
        {
            _context = RoleDAO.GetInstance(dbContext);
        }

        private readonly RoleDAO _context;

        public List<Role> GetRoles() => RoleDAO.GetRoles();
        public Role GetRoleById(string id) => RoleDAO.GetRoleById(id);
        public Role AddRole(string roleName) => _context.AddRoleAsync(roleName);
        public void UpdateRole(Role role) => RoleDAO.UpdateRole(role);
        public void DeleteRole(Role role) => RoleDAO.DeleteRole(role);
    }
}
