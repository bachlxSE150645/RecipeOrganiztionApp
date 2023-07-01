using BusinessObjects;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.Interfaces;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAccountRepository accRepo;

        public AdminController(AppDBContext dbContext)
        {
            accRepo = new AccountRepository(dbContext);
        }

        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            try
            {
                return Ok(accRepo.GetAccounts());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{AccountId}")]
        public ActionResult<Account> GetAccountById(Guid AccountId)
        {
            try
            {
                return Ok(accRepo.GetAccountsById(AccountId));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{userName}")]
        public ActionResult<IEnumerable<Account>> SreachAccountByUserName(string userName)
        {
            try
            {
                return Ok(accRepo.SearchAccountByUser(userName));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostAccount(SignUpData accountInfo)
        {
            var result = await accRepo.AddAccount(accountInfo);
            if (result == null)
            {
                return Conflict("Something wrong!");
            }

            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> PutAccount(Guid accountID, Account acc)
        {

            if (accountID != acc.AccountID)
            {
                return BadRequest();
            }
            try
            {
                accRepo.UpdateAccount(acc);
            }

            catch (DbUpdateConcurrencyException)
            {
                if (accRepo.GetAccountsById(accountID) == null)
                {
                    return NotFound();
                }

                throw;
            }
            return NoContent();

        }
        [HttpDelete("AccountId")]
        public IActionResult DeleteAccount(Account acc)
        {
            try
            {
                var accID = accRepo.GetAccountsById(acc.AccountID);
                if (accID == null)
                {
                    return NotFound();
                }
                acc.Status = false;
                accRepo.UpdateAccount(acc);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

    }
}
