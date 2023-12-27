using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WaterBill.DAL.Data.Entities;
using WaterBill.PL.ViewModels;
using WaterBill.SAL.Interfaces;

namespace WaterBill.PL.Controllers
{
    public class RrealEstateController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IService<RrealEstateType> _service;

        public RrealEstateController(IMapper mapper,IService<RrealEstateType> service)
        {
            this._mapper = mapper;
            this._service = service;
        }
        [HttpGet]
        public IActionResult UpdateRrealEstate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRrealEstate(RrealEstateDto dto)
        {
            if (ModelState.IsValid)
            {
                var rrealEstate = _mapper.Map<RrealEstateDto, RrealEstateType>(dto);

               var result = await _service.UpdateAsync(rrealEstate);
            }
            return RedirectToAction(nameof(UpdateRrealEstate));
        }

        [HttpGet]
        public async Task<IActionResult> GetRrealEstateData (string Code )
        {
           var rrealEstate =  await _service.GetAsync(Code);
            if (rrealEstate is null) return NotFound();
            
            return Ok(rrealEstate);
        }

    }
}
