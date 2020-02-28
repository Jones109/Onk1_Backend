using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services.ToolService
{
    public class StubToolService : IToolService
    {
        public Task DeleteTool(Guid id)
        {
            return Task.CompletedTask;
        }

        public Task EditTool(Guid id, Tool tool)
        {
            return Task.CompletedTask;
        }

        public async Task<Tool> GetTool(Guid id)
        {
            return new Tool()
            {
                ToolBox = new ToolBox(),
                Acquired = DateTime.Now,
                Brand = "Brand1",
                Id = Guid.NewGuid(),
                Model = "Model",
                SerialNumber = "ashgoiegnl347gd",
                Type = "Hammer"
            };
        }

        public async Task<List<Tool>> GetTools()
        {
            var tools = new List<Tool>();
            tools.Add(new Tool()
            {
                ToolBox = new ToolBox(),
                Acquired = DateTime.Now,
                Brand = "Brand1",
                Id = Guid.NewGuid(),
                Model = "Model",
                SerialNumber = "ashgoiegnl347gd",
                Type = "Hammer"
            });
            tools.Add(new Tool()
            {
                ToolBox = new ToolBox(),
                Acquired = DateTime.Now,
                Brand = "Brand2",
                Id = Guid.NewGuid(),
                Model = "Model2",
                SerialNumber = "afghgjækajsg",
                Type = "Saw"
            });

            return tools;
        }

        public Task SaveTool(Tool tool)
        {
            return Task.CompletedTask;
        }
    }
}
