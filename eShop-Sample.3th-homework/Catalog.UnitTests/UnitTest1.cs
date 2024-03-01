using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Catalog.Host.Controllers;
using Catalog.Host.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

public class CatalogBffControllerTests
{
    [Fact]
    public async Task GetById_ReturnsOkResultWithCatalogItemDto()
    {
        var catalogServiceMock = new Mock<ICatalogService>();
        catalogServiceMock.Setup(c => c.GetCatalogItemByIdAsync(It.IsAny<int>())).ReturnsAsync(new CatalogItemDto());

        var controller = new CatalogBffController(null, catalogServiceMock.Object, null, null, null);

        var result = await controller.GetById(1);

        var okResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsType<CatalogItemDto>(okResult.Value);
        Assert.NotNull(model);
    }

    [Fact]
    public async Task GetById_ReturnsNotFoundResult()
    {
        var catalogServiceMock = new Mock<ICatalogService>();
        catalogServiceMock.Setup(c => c.GetCatalogItemByIdAsync(It.IsAny<int>())).ReturnsAsync(null);

        var controller = new CatalogBffController(null, catalogServiceMock.Object, null, null, null);

        var result = await controller.GetById(1);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetByBrand_ReturnsOkResultWithCatalogItemsDto()
    {
        var catalogServiceMock = new Mock<ICatalogService>();
        catalogServiceMock.Setup(c => c.GetCatalogItemsByBrandAsync(It.IsAny<string>())).ReturnsAsync(new List<CatalogItemDto>());

        var controller = new CatalogBffController(null, catalogServiceMock.Object, null, null, null);

        var result = await controller.GetByBrand("SomeBrand");

        var okResult = Assert.IsType<OkObjectResult>(result);
        var models = Assert.IsType<List<CatalogItemDto>>(okResult.Value);
        Assert.NotNull(models);
    }

    [Fact]
    public async Task GetByBrand_ReturnsNotFoundResult()
    {
        var catalogServiceMock = new Mock<ICatalogService>();
        catalogServiceMock.Setup(c => c.GetCatalogItemsByBrandAsync(It.IsAny<string>())).ReturnsAsync(null);

        var controller = new CatalogBffController(null, catalogServiceMock.Object, null, null, null);

        var result = await controller.GetByBrand("NonExistentBrand");

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetByType_ReturnsOkResultWithCatalogItemsDto()
    {
        var catalogServiceMock = new Mock<ICatalogService>();
        catalogServiceMock.Setup(c => c.GetCatalogItemsByTypeAsync(It.IsAny<string>())).ReturnsAsync(new List<CatalogItemDto>());

        var controller = new CatalogBffController(null, catalogServiceMock.Object, null, null, null);

        var result = await controller.GetByType("SomeType");

        var okResult = Assert.IsType<OkObjectResult>(result);
        var models = Assert.IsType<List<CatalogItemDto>>(okResult.Value);
        Assert.NotNull(models);
    }

    [Fact]
    public async Task GetByType_ReturnsNotFoundResult()
    {
        var catalogServiceMock = new Mock<ICatalogService>();
        catalogServiceMock.Setup(c => c.GetCatalogItemsByTypeAsync(It.IsAny<string>())).ReturnsAsync(null);

        var controller = new CatalogBffController(null, catalogServiceMock.Object, null, null, null);

        var result = await controller.GetByType("NonExistentType");

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetBrands_ReturnsOkResultWithCatalogBrandDtos()
    {
        var catalogServiceMock = new Mock<ICatalogService>();
        catalogServiceMock.Setup(c => c.GetCatalogBrandsAsync()).ReturnsAsync(new List<CatalogBrandDto>());

        var controller = new CatalogBffController(null, catalogServiceMock.Object, null, null, null);

        var result = await controller.GetBrands();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var brands = Assert.IsType<List<CatalogBrandDto>>(okResult.Value);
        Assert.NotNull(brands);
    }

    [Fact]
    public async Task GetBrands_ReturnsNotFoundResult()
    {
        var catalogServiceMock = new Mock<ICatalogService>();
        catalogServiceMock.Setup(c => c.GetCatalogBrandsAsync()).ReturnsAsync(null);

        var controller = new CatalogBffController(null, catalogServiceMock.Object, null, null, null);

        var result = await controller.GetBrands();

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetTypes_ReturnsOkResultWithCatalogTypeDtos()
    {
        var catalogServiceMock = new Mock<ICatalogService>();
        catalogServiceMock.Setup(c => c.GetCatalogTypesAsync()).ReturnsAsync(new List<CatalogTypeDto>());

        var controller = new CatalogBffController(null, catalogServiceMock.Object, null, null, null);

        var result = await controller.GetTypes();

        var okResult = Assert.IsType<OkObjectResult>(result);
        var types = Assert.IsType<List<CatalogTypeDto>>(okResult.Value);
        Assert.NotNull(types);
    }

    [Fact]
    public async Task GetTypes_ReturnsNotFoundResult()
    {
        var catalogServiceMock = new Mock<ICatalogService>();
        catalogServiceMock.Setup(c => c.GetCatalogTypesAsync()).ReturnsAsync(null);

        var controller = new CatalogBffController(null, catalogServiceMock.Object, null, null, null);

        var result = await controller.GetTypes();

        Assert.IsType<NotFoundResult>(result);
    }



    [Fact]
    public async Task AddBrand_ReturnsOkResultWithAddItemResponse()
    {
        var catalogBrandServiceMock = new Mock<ICatalogBrandService>();
        catalogBrandServiceMock.Setup(c => c.Add(It.IsAny<string>())).ReturnsAsync(1);

        var controller = new CatalogBffController(null, null, catalogBrandServiceMock.Object, null, null);

        var result = await controller.AddBrand(new CreateBrandRequest { Brand = "NewBrand" });

        var okResult = Assert.IsType<OkObjectResult>(result);
        var response = Assert.IsType<AddItemResponse<int?>>(okResult.Value);
        Assert.NotNull(response);
        Assert.Equal(1, response.Id);
    }

    [Fact]
    public async Task AddBrand_ReturnsBadRequestResult()
    {
        var catalogBrandServiceMock = new Mock<ICatalogBrandService>();
        catalogBrandServiceMock.Setup(c => c.Add(It.IsAny<string>())).ReturnsAsync(null);

        var controller = new CatalogBffController(null, null, catalogBrandServiceMock.Object, null, null);

        var result = await controller.AddBrand(new CreateBrandRequest { Brand = "ExistingBrand" });

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task UpdateBrand_ReturnsOkResult()
    {
        var catalogBrandServiceMock = new Mock<ICatalogBrandService>();
        catalogBrandServiceMock.Setup(c => c.Update(It.IsAny<int>(), It.IsAny<UpdateBrandRequest>())).ReturnsAsync(true);

        var controller = new CatalogBffController(null, null, catalogBrandServiceMock.Object, null, null);

        var result = await controller.UpdateBrand(1, new UpdateBrandRequest { Brand = "UpdatedBrand" });

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task UpdateBrand_ReturnsBadRequestResult()
    {
        var catalogBrandServiceMock = new Mock<ICatalogBrandService>();
        catalogBrandServiceMock.Setup(c => c.Update(It.IsAny<int>(), It.IsAny<UpdateBrandRequest>())).ReturnsAsync(false);

        var controller = new CatalogBffController(null, null, catalogBrandServiceMock.Object, null, null);

        var result = await controller.UpdateBrand(1, new UpdateBrandRequest { Brand = "ExistingBrand" });

        Assert.IsType<BadRequestResult>(result);
    }

    [Fact]
    public async Task DeleteBrand_ReturnsOkResult()
    {
        var catalogBrandServiceMock = new Mock<ICatalogBrandService>();
        catalogBrandServiceMock.Setup(c => c.Delete(It.IsAny<int>())).ReturnsAsync(true);

        var controller = new CatalogBffController(null, null, catalogBrandServiceMock.Object, null, null);

        var result = await controller.DeleteBrand(1);

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task DeleteBrand_ReturnsBadRequestResult()
    {
        var catalogBrandServiceMock = new Mock<ICatalogBrandService>();
        catalogBrandServiceMock.Setup(c => c.Delete(It.IsAny<int>())).ReturnsAsync(false);

        var controller = new CatalogBffController(null, null, catalogBrandServiceMock.Object, null, null);

        var result = await controller.DeleteBrand(1);

        Assert.IsType<BadRequestResult>(result);
    }


    [Fact]
    public async Task UpdateItem_ReturnsOkResult()
    {
        var catalogItemServiceMock = new Mock<ICatalogItemService>();
        catalogItemServiceMock.Setup(c => c.Update(It.IsAny<int>(), It.IsAny<UpdateItemRequest>())).ReturnsAsync(true);

        var controller = new CatalogBffController(null, null, null, catalogItemServiceMock.Object, null);

        var result = await controller.UpdateItem(1, new UpdateItemRequest());

        Assert.IsType<OkResult>(result);
    }

    [Fact]
    public async Task UpdateItem_ReturnsBadRequestResult()
    {
        var catalogItemServiceMock = new Mock<ICatalogItemService>();
        catalogItemServiceMock.Setup(c => c.Update(It.IsAny<int>(), It.IsAny<UpdateItemRequest>())).ReturnsAsync(false);

        var controller = new CatalogBffController(null, null, null, catalogItemServiceMock.Object, null);

        var result = await controller.UpdateItem(1, new UpdateItemRequest());

        Assert.IsType<BadRequestResult>(result);
    }
}
