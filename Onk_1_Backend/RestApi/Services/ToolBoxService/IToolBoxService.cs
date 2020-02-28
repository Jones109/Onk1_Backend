using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services.ToolBoxService
{
    public interface IToolBoxService
    {
        Task<List<Models.ToolBox>> GetToolBoxes();

        Task<Models.ToolBox> GetToolBox(Guid id);

        Task SaveToolBox(Models.ToolBox toolBox);

        Task DeleteToolBox(Guid id);

        Task EditToolBox(Guid id, Models.ToolBox toolBox);
    }
}
