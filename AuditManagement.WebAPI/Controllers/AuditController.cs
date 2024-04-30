using AuditManagement.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AuditManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuditController : ControllerBase
    {
        private readonly IAuditManager auditManager;

        public AuditController(IAuditManager fileManager)
        {
            this.auditManager = fileManager;
        }

        [HttpPost("populateDB")]
        [SwaggerOperation(
          Summary = "Populate DB",
          Description = "Initial empty db setup.")]
        public async Task<IActionResult> PopulateDB()
        {
            var projectFolder = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            var filePath = Path.Combine(projectFolder, @"AuditManagement.WebAPI\Data\AuditData.csv");

            var insertedRecords = await auditManager.InsertTransactionDataAsync(filePath);
            return Ok(insertedRecords);
        }


        [HttpPost("sap")]
        [SwaggerOperation(
          Summary = "Post to SAP",
          Description = "Post all the data in db to SAP in batches")]

        public async Task<IActionResult> PostToSAP()
        {
            (var isSuccess, var errorMessage) = await auditManager.PostSAPTransactions();
            if (isSuccess)
            {
                return NoContent();
            }

            return BadRequest(errorMessage);
        }

    }
}
