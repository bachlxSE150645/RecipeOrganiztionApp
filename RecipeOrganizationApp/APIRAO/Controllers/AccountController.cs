using BusinessObjects;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accRepo;

        public AccountController(IAccountRepository _accountRepository)
        {
            this.accRepo = _accountRepository;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginData inf)
        {
            var check = accRepo!.GetAccountByEmailAndPassword(inf.Email, inf.Password);

            if (check == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(check);
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpData inf)
        {
            var result = await accRepo.AddAccount(inf);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts(string searchString, int pageIndex)
        {
            try
            {
                return Ok(accRepo.GetAccounts(searchString,pageIndex));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("AccountID")]
        public async Task<IActionResult> GetAccounts(Guid AccountID)
        {
            try
            {
                return Ok(accRepo.GetAccountsById(AccountID));
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
