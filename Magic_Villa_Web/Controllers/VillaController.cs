using AutoMapper;
using Magic_Villa_Web.Domain.Models.DTO;
using Magic_Villa_Web.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Magic_Villa_Web.Controllers;
public class VillaController : Controller
{
    private readonly IVillaService _villaService;
    private readonly IMapper _mapper;

    public VillaController(IVillaService villaService, IMapper mapper)
    {
        _villaService = villaService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _villaService.GetAllAsync<APIResponse>();
        if (response == null && !response.IsSuccess)
            return View("NotFound");

        var villas = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
        return View(villas);
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(VillaCreateDTO createDTO)
    {
        if (!ModelState.IsValid)
            return View(createDTO);

        var response = await _villaService.CreateAsync<APIResponse>(createDTO);
        if (response == null && !response.IsSuccess)
            return View(createDTO);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Update(int id)
    {
        var response = await _villaService.GetAsync<APIResponse>(id);
        if (response == null)
            return View("NotFound");

        var villa = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));

        return View(_mapper.Map<VillaUpdateDTO>(villa));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Update(VillaUpdateDTO updateDTO)
    {
        if (!ModelState.IsValid)
            return View(updateDTO);

        var response = await _villaService.UpdateAsync<APIResponse>(updateDTO);
        if (response == null && !response.IsSuccess)
            return View(updateDTO);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _villaService.DeleteAsync<APIResponse>(id);
        if (response == null || !response.IsSuccess)
            return View("NotFound");

        return RedirectToAction(nameof(Index));
    }
}
