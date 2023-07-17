using AutoMapper;
using BusinessObjects;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Repository;
using Repository.DTOs.Account;
using Repository.Interfaces;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAccountRepository accRepo;
        private readonly IMapper _mapper;

        public AdminController(IAccountRepository accountRepository, IMapper mapper)
        {
            accRepo = accountRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Account>>> GetAccounts(string? searchString, int pageIndex = 1)
        {
            try
            {
                var dto = await accRepo.GetAccounts(searchString, pageIndex);
                var account = _mapper.Map<List<AccountDTO>>(dto);
                return Ok(account);
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
        public IActionResult DeleteAccount(Guid AccountID)
        {
            try
            {
                var accID = accRepo.GetAccountsById(AccountID);
                if (accID == null)
                {
                    return NotFound();
                }
                accID.Status = false;
                accRepo.UpdateAccount(accID);
                return NoContent();
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

    }
}