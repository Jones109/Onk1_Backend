using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services.ToolService
{
    public interface IToolService
    {
        Task<List<Models.Tool>> GetTools();

        Task<Models.Tool> GetTool(Guid id);

        Task SaveTool(Models.Tool tool);

        Task DeleteTool(Guid id);

        Task EditTool(Guid id, Models.Tool tool);
    }
}
