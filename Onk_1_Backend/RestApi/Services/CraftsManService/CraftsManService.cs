using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using RestApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

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
                .UseSqlServer(Configuration.GetConnectionString("F20ITONKASPNETKubernetesConnection"))
                .Options;
        }

        public async Task DeleteCraftsMan(int id)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var craftsMan = context.CraftsMen.First(c => c.HaandvaerkerId == id);

                context.CraftsMen.Attach(craftsMan);
                context.CraftsMen.Remove(craftsMan);
                context.SaveChanges();
            }
        }

        public async Task EditCraftsMan(Haandvaerker craftsMan)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                context.CraftsMen.Update(craftsMan);
                context.SaveChanges();
            }
        }

        public async Task<Haandvaerker> GetCraftsMan(int id)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var craftsMan = await context.CraftsMen.FirstAsync(h=>h.HaandvaerkerId == id);

                return craftsMan;
            }
        }

        public async Task<List<Haandvaerker>> GetCraftsMen()
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var craftsMan = context.CraftsMen;

                return await craftsMan.ToListAsync<Haandvaerker>();
            }
        }

        public async Task SaveCraftsMan(Haandvaerker craftsMan)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                await context.CraftsMen.AddAsync(craftsMan);
                await context.SaveChangesAsync();
            }
        }

        public bool CreateDB()
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                if (true && (context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator).Exists())
                    return false;

                context.Database.EnsureDeleted();
                return context.Database.EnsureCreated();
            }
        }
    }
}
