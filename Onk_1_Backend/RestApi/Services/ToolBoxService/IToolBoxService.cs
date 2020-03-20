using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace RestApi.Services.ToolBoxService
{
    public interface IToolBoxService
    {
        Task<List<Vaerktoejskasse>> GetToolBoxes();

        Task<Vaerktoejskasse> GetToolBox(Guid id);

        Task SaveToolBox(Vaerktoejskasse toolBox);

        Task DeleteToolBox(Guid id);

        Task EditToolBox(Guid id, Vaerktoejskasse toolBox);
    }
}
