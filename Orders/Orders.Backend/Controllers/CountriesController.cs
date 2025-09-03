using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Shared.Entities;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[Controller]")] // [Controller] reemplaza el nombre api/Countries
public class CountriesController : ControllerBase
{
    private readonly DataContext _context; //Propiedad de lectura context

    public CountriesController(DataContext context)
    {
        _context = context; //A esa propiedad de lectura, le asigna lo que viene de context que está en el Datacontext de program donde se instanció la conexión al SQLServer
    }

    [HttpGet]
    public async Task<IActionResult> GetAsyn()
    {
        return Ok(await _context.Countries.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsyn(Country country)
    {
        _context.Countries.Add(country);
        await _context.SaveChangesAsync();
        return Ok(country);
    }
}