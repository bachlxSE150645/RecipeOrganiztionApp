using BusinessObjects;

namespace DataAccess
{
    public class RoleDAO
    {
        private static RoleDAO instance;
        private readonly AppDBContext _context;

        public RoleDAO(AppDBContext context)
        {
            this._context = context;
        }

        public static RoleDAO GetInstance(AppDBContext dbContext)
        {

            if (instance == null)
            {
                instance = new RoleDAO(dbContext);
            }

            return instance;
        }

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
        public Role AddRoleAsync(string roleName)
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
