using Microsoft.AspNetCore.Mvc;
using SecurityPaymentControl.Services.Features.VoucherResident;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityPaymentControl.Services.Features.VoucherResident
{

    [Route("api/voucher")]
    [ApiController]
    public class VoucherController : ControllerBase
    {

        private readonly VoucherService _voucherService;
        public VoucherController(VoucherService voucherService)
        {
            _voucherService = voucherService;

        }

        [Route("get-vouchers")]
        [HttpGet]
        public async Task<IActionResult> GetVouchersByResidentId(string residentId)
        {
            var message = await _voucherService.GetVouchersByResidentId(residentId);
            return Ok(message);
        }


        [Route("save-voucher-by-resident")]
        [HttpPost]
        public async Task<IActionResult> SaveVoucher([FromBody] VoucherRequest voucherRequest)
        {
            var message = await _voucherService.SaveVoucher(voucherRequest);
            return Ok(message);
        }
    }
}
