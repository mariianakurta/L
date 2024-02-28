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


namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogBffController : ControllerBase
    {
        private readonly ILogger<CatalogBffController> _logger;
        private readonly ICatalogService _catalogService;
        private readonly ICatalogItemService _catalogItemService;
        private readonly ICatalogBrandService _catalogBrandService;
        private readonly ICatalogTypeService _catalogTypeService;

        public CatalogBffController(
            ILogger<CatalogBffController> logger,
            ICatalogService catalogService,
            ICatalogItemService catalogItemService,
            ICatalogBrandService catalogBrandService,
            ICatalogTypeService catalogTypeService)
        {
            _logger = logger;
            _catalogService = catalogService;
            _catalogItemService = catalogItemService;
            _catalogBrandService = catalogBrandService;
            _catalogTypeService = catalogTypeService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Items(PaginatedItemsRequest request)
        {
            var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex);
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CatalogItemDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetById(int id)
        {
            var catalogItem = await _catalogService.GetCatalogItemByIdAsync(id);
            if (catalogItem == null)
            {
                return NotFound();
            }
            return Ok(catalogItem);
        }

        [HttpGet("brands/{brand}")]
        [ProducesResponseType(typeof(IEnumerable<CatalogItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByBrand(string brand)
        {
            var catalogItems = await _catalogService.GetCatalogItemsByBrandAsync(brand);
            return Ok(catalogItems);
        }

        [HttpGet("types/{type}")]
        [ProducesResponseType(typeof(IEnumerable<CatalogItemDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByType(string type)
        {
            var catalogItems = await _catalogService.GetCatalogItemsByTypeAsync(type);
            return Ok(catalogItems);
        }

        [HttpGet("brands")]
        [ProducesResponseType(typeof(IEnumerable<CatalogBrandDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await _catalogService.GetCatalogBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("types")]
        [ProducesResponseType(typeof(IEnumerable<CatalogTypeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTypes()
        {
            var types = await _catalogService.GetCatalogTypesAsync();
            return Ok(types);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Add(CreateProductRequest request)
        {
            var result = await _catalogItemService.Add(request.Name, request.Description, request.Price, request.AvailableStock, request.CatalogBrandId, request.CatalogTypeId, request.PictureFileName);
            return Ok(new AddItemResponse<int?> { Id = result });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] UpdateItemRequest request)
        {
            var updated = await _catalogItemService.Update(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var deleted = await _catalogItemService.Delete(id);
            return Ok(deleted);
        }

        [HttpPut("brands/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBrand(int id, [FromBody] UpdateBrandRequest request)
        {
            var updated = await _catalogBrandService.Update(id, request);
            return Ok(updated);
        }

        [HttpDelete("brands/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var deleted = await _catalogBrandService.Delete(id);
            return Ok(deleted);
        }

        [HttpPut("types/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateType(int id, [FromBody] UpdateTypeRequest request)
        {
            var updated = await _catalogTypeService.Update(id, request);
            return Ok(updated);
        }

        [HttpDelete("types/{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteType(int id)
        {
            var deleted = await _catalogTypeService.Delete(id);
            return Ok(deleted);
        }
    }
}
