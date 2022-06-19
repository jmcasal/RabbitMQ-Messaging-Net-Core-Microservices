using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Domain.Models;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace MicroRabbit.Banking.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // Get aspi/banking
        [HttpGet()]
        [Route("get-accounts")]
        [SwaggerOperation(OperationId ="GetAccounts")]
        public ActionResult<IEnumerable<Account>> GetAccounts()
        {
            return Ok(_accountService.GetAccounts()); 
        }
    }
}