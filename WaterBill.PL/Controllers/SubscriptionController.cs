using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;
using WaterBill.BAL.Specifications;
using WaterBill.BAL.Specifications.SubscriptionSpecifications;
using WaterBill.DAL.Data.Entities;
using WaterBill.PL.ViewModels;
using WaterBill.SAL.Interfaces;

namespace WaterBill.PL.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly IServiceWithSpecs<Subscription> _service;
        private readonly IMapper _mapper;

        public SubscriptionController(IServiceWithSpecs<Subscription> service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }


        [HttpGet]
        public IActionResult UpdateSubscription()
        {
            
           
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSubscription(SubscriptionDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var subsription = _mapper.Map<SubscriptionDto, Subscription>(dto);

            var updatedObject = new Subscription();
            //check if found update,else add it
            var result = await _service.GetAsync(subsription.Id);
            if (result is null)
            
                // if no record to update then add new subscription
                 updatedObject = await _service.AddAsync(subsription);
            
            else
             
                 updatedObject = await _service.UpdateAsync(subsription);
            

            return updatedObject is null ? RedirectToAction("Index","Home") : View(dto);


        }

        [HttpGet]
        public  IActionResult AllSubscriptions()
        {

            return View();
        }

        [HttpGet]
        public async  Task<IActionResult> GetSubscriptionById([FromQuery] string id)
        {

            var subscription = await _service.GetWithSpecAsync(new SubscriptionSpecifications()
            {
                Criteria = S=>S.Id==id
            }
                );

            if (subscription is null) return NotFound();

            var subscriptionDto = _mapper.Map<Subscription, SubscriptionToReturnDto>(subscription);
            return Ok(subscriptionDto);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllSubscriptions([FromQuery]int length, [FromQuery] int start)
        {
           
            var subsriptionPrams = new OptionsPrams()
            {
                PageSize = length,
                Search =  HttpContext.Request.Query["search[value]"],
                Skip = start,
               

            };
            var spec = new SubscriptionSpecifications(subsriptionPrams);


            var subscritopinsList = await _service.GetAllWithSpecsAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Subscription>, IReadOnlyList<SubscriptionToReturnDto>>(subscritopinsList);

            var countOfList = await _service.CountAsync(spec);
            var jsonData = new { recordsFiltered = countOfList, recordsTotal = countOfList, data };
           
            return Ok(jsonData);
        }

    }
}
