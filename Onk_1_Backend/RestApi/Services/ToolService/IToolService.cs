using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace RestApi.Services.ToolService
{
    public interface IToolService
    {
        Task<List<Vaerktoej>> GetTools();

        Task<Vaerktoej> GetTool(Guid id);

        Task SaveTool(Vaerktoej tool);

        Task DeleteTool(Guid id);

        Task EditTool(Guid id, Vaerktoej tool);
    }
}
