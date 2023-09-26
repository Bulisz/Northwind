using Microsoft.AspNetCore.Mvc;
using Northwind.WebApi.Abstractions;
using Northwind.WebApi.Models.DTOs;

namespace Northwind.WebApi.Controllers;

[Route("[controller]")]
[ApiController]
public class NorthwindController : ControllerBase
{
    private readonly INorthwindService _service;

    public NorthwindController(INorthwindService service)
    {
        _service = service;
    }

    [HttpGet(nameof(GetAllProducts))]
    public async Task<ActionResult<IEnumerable<ProductDetailsDTO>>> GetAllProducts()
    {
        try
        {
            var products = await _service.GetAllProductsAsync();
            return Ok(products);
        }
        catch (TaskCanceledException)
        {
            return NotFound("No connection with the northwind server");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet(nameof(GetAllSuppliers))]
    public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetAllSuppliers()
    {
        try
        {
            var suppliers = await _service.GetAllSupplierAsync();
            return Ok(suppliers);
        }
        catch (TaskCanceledException)
        {
            return NotFound("No connection with the northwind server");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("GetOrdersOfSupplier/{supplierId}")]
    public async Task<ActionResult<IEnumerable<SupplierOrdersDTO>>> GetOrdersOfSupplier(int supplierId)
    {
        try
        {
            var suppliers = await _service.GetOrdersOfSupplierAsync(supplierId);
            return Ok(suppliers);
        }
        catch (TaskCanceledException)
        {
            return NotFound("No connection with the northwind server");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
