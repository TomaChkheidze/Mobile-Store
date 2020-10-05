using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobile_Store.Models;
using Mobile_Store.Repositories;

namespace Mobile_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandsRepository _repo;

        public BrandsController(IBrandsRepository repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Gets all brands from database
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Succesfully returned brands from database</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Something happened in back-end</response>
        [HttpGet]
        public async Task<ActionResult<List<Brand>>> GetAll()
        {
            try
            {
                var result = await _repo.GetAllAsync();

                if (result == null || result.Count() <= 0)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
