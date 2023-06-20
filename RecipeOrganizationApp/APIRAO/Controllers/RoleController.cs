using BusinessObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository roleRepo;

        public RoleController()
        {
            AppDBContext dbContext = new();
            roleRepo = new RoleRepository(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                return Ok(roleRepo.GetRoles());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public ActionResult PostRoleAsync(string roleName)
        {
            /*var result = roleRepo.AddRole(roleName);
            if (result == null)
            {
                return Conflict("Something wrong!");
            }*/
            roleRepo.AddRole(roleName);
            return Ok();
        }

    }
}
