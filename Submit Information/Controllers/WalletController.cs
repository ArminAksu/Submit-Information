using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Submit_Information.Data;
using Submit_Information.Request;

namespace Submit_Information.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        DataContext _Context;
        public WalletController(DataContext dataContext)
        {
            _Context = dataContext;
        }

        [HttpGet("getsts")]
        public ActionResult GetInWallet()
        {
            var Wallet = _Context.Wallets.FirstOrDefault();
            return Ok(Wallet);
        }
        [HttpGet("getprods")]
        public ActionResult<Entity.Wallet> GetInWallte(decimal AmoutBlock)
        {
            var Wallet = _Context.Wallets.Where(s => s.AmountBlock == AmoutBlock).FirstOrDefault();
            if (Wallet is null)
                return NotFound($"notfound InWallet with {AmoutBlock}");
            else
                return Ok(Wallet);
        }
        [HttpPut("UpdateWallet")]
        public IActionResult UpdateWallet(decimal AmoutBlock, UpdateWalletRequest request)
        {
            if (ModelState.IsValid)
            {
                var UpdateWallet = _Context.Wallets.Where(s => s.AmountBlock == AmoutBlock).FirstOrDefault();
                if (UpdateWallet is not null)
                {
                    if (request.Block != null)
                        UpdateWallet.Block = request.Block;
                    if (request.Amount != null)
                        UpdateWallet.Amount = request.Amount;
                    if (request.AmountBlock != null)
                        UpdateWallet.AmountBlock = request.AmountBlock;
                    if (request.NumberAccount != null)
                        UpdateWallet.NumberAccount = request.NumberAccount;
                    var newWallet = _Context.Wallets.Update(UpdateWallet);
                    _Context.SaveChanges();
                    return Ok(newWallet.Entity);
                }
                return NotFound("کد ملی و مبلغ داده شود");
            }
            return BadRequest("اطلاعات ارسالی صحیح نمی باشد");
        }
    }
}
