using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobile_Store.Commons;
using Mobile_Store.Models;
using Mobile_Store.Repositories;
using Mobile_Store.ViewModels;

namespace Mobile_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        private readonly IPhonesRepository _repo;
        private readonly IMapper _mapper;

        public PhonesController(IPhonesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all phones from database (paged and filtered)
        /// </summary>
        /// <param name="search">string to search phones by title</param>
        /// <param name="brand">BrandId to filter phones</param>
        /// <param name="priceLow">Lowest price point for filtering</param>
        /// <param name="priceHigh">Highest price point for filtering</param>
        /// <param name="pageIndex">Current page</param>
        /// <param name="pageSize">Items per page</param>
        /// <returns></returns>
        /// <response code="200">Succesfully returned filtered phones from database</response>
        /// <response code="400">Error malformed parameters were passed</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Something happened in back-end</response>
        [HttpGet]
        public async Task<ActionResult<PagedResult<PhoneViewModel>>> GetAll(string search, int? brand, double? priceLow, double? priceHigh, int pageIndex = 1, int pageSize = 5)
        {
            if (pageIndex <= 0) { return BadRequest("Page index must not have negative or 0 value!"); }
            if (pageSize <= 0) { return BadRequest("Page size must not have negative or 0 value!"); }
            //filter delegate
            IQueryable<Phone> filter(IQueryable<Phone> query)
            {
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => EF.Functions.Like(x.Title, $"%{search}%"));
                }

                if (brand != null)
                {
                    query = query.Where(x => x.BrandId == brand);
                }

                if (priceLow != null && priceHigh != null)
                {
                    query = query.Where(x => x.Price >= priceLow && x.Price <= priceHigh);
                }

                return query;
            }

            try
            {
                //call from db
                var result = await _repo.GetAllAsync(filter, pageIndex, pageSize);

                //mapping to viewmodel
                var mapped = new PagedResult<PhoneViewModel>()
                {
                    Data = _mapper.Map<List<PhoneViewModel>>(result.Data),
                    Count = result.Count,
                    PageIndex = result.PageIndex,
                    PageSize = result.PageSize,
                    TotalPages = result.TotalPages
                };

                if (mapped.Data == null || mapped.Count <= 0) { return NotFound(); }

                return Ok(mapped);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Gets signle phone's detailed information
        /// </summary>
        /// <param name="id">The Id of a Phone</param>
        /// <returns></returns>
        /// <response code="200">Returns the phone with specified Id</response>
        /// <response code="404">If the phone isn't found</response>
        /// <response code="500">Something happened in back-end</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Phone>> GetSingle(int id)
        {
            try
            {
                //call from db
                var mobilePhone = await _repo.GetAsync(id);

                //if not found
                if (mobilePhone == null)
                {
                    return NotFound();
                }

                return Ok(mobilePhone);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
