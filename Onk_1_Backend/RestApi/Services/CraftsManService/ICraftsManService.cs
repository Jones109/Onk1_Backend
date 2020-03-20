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

        Task<Haandvaerker> GetCraftsMan(int id);

        Task SaveCraftsMan(Haandvaerker craftsMan);

        Task DeleteCraftsMan(int id);

        Task EditCraftsMan(Haandvaerker craftsMan);

        bool CreateDB();
    }
}
