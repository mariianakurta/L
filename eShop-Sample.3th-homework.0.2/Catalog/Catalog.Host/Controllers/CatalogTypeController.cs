using System.Net;
using System.Threading.Tasks;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Catalog.Host.Controllers
{
    [ApiController]
    [Route(ComponentDefaults.DefaultRoute)]
    public class CatalogTypeController : ControllerBase
    {
        private readonly ILogger<CatalogTypeController> _logger;
        private readonly ICatalogTypeService _catalogTypeService;

        public CatalogTypeController(ILogger<CatalogTypeController> logger, ICatalogTypeService catalogTypeService)
        {
            _logger = logger;
            _catalogTypeService = catalogTypeService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CatalogTypeDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTypes()
        {
            var types = await _catalogTypeService.GetCatalogTypesAsync();
            return Ok(types);
        }

        [HttpPost]
        [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddType(CreateTypeRequest request)
        {
            var result = await _catalogTypeService.Add(request.Type);
            return Ok(new AddItemResponse<int?> { Id = result });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateType(int id, [FromBody] UpdateTypeRequest request)
        {
            var updated = await _catalogTypeService.Update(id, request);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteType(int id)
        {
            var deleted = await _catalogTypeService.Delete(id);
            return Ok(deleted);
        }
    }
}
