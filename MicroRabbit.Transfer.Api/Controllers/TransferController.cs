using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

using Microsoft.AspNetCore.Mvc;

using Swashbuckle.AspNetCore.Annotations;

namespace MicroRabbit.Transfer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService TransferService)
        {
            _transferService = TransferService;
        }

        // Get aspi/Transfer
        [HttpGet()]
        [Route("get-Transfers")]
        [SwaggerOperation(OperationId ="GetTransfers")]
        public ActionResult<IEnumerable<TransferLog>> GetTransfers()
        {
            return Ok(_transferService.GetTransferLogs()); 
        }

        /*
        [HttpPost]
        public IActionResult Post([FromBody] TransferTransfer TransferTransfer)
        {
            _transferService.Transfer(TransferTransfer);
            return Ok(TransferTransfer);
        }
        */

    }
}