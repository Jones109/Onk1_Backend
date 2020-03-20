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

        Task<Vaerktoej> GetTool(int id);

        Task SaveTool(Vaerktoej tool);

        Task DeleteTool(int id);

        Task EditTool(Vaerktoej tool);
    }
}
