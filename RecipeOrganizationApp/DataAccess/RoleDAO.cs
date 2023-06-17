using BusinessObjects;
namespace DataAccess
{
    public class RoleDAO
    {
        //Get all Roles
        public static List<Role> GetRoles()
        {
            var listRole = new List<Role>();
            try
            {
                using(var context = new AppDBContext())
                {
                    listRole = context.Roles.ToList();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listRole;
        }
        //Get role by RoleID
        public static Role GetRoleById(string id)
        {
            var role = new Role();
            try
            {
                using(var context = new AppDBContext())
                {
                    role = context.Roles.SingleOrDefault(x => x.RoleID.ToString() == id);
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return role;
        }
        //Post new Role
        public static void AddRole(Role role)
        {
            try
            {
                using(var context = new AppDBContext()) {
                    if(context.Roles.SingleOrDefault(x=>x.RoleName == role.RoleName) == null) 
                    {
                        var newRole = new Role { RoleName= role.RoleName };
                        context.Roles.Add(newRole);
                        context.SaveChanges();
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //Put existing role by Role ID
        public static void UpdateRole(Role role)
        {
            try
            {
                using(var context = new AppDBContext())
                {
                    if(context.Roles.SingleOrDefault(x=>x.RoleID == role.RoleID) != null)
                    {
                        context.Entry<Role>(role).State =
                           Microsoft.EntityFrameworkCore.EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }catch(Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        //Delete existing role
        public static void DeleteRole(Role role)
        {
            try
            {
                using(var context = new AppDBContext()) {
                    var rolecheck = context.Roles.SingleOrDefault(x => x.RoleID == role.RoleID);
                    if (rolecheck != null)
                    {
                        context.Roles.Remove(rolecheck);
                    }
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
