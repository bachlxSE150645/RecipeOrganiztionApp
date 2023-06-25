using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
using BusinessObjects.MapData;

namespace DataAccess
{
    public class RoleDAO
    {
        private readonly AppDBContext _context;

        public RoleDAO(AppDBContext context)
        {
            _context = context;
        }

        //Get all Roles
        public List<Role> GetRoles()
        {
            try
            {
                return _context.Roles.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Get role by RoleID
        public Role GetRoleById(string id)
        {
            try
            {
                return _context.Roles.SingleOrDefault(x => x.RoleID == Guid.Parse(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Post new Role
        public Role AddRole(string roleName)
        {
            try
            {
                var newRole = new Role
                {
                    RoleID = Guid.NewGuid(),
                    RoleName = roleName
                };
                _context.Roles.Add(newRole);
                _context.SaveChanges();
                return newRole;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Put existing role by Role ID
        public void UpdateRole(Role role)
        {
            try
            {
                var roleCheck = _context.Roles.SingleOrDefault(x => x.RoleID == role.RoleID);
                if (roleCheck != null)
                {
                    _context.Entry(roleCheck).CurrentValues.SetValues(role);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Delete existing role
        public void DeleteRole(Role role)
        {
            try
            {
                var roleCheck = _context.Roles.SingleOrDefault(x => x.RoleID == role.RoleID);
                if (roleCheck != null)
                {
                    _context.Roles.Remove(roleCheck);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}