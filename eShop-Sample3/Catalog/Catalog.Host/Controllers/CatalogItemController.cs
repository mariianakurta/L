using System.Net;
using System.Threading.Tasks;
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
    public class CatalogItemController : ControllerBase
    {
        private readonly ILogger<CatalogItemController> _logger;
        private readonly ICatalogItemService _catalogItemService;

        public CatalogItemController(
            ILogger<CatalogItemController> logger,
            ICatalogItemService catalogItemService)
        {
            _logger = logger;
            _catalogItemService = catalogItemService;
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
    }
}
