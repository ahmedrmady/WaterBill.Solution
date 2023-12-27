using Microsoft.AspNetCore.Mvc;
using WaterBill.BAL.Specifications.SubscriberSpecifications;
using WaterBill.BAL.Specifications;
using WaterBill.DAL.Data.Entities;
using WaterBill.PL.ViewModels;
using WaterBill.SAL.Interfaces;
using AutoMapper;
using WaterBill.BAL.Specifications.InvoiceSpecifications;
using WaterBill.SAL.Helpers;

namespace WaterBill.PL.Controllers
{        
    public class InvoiceController : Controller
    {
        private readonly IServiceWithSpecs<Invoice> _service;
        private readonly IMapper _mapper;
        private readonly IWaterBillService _waterBillService;

        public InvoiceController(IServiceWithSpecs<Invoice> service,IMapper mapper,IWaterBillService waterBillService)
        {
            this._service = service;
            this._mapper = mapper;
            this._waterBillService = waterBillService;
        }

        [HttpGet]
        public IActionResult CreateNewInvoice()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewInvoice(InvoiceDto dto)
        {

            dto.Year = DateTime.Now.Year.ToString().Substring(2,2);
            var invoic = _mapper.Map<InvoiceDto,Invoice>(dto);
           var result = await _service.AddAsync(invoic);
            return RedirectToAction("Index","Home");

        }

        [HttpPost]
        public async Task<IActionResult> GetTheInvoceTotal([FromBody]WaterBillServicePrams prams)
        {
            var billComponents = await _waterBillService.GetInvoiceTotalBillComponets(prams);
            return Ok(billComponents);
        }



        [HttpGet]
        public IActionResult AllInvoices ()
        {

            return View();
        }

        [HttpGet]
        public async  Task<IActionResult> GetInvoices([FromQuery] int length, [FromQuery] int start)
        {
            var subsriptionPrams = new OptionsPrams()
            {
                PageSize = length,
                Search = /*HttpContext.Request.Query["search[value]"]*/ "",
                Skip = start,


            };
            var spec = new InvoiceSpecifications(subsriptionPrams);


            var subscritopinsList = await _service.GetAllWithSpecsAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Invoice>, IReadOnlyList<InvoiceDto>>(subscritopinsList);

            var countOfList = await _service.CountAsync(spec);
            var jsonData = new { recordsFiltered = countOfList, recordsTotal = countOfList, data };

            return Ok(jsonData);
        }
    }
}
