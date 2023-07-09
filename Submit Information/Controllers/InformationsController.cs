using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Submit_Information.Data;
using Submit_Information.Entity;
using Submit_Information.Request;
using Submit_Information.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Submit_Information.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationsController : ControllerBase
    {
        DataContext _context;
        private readonly IWalletRepository _walletRepository;
        private readonly IInformationRepository _informationRepository;
        public InformationsController(DataContext dataContext, IWalletRepository walletRepository, IInformationRepository informationRepository)
        {
            _context = dataContext;
            _walletRepository = walletRepository;
            _informationRepository = informationRepository;
        }

        [HttpGet("getsts")]
        public ActionResult GetInformations()
        {
            var Information = _context.Informations.ToList();
            return Ok(Information);
        }
        [HttpGet("getprods")]
        public ActionResult<Entity.Information> GetInformation(string nationalCode)
        {
            var Information = _context.Informations.Where(s => s.NationalCode == nationalCode).FirstOrDefault();
            if (Information is null)
                return NotFound($"notfound InformationPerson with {nationalCode}");
            else
                return Ok(Information);
        }
        [HttpPut("UpdateInformation")]
        public IActionResult UpdateInformation(string nationalCode, UpdataInformationRequest request)
        {
            if (ModelState.IsValid)
            {
                var updateInformation = _context.Informations.Where(s => s.NationalCode == nationalCode).FirstOrDefault();
                if (updateInformation is not null)
                {
                    if (request.FirstName != null)
                        updateInformation.FirstName = request.FirstName;
                    if (request.LastName != null)
                        updateInformation.LastName = request.LastName;
                    if (request.NationalCode != null)
                        updateInformation.NationalCode = request.NationalCode;
                    var newInformation = _context.Informations.Update(updateInformation);
                    _context.SaveChanges();
                    return Ok(newInformation.Entity);
                }
                return NotFound("شخص با کد ملی وارد شده یافت نشد");
            }
            return BadRequest("اطلاعات ارسالی صحیح نمی باشد");
        }

        [HttpPost("AddInformation")]
        public IActionResult InsertInformation(InsertInformationRequest request)
        {
            var existInformation = _context.Informations.Where(s => s.NationalCode == request.NationalCode).FirstOrDefault();
            if (existInformation is null)
            {
                Entity.Information newInformation = new Entity.Information()
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    NationalCode = request.NationalCode,
                };

                var insertedInformation = _context.Informations.Add(newInformation);
                _context.SaveChanges();

                Wallet newWallet = new Wallet()
                {

                    Amount = 10000,
                    Block = false,
                    AmountBlock = 0,
                    InformationId = insertedInformation.Entity.Id,
                    NumberAccount = 0
                };

                var insertedWallet = _context.Wallets.Add(newWallet);
                _context.SaveChanges();
                return Ok();
            }
            return Ok();
        }

        [HttpPut("transferAmount")]
        public IActionResult transferAmount(TransferAmountRequest request)
        {
            if (ModelState.IsValid)
            {
                var personSource = _context.Informations.Where(s => s.NationalCode == request.NationalCodeSource).FirstOrDefault();
                var personDestination = _context.Informations.Where(s => s.NationalCode == request.NationalCodeDestination).FirstOrDefault();

                if (personSource is not null && personDestination is not null)
                {
                    var sourceWallet = _walletRepository.GetWallet(personSource.Id);
                    var destinationWallet = _walletRepository.GetWallet(personDestination.Id);

                    if (sourceWallet == null)
                        return BadRequest("کیف پول تعریف نشده");

                    if (sourceWallet.Amount < request.Amount)
                        return BadRequest("مبلغ در خواستی بیشتر از موچودی حساب می باشد");

                    if (sourceWallet.Block)
                    {
                        var subtraction = sourceWallet.Amount - sourceWallet.AmountBlock;
                        if (subtraction < request.Amount)
                            return BadRequest("مبلغ در خواستی بلوکه می باشد");
                    }
                    sourceWallet.Amount = sourceWallet.Amount - request.Amount;
                    destinationWallet.Amount = destinationWallet.Amount + request.Amount;

                    _walletRepository.UpdateWallet(sourceWallet);
                    _walletRepository.UpdateWallet(destinationWallet);
                    _context.SaveChanges();
                    return Ok("عملیات با موفیت انجا شد");
                }
                else
                {
                    return BadRequest("");
                }
            }
            return BadRequest();
        }

        [HttpPut("BlockAccount")]
        public IActionResult BlockAccount(string nationaCode, decimal amount)
        {
            if (nationaCode == null)
                return BadRequest("کد ملی را وارد کنید");
            if (amount == null || amount == 0)
                return BadRequest("مبلغ مورد نظر را وارد کنید");

            var person = _informationRepository.GetInformationByNationalCode(nationaCode);
            var wallet = _walletRepository.GetWallet(person.Id);

            wallet.Block = true;
            wallet.AmountBlock = amount;

            _walletRepository.UpdateWallet(wallet);
            _context.SaveChanges();
            return Ok();
        }
        private void UpdateWallet(Wallet wallet)
        {
            throw new NotImplementedException();
        }
    }
}
