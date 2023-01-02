using AutoMapper;
using Magic_Villa_Web.Domain.Models.DTO;
using Magic_Villa_Web.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Magic_Villa_Web.Controllers;
public class VillaNumberController : Controller
{
    private readonly IVillaNumberService _villaNumberService;
    private readonly IMapper _mapper;

    public VillaNumberController(IVillaNumberService villaService, IMapper mapper)
    {
        _villaNumberService = villaService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _villaNumberService.GetAllAsync<APIResponse>();
        if (response == null && !response.IsSuccess)
            return View("NotFound");

        var villaNumbers = JsonConvert.DeserializeObject<List<VillaNumberDTO>>(Convert.ToString(response.Result));
        return View(villaNumbers);
    }
}
