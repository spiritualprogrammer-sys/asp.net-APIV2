using System;
using APIV2.Data;
using APIV2.Dtos.Stock;
using APIV2.Interfaces;
using APIV2.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIV2.Controllers;


[Route("api/stock")]
[ApiController]
public class StocksController: ControllerBase
{
    private readonly ApplicationContextDb _context;
    private readonly IStockRepository _stockRepository;

    public StocksController(ApplicationContextDb context,  IStockRepository stockRepository)
    {
          _stockRepository = stockRepository;
        _context = context;
    }


    [HttpGet]
    public async  Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
          return BadRequest(ModelState); 
        var stocks = await _stockRepository.GetAllAsync();
        var stockDto = stocks.Select(s => s.ToStockDto());
        
        return Ok(stockDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult>  GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);
        var stock = await _stockRepository.GetByIdAsync(id);
        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public  async  Task<IActionResult> Create([FromBody] CreateStockRequestDto stockRequestDto)
    {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);
        var stockModel = stockRequestDto.ToStockFromCreateDto();
        await _stockRepository.CreateAsync(stockModel);
        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());

    }

    [HttpPut]
    [Route("{id:int}")]
    public  async  Task<IActionResult> Update([FromRoute] int id,  [FromBody] UpdateStockRequestDto stockRequestDto)
    {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);
        var stockModel = await _stockRepository.UpdateAsync(id, stockRequestDto);    

        return Ok(stockModel.ToStockDto()); 
        
    }

    [HttpDelete]
    [Route("{id:int}")]
    public  async  Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
          return BadRequest(ModelState);
        var stockModel = await _stockRepository.DeleteAsync(id);
        if (stockModel == null)
        {
            return NotFound("StocK does not exist");
        }
        return Ok(stockModel); 
        
    }

}
