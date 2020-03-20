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
                .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .Options;
        }

        public async Task DeleteCraftsMan(Guid id)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var craftsMan = context.CraftsMen.First(c => c.HaandvaerkerId == id);

                context.CraftsMen.Attach(craftsMan);
                context.CraftsMen.Remove(craftsMan);
                context.SaveChanges();
            }
        }

        public async Task EditCraftsMan(Guid id, Haandvaerker craftsMan)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                context.CraftsMen.Update(craftsMan);
                context.SaveChanges();
            }
        }

        public async Task<Haandvaerker> GetCraftsMan(Guid id)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var craftsMan = await context.CraftsMen.Include(c => c.Vaerktoejskasse).FirstAsync();

                return craftsMan;
            }
        }

        public async Task<List<Haandvaerker>> GetCraftsMen()
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var craftsMan = context.CraftsMen.Include(c => c.Vaerktoejskasse);

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
