using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace RestApi.Services.CraftsManService
{
    public interface ICraftsManService
    {
        Task<List<Haandvaerker>> GetCraftsMen();

        Task<Haandvaerker> GetCraftsMan(Guid id);

        Task SaveCraftsMan(Haandvaerker craftsMan);

        Task DeleteCraftsMan(Guid id);

        Task EditCraftsMan(Guid id, Haandvaerker craftsMan);
    }
}
