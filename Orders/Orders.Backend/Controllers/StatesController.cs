using Microsoft.AspNetCore.Mvc;
using Orders.Backend.UnitsOfWork.Implementations;
using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.DTOs;
using Orders.Shared.Entities;

namespace Orders.Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatesController : GenericController<State>
{
    private readonly IStatesUnitOfWork _statesUnitOfwork;

    public StatesController(IGenericUnitOfWork<State> unitOfWork, IStatesUnitOfWork statesUnitOfwork) : base(unitOfWork)
    {
        _statesUnitOfwork = statesUnitOfwork;
    }

    [HttpGet("paginated")]
    public override async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _statesUnitOfwork.GetAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpGet("totalRecords")]
    public override async Task<IActionResult> GetTotalRecordsAsync([FromQuery] PaginationDTO pagination)
    {
        var action = await _statesUnitOfwork.GetTotalRecordsAsync(pagination);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpGet]
    public override async Task<IActionResult> GetAsync()
    {
        var action = await _statesUnitOfwork.GetAsync();
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return BadRequest(action.Message);
    }

    [HttpGet("{id}")]
    public override async Task<IActionResult> GetAsync(int id)
    {
        var action = await _statesUnitOfwork.GetAsync(id);
        if (action.WasSuccess)
        {
            return Ok(action.Result);
        }
        return NotFound();
    }
}
