using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services.CraftsManService
{
    public interface ICraftsManService
    {
        Task<List<Models.CraftsMan>> GetCraftsMen();

        Task<Models.CraftsMan> GetCraftsMan(Guid id);

        Task SaveCraftsMan(Models.CraftsMan craftsMan);

        Task DeleteCraftsMan(Guid id);

        Task EditCraftsMan(Guid id, Models.CraftsMan craftsMan);
    }
}
