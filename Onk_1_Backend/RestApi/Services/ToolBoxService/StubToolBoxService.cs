using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services.ToolBoxService
{
    public class StubToolBoxService : IToolBoxService
    {
        public Task DeleteToolBox(Guid id)
        {
            return Task.CompletedTask;
        }

        public Task EditToolBox(Guid id, ToolBox toolBox)
        {
            return Task.CompletedTask;
        }

        public async Task<ToolBox> GetToolBox(Guid id)
        {
            return new ToolBox()
            {
                Acquired = DateTime.Now,
                Owner = new CraftsMan(),
                Brand = "BrandStub",
                Color = "Blue",
                Id = Guid.NewGuid(),
                Model = "A400",
                SerialNumber = "asdfhsfdhasfsd"
            };
    }

        public async Task<List<ToolBox>> GetToolBoxes()
        {
            var toolBoxes = new List<ToolBox>();
            toolBoxes.Add(new ToolBox()
            {
                Acquired = DateTime.Now,
                Owner = new CraftsMan(),
                Brand = "BrandStub",
                Color = "Blue",
                Id = Guid.NewGuid(),
                Model = "A400",
                SerialNumber = "asdfhsfdhasfsd"
            });
            toolBoxes.Add(new ToolBox()
            {
                Acquired = DateTime.Now,
                Owner = new CraftsMan(),
                Brand = "BrandStub2",
                Color = "Yellow",
                Id = Guid.NewGuid(),
                Model = "A500",
                SerialNumber = "oeriyteqropgjhafeblk"
            });

            return toolBoxes;
        }

        public Task SaveToolBox(ToolBox toolBox)
        {
            return Task.CompletedTask;
        }
    }
}
