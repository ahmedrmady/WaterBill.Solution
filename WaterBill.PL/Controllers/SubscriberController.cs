using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WaterBill.BAL.Specifications.SubscriptionSpecifications;
using WaterBill.BAL.Specifications;
using WaterBill.DAL.Data.Entities;
using WaterBill.PL.ViewModels;
using WaterBill.SAL.Interfaces;
using WaterBill.BAL.Specifications.SubscriberSpecifications;

namespace WaterBill.PL.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly IServiceWithSpecs<Subscriber> _service;
        private readonly IMapper _mapper;

        public SubscriberController(IServiceWithSpecs<Subscriber> service,IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        [HttpGet]
        public  IActionResult UpdateSubscriberData()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscriberData(SubscriberDto dto)
        {
            if(!ModelState.IsValid) return View(dto);

            var mappedSubscriber = _mapper.Map<SubscriberDto,Subscriber>(dto);

         return  await _service.UpdateAsync(mappedSubscriber) is null? BadRequest(): Ok(dto);
       
        }

        [HttpGet]
        public async Task<ActionResult<SubscriberDto>> GetSubscriberById ( [FromQuery] string id)
        {
           var subscriber = await _service.GetAsync(id);

            return subscriber is null ? NotFound() : Ok(_mapper.Map<Subscriber, SubscriberDto>(subscriber));
        }



        [HttpGet]
        public IActionResult AllSubscribers ()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetSubscribersAsync([FromQuery] int length, [FromQuery] int start)
        {

            var subsriptionPrams = new OptionsPrams()
            {
                PageSize = length,
                Search = HttpContext.Request.Query["search[value]"],
                Skip = start,


            };
            var spec = new SubscriberSpecifications(subsriptionPrams);


            var subscritopinsList = await _service.GetAllWithSpecsAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Subscriber>, IReadOnlyList<SubscriberToReturnDto>>(subscritopinsList);

            var countOfList = await _service.CountAsync(spec);
            var jsonData = new { recordsFiltered = countOfList, recordsTotal = countOfList, data };

            return Ok(jsonData);
        }



    }
}
