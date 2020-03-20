using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Services.ToolBoxService;
using Models;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ToolBoxController : ControllerBase
    {
        private readonly ILogger<ToolBoxController> _logger;
        private readonly IToolBoxService _toolBoxService;

        public ToolBoxController(ILogger<ToolBoxController> logger, IToolBoxService toolBoxService)
        {
            _logger = logger;
            _toolBoxService = toolBoxService;
        }

        [HttpGet]
        public async Task<List<Vaerktoejskasse>> Get()
        {
            List<Vaerktoejskasse> toolBoxes = await _toolBoxService.GetToolBoxes();

            return toolBoxes;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Vaerktoejskasse> Get([FromRoute] Guid id)
        {
            var toolBox = await _toolBoxService.GetToolBox(id);

            return toolBox;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Vaerktoejskasse newToolBox)
        {
            await _toolBoxService.EditToolBox(id, newToolBox);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _toolBoxService.DeleteToolBox(id);
          
            return NoContent();
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Post([FromBody] Vaerktoejskasse toolBox)
        {
            await _toolBoxService.SaveToolBox(toolBox);

            return NoContent();
        }
    }
}
