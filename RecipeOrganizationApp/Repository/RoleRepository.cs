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
            _context = new RoleDAO(dbContext);
        }

        private readonly RoleDAO _context;

        public List<Role> GetRoles() => _context.GetRoles();
        public Role GetRoleById(string id) => _context.GetRoleById(id);
        public Role AddRole(string roleName) => _context.AddRole(roleName);
        public void UpdateRole(Role role) => _context.UpdateRole(role);
        public void DeleteRole(Role role) => _context.DeleteRole(role);
    }
}
