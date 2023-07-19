using BusinessObjects.MapData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;

namespace APIRAO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListItemRepository wlRepo;

        public WishListController(IWishListItemRepository _wlRepo)
        {
            this.wlRepo = _wlRepo;
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetWishListsItemByAccountID(Guid accountId)
        {
            try
            {
                return Ok(wlRepo.GetWishListByAccountID(accountId));
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostWishListItem(WishListItemData inf)
        {
            var result = wlRepo.addWishListItem(inf);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWishListItem(WishListItemData inf)
        {
            var result = wlRepo.removeWishListItem(inf);
            if (result == null)
            {
                return BadRequest("Something wrong!");
            }

            return Ok(result);
        }

    }
}
