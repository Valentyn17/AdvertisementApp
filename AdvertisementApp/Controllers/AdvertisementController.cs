using AdvertisementApp.Models;
using AutoMapper;
using DataLayer.Entities;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvertisementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementRepository _advertisementRepository;
        private readonly IMapper _mapper;
        public AdvertisementController(IAdvertisementRepository advertisementRepository, IMapper mapper)
        {
            _advertisementRepository = advertisementRepository;
            _mapper = mapper;
        }
        // GET: api/<AdvertismentController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_mapper.Map<IEnumerable<ShortAdvertisementModel>>(_advertisementRepository.GetAll()));
        }


        // GET: api/<AdvertismentController>/sortByPrice
        [HttpGet("sortByPrice")]
        public IActionResult GetSorted()
        {

            return Ok(_mapper.Map<IEnumerable<ShortAdvertisementModel>>(_advertisementRepository.GetAll()).OrderBy(x=>x.Price));
        }

        // GET: api/<AdvertismentController>/sortByPrice
        [HttpGet("sortByPriceDesc")]
        public IActionResult GetSortedDescending()
        {

            return Ok(_mapper.Map<IEnumerable<ShortAdvertisementModel>>(_advertisementRepository.GetAll())
                .OrderByDescending(x => x.Price));
        }

        // GET api/<AdvertismentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, bool fields=false)
        {
            var advert= await _advertisementRepository.GetByIdAsync(id);
            if (advert == null)
                return BadRequest("AAdvertisement with such Id doesn't exist");
            if (fields)
            {
                return Ok(_mapper.Map<AdvertisementModel>(advert));
            }
            return  Ok(_mapper.Map<ShortAdvertisementModel>(advert));
        }

        // POST api/<AdvertismentController>
        [HttpPost]
        public IActionResult Post([FromBody] AdvertisementModel entity)
        {

            if (ModelState.IsValid)
            {
                var advert = _mapper.Map<Advertisement>(entity);
                try
                {
                    var id = _advertisementRepository.CreateAsync(advert);
                    return Ok(id);
                }
                catch (InvalidOperationException e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
                return BadRequest("Model is not valid");
        }


    }
}
