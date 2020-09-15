using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SecurityPaymentControl.Services.Features.Resident;
using SecurityPaymentControl.Services.Helpers;

namespace SecurityPaymentControl.Services.Features.Residents
{
    [Route("api/resident")]
    [ApiController]
    public class ResidentInformationController : ControllerBase
    {
        private readonly ResidentInformationService _residentInformationService;

        public ResidentInformationController(ResidentInformationService residentInformationService)
        {
            _residentInformationService = residentInformationService;

        }

        [Route("get-all-residents")]
        [HttpGet]
        public async Task<IActionResult> GetAllResidents()
        {
            var message = await _residentInformationService.GetResidents();
            return Ok(message);
        }


        [Route("save-resident")]
        [HttpPost]
        public async Task<IActionResult> SaveResident([FromBody] ResidentRequest residentResquest)
        {
            var message = await _residentInformationService.SaveResident(residentResquest);
            return Ok(message);
        }

        [Route("delete-resident")]
        [HttpDelete]
        public async Task<IActionResult> DeleteResident(string residentId)
        {
            var message = await _residentInformationService.DeleteResident(residentId);
            return Ok(message);
        }


    }
}
