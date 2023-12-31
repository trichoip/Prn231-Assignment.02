﻿using EBookStore.Application.DTOs;
using EBookStore.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace EBookStore.WebApi.Controllers;

public class UsersController : ODataController
{
    private readonly IUserService _entityService;

    public UsersController(IUserService entityService)
    {
        _entityService = entityService;
    }

    [EnableQuery]
    public async Task<IActionResult> Get() => Ok(_entityService.Entities);

    [EnableQuery]
    public async Task<IActionResult> Get(int key)
    {
        var entity = await _entityService.FindByIdAsync(key);
        if (entity == null) return NotFound();
        return Ok(entity);
    }

    public async Task<IActionResult> Put(int key, [FromBody] UserDto entityDto)
    {
        if (key != entityDto.UserId) return BadRequest();
        try
        {
            await _entityService.UpdateAsync(entityDto);
        }
        catch (KeyNotFoundException ex)
        {
            return Problem(statusCode: 404, detail: ex.Message);
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 500, detail: ex.Message);
        }

        return NoContent();
    }

    public async Task<IActionResult> Post([FromBody] UserDto entityDto)
    {
        if (entityDto.UserId != 0) return BadRequest();
        try
        {
            entityDto = await _entityService.CreateAsync(entityDto);
        }
        catch (KeyNotFoundException ex)
        {
            return Problem(statusCode: 404, detail: ex.Message);
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 500, detail: ex.Message);
        }

        return CreatedAtAction(nameof(Get), new { key = entityDto.UserId }, entityDto);
    }

    public async Task<IActionResult> Delete(int key)
    {
        try
        {
            await _entityService.RemoveAsync(key);
        }
        catch (KeyNotFoundException ex)
        {
            return Problem(statusCode: 404, detail: ex.Message);
        }
        catch (Exception ex)
        {
            return Problem(statusCode: 500, detail: ex.Message);
        }

        return NoContent();
    }

}
