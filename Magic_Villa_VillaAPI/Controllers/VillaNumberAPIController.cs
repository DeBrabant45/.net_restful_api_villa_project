using AutoMapper;
using Magic_Villa_VillaAPI.Models;
using Magic_Villa_VillaAPI.Models.DTO;
using Magic_Villa_VillaAPI.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Magic_Villa_VillaAPI.Controllers;

[ApiController]
[Route("api/VillaNumberAPI")]
public class VillaNumberAPIController : ControllerBase
{
    private readonly IVillaNumberRepository _numberRepository;
    private readonly IVillaRepository _villaRepository;
    private readonly IMapper _mapper;
    private readonly APIResponse _response;

    public VillaNumberAPIController(IVillaNumberRepository numberRepository, IVillaRepository villaRepository,IMapper mapper)
    {
        _numberRepository = numberRepository;
        _villaRepository = villaRepository;
        _mapper = mapper;
        _response = new APIResponse();
    }

    [HttpPost("{number:int}", Name = nameof(CreateVillaNumberAsync))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<APIResponse>> CreateVillaNumberAsync(int number, [FromBody] VillaNumberCreateDTO createDTO)
    {
        try
        {
            if (createDTO == null || number <= 0 || number != createDTO.Number)
                return BadRequest(createDTO);

            var villaNumber = await _numberRepository.GetAsync(v => v.Number == createDTO.Number);
            if (villaNumber != null)
            {
                ModelState.AddModelError("", "Villa Number already exits!");
                return BadRequest(ModelState);
            }

            var villa = await _villaRepository.GetAsync(v => v.Id == createDTO.VillaId);
            if (villa == null)
            {
                ModelState.AddModelError("", "Villa does not exits!");
                return BadRequest(ModelState);
            }

            var newVillaNumber = _mapper.Map<VillaNumber>(createDTO);
            await _numberRepository.CreateAsync(newVillaNumber);

            _response.Result = _mapper.Map<VillaNumberDTO>(newVillaNumber);
            _response.StatusCode = HttpStatusCode.OK;
            return CreatedAtRoute(nameof(GetVillaNumberAsync), new { number = newVillaNumber.Number }, _response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<APIResponse>> GetAllVillaNumbersAsync()
    {
        try
        {
            var villaNumbers = await _numberRepository.GetAllAsync();
            _response.Result = _mapper.Map<List<VillaNumberDTO>>(villaNumbers);
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

    [HttpGet("{number:int}", Name = nameof(GetVillaNumberAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<APIResponse>> GetVillaNumberAsync(int number)
    {
        try
        {
            var villaNumber = await _numberRepository.GetAsync(v => v.Number == number);
            if (villaNumber == null)
                return NotFound();

            _response.Result = _mapper.Map<VillaNumberDTO>(villaNumber);
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

    [HttpPut("{number:int}", Name = nameof(UpdateVillaNumberAsync))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<APIResponse>> UpdateVillaNumberAsync(int number, [FromBody] VillaNumberUpdateDTO updateDTO)
    {
        try
        {
            if (number <= 0 || updateDTO == null || number != updateDTO.Number)
                return BadRequest(updateDTO);

            var villaNumber = await _numberRepository.GetAsync(v => v.Number == number, isTracked: false);
            if (villaNumber == null)
            {
                ModelState.AddModelError("", "Villa Number does not exits!");
                return BadRequest(ModelState);
            }

            var villa = await _villaRepository.GetAsync(v => v.Id == updateDTO.VillaId);
            if (villa == null)
            {
                ModelState.AddModelError("", "Villa does not exits!");
                return BadRequest(ModelState);
            }

            var updatedVillaNumber = _mapper.Map<VillaNumber>(updateDTO);
            await _numberRepository.UpdateAsync(updatedVillaNumber);

            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }

    [HttpDelete("{number:int}", Name = nameof(DeleteVillaNumberAsync))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<APIResponse>> DeleteVillaNumberAsync(int number)
    {
        try
        {
            if (number <= 0)
                return BadRequest();

            var villaNumber = await _numberRepository.GetAsync(v => v.Number == number);
            if (villaNumber == null)
                return NotFound();

            await _numberRepository.RemoveAsync(villaNumber);
            _response.StatusCode = HttpStatusCode.NoContent;
            return Ok(_response);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() };
        }
        return _response;
    }
}
