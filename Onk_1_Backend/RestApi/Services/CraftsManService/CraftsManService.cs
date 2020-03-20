using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using RestApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services.CraftsManService
{
    public class CraftsManService : ICraftsManService
    {
        public IConfiguration Configuration { get; }
        private DbContextOptions<HaandvaerkerDbContext> _options;

        public CraftsManService(IConfiguration configuration)
        {
            Configuration = configuration;
            _options = new DbContextOptionsBuilder<HaandvaerkerDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .Options;
        }

        public Task DeleteCraftsMan(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task EditCraftsMan(Guid id, Haandvaerker craftsMan)
        {
            throw new NotImplementedException();
        }

        public Task<Haandvaerker> GetCraftsMan(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Haandvaerker>> GetCraftsMen()
        {
            throw new NotImplementedException();
        }

        public Task SaveCraftsMan(Haandvaerker craftsMan)
        {
            throw new NotImplementedException();
        }
    }
}
