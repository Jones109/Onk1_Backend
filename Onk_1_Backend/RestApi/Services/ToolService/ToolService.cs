using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using RestApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services.ToolService
{
    public class ToolService : IToolService
    {
        public IConfiguration Configuration { get; }
        private DbContextOptions<HaandvaerkerDbContext> _options;

        public ToolService(IConfiguration configuration)
        {
            Configuration = configuration;
            _options = new DbContextOptionsBuilder<HaandvaerkerDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("F20ITONKASPNETKubernetesConnection"))
                .Options;
        }

        public async Task DeleteTool(Guid id)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var tool = context.Tools.First(c => c.VTId == id);

                context.Tools.Attach(tool);
                context.Tools.Remove(tool);
                context.SaveChanges();
            }
        }

        public async Task EditTool(Guid id, Vaerktoej tool)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                context.Tools.Update(tool);
                context.SaveChanges();
            }
        }

        public async Task<Vaerktoej> GetTool(Guid id)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var tool = await context.Tools.FirstAsync(h => h.VTId == id);

                return tool;
            }
        }

        public async Task<List<Vaerktoej>> GetTools()
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var tools = context.Tools; ;

                return await tools.ToListAsync(); ;
            }
        }

        public async Task SaveTool(Vaerktoej tool)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                await context.Tools.AddAsync(tool);
                await context.SaveChangesAsync();
            }
        }
    }
}
