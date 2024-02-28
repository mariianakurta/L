using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogBrandController : ControllerBase
    {
        private readonly ILogger<CatalogBrandController> _logger;
        private readonly ICatalogBrandService _catalogBrandService;

        public CatalogBrandController(ILogger<CatalogBrandController> logger, ICatalogBrandService catalogBrandService)
        {
            _logger = logger;
            _catalogBrandService = catalogBrandService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CatalogBrandDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _catalogBrandService.GetCatalogBrandsAsync();
            return Ok(brands);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddBrand(CreateBrandRequest request)
        {
            var result = await _catalogBrandService.Add(request.Brand);
            return Ok(new AddItemResponse<int?> { Id = result });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] UpdateBrandRequest request)
        {
            var updated = await _catalogBrandService.Update(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var deleted = await _catalogBrandService.Delete(id);
            return Ok(deleted);
        }
    }
}
