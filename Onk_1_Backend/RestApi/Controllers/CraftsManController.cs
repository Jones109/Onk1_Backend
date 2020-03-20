using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Services.CraftsManService;
using Models;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CraftsManController : ControllerBase
    {
      
        private readonly ILogger<CraftsManController> _logger;
        private readonly ICraftsManService _craftsManService;

        public CraftsManController(ILogger<CraftsManController> logger, ICraftsManService craftsManService)
        {
            _logger = logger;
            _craftsManService = craftsManService;
        }

        [HttpGet]
        public async Task<List<Haandvaerker>> Get()
        {
            var craftsMen = await _craftsManService.GetCraftsMen();

            return craftsMen;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Haandvaerker> Get([FromRoute] Guid id)
        {
            var craftsMan = await _craftsManService.GetCraftsMan(id);

            return craftsMan;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Haandvaerker newCraftsMan)
        {
            await _craftsManService.EditCraftsMan(id, newCraftsMan);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _craftsManService.DeleteCraftsMan(id);

            return NoContent();
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Post([FromBody] Haandvaerker craftsMan)
        {
            await _craftsManService.SaveCraftsMan(craftsMan);

            return NoContent();
        }
    }
}
