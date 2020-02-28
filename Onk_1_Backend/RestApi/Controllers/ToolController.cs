﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestApi.Services.ToolService;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ToolController : ControllerBase
    {
        private readonly ILogger<ToolController> _logger;
        private readonly IToolService _toolService;

        public ToolController(ILogger<ToolController> logger, IToolService toolService)
        {
            _logger = logger;
            _toolService = toolService;
        }
        

        [HttpGet]
        public async Task<List<Models.Tool>> Get()
        {
            List<Models.Tool> tools = await _toolService.GetTools();
            
            return tools;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<Models.Tool> Get([FromRoute] Guid id)
        {
            var tool = await _toolService.GetTool(id);

            return tool;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Models.Tool newTool)
        {
            await _toolService.EditTool(id, newTool);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _toolService.DeleteTool(id);

            return NoContent();
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<IActionResult> Post([FromBody] Models.Tool tool)
        {
            await _toolService.SaveTool(tool);

            return NoContent();
        }
    }
}