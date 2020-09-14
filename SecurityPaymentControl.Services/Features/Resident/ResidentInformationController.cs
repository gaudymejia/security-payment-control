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
        [Route("save-resident")]
        [HttpPost]
        public async Task<IActionResult> SaveResident([FromBody] ResidentRequest residentResquest)
        {
            var message = await _residentInformationService.SaveResident(residentResquest);
            return Ok(message);
        }


    }
}
