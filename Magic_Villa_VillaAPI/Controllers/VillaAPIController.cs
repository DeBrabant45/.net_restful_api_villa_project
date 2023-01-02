using AutoMapper;
using Magic_Villa_VillaAPI.Models;
using Magic_Villa_VillaAPI.Models.DTO;
using Magic_Villa_VillaAPI.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Magic_Villa_VillaAPI.Controllers;

[ApiController]
[Route("api/VillaAPI")]
public class VillaAPIController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IVillaRepository _respository;
    protected APIResponse _response;

    public VillaAPIController(IVillaRepository repository, IMapper mapper)
    {
        _respository = repository;
        _mapper = mapper;
        _response = new();
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<APIResponse>> GetVillas()
    {
        try
        {
            var villas = await _respository.GetAllAsync();
            _response.Result = _mapper.Map<List<VillaDTO>>(villas);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpGet("{id:int}", Name = nameof(GetVilla))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<APIResponse>> GetVilla(int id)
    {
        try
        {
            var villa = await _respository.GetAsync(v => v.Id == id);
            if (id == 0)
                return BadRequest();

            if (villa == null)
                return NotFound();

            _response.Result = _mapper.Map<VillaDTO>(villa);
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<APIResponse>> CreateVilla([FromBody]VillaCreateDTO createDTO)
    {
        try
        {
            var villa = await _respository.GetAsync(v => v.Name.ToLower() == createDTO.Name.ToLower());
            if (villa != null)
            {
                ModelState.AddModelError("", "Villa already exits!");
                return BadRequest(ModelState);
            }

            if (createDTO == null)
                return BadRequest(createDTO);

            var villaToAdd = _mapper.Map<Villa>(createDTO);
            await _respository.CreateAsync(villaToAdd);

            _response.Result = _mapper.Map<VillaDTO>(villaToAdd);
            _response.StatusCode = HttpStatusCode.OK;
            return CreatedAtRoute(nameof(GetVilla), new { id = villaToAdd.Id }, _response);
        }
        catch (Exception ex) 
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpDelete("{id:int}", Name = nameof(DeleteVilla))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
    {
        try
        {
            var villa = await _respository.GetAsync(v => v.Id == id);
            if (id == 0)
                return BadRequest();

            if (villa == null)
                return NotFound();

            await _respository.RemoveAsync(villa);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpPut("{id:int}", Name = nameof(UpdateVilla))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<APIResponse>> UpdateVilla(int id, [FromBody]VillaUpdateDTO updateDTO)
    {
        try
        {
            if (updateDTO == null || id != updateDTO.Id)
                return BadRequest();

            var villa = await _respository.GetAsync(v => v.Id == updateDTO.Id, isTracked:false);
            if (villa == null)
            {
                ModelState.AddModelError("", "Villa does not exits!");
                return BadRequest(ModelState);
            }

            var updatedVilla = _mapper.Map<Villa>(updateDTO);
            await _respository.UpdateAsync(updatedVilla);
            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess = true;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpPatch("{id:int}", Name = nameof(UpdatePartialVilla))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDTO> patchDTO)
    {
        if (patchDTO == null || id == 0)
            return BadRequest();

        var villa = await _respository.GetAsync(v => v.Id == id, isTracked:false);
        var updatedDTO = _mapper.Map<VillaUpdateDTO>(villa);

        if (villa == null)
            return BadRequest();

        patchDTO.ApplyTo(updatedDTO, ModelState);
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var villaUpdated = _mapper.Map<Villa>(updatedDTO);
        await _respository.UpdateAsync(villaUpdated);
        return NoContent();
    }
}
