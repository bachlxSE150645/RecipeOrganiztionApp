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
        private readonly IWishListRepository wishListRepo;

        public AccountController(IAccountRepository _accountRepository, IWishListRepository _wishListRepo)
        {
            this.accRepo = _accountRepository;
            this.wishListRepo = _wishListRepo;
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
            else
            {
                wishListRepo.newWishList(result.AccountID);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAccounts(string? searchString, int pageIndex = 1)
        {
            try
            {
                return Ok( await accRepo.GetAccounts(searchString));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{AccountID}")]
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
