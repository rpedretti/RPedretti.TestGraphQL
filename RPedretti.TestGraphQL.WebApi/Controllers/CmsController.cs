using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RPedretti.TestGraphQL.Services;
using RPedretti.TestGraphQL.Types;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPedretti.TestGraphQL.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CmsController : ControllerBase
{
    private readonly ICmsService cmsService;

    public CmsController(ICmsService cmsService)
    {
        this.cmsService = cmsService;
    }

    [HttpGet("cms")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CmsItemType>))]
    public async Task<IActionResult> GetCmsAsyn([FromQuery]string cmsIds, [FromQuery]int languageId, [FromQuery] bool showCmsId)
    {
        //TODO: add cache
        var cmsItems = await cmsService.GetCmsAsync(cmsIds.Split(",").Select(id => int.Parse(id)), languageId, showCmsId);
        return Ok(cmsItems);
    }
}
