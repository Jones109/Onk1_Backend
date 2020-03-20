using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models;
using RestApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services.ToolBoxService
{
    public class ToolBoxService : IToolBoxService
    {
        public IConfiguration Configuration { get; }
        private DbContextOptions<HaandvaerkerDbContext> _options;

        public ToolBoxService(IConfiguration configuration)
        {
            Configuration = configuration;
            _options = new DbContextOptionsBuilder<HaandvaerkerDbContext>()
                .UseSqlServer(Configuration.GetConnectionString("F20ITONKASPNETKubernetesConnection"))
                .Options;
        }

        public async Task DeleteToolBox(int id)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var toolBox = context.ToolBoxes.First(c => c.VTKId == id);

                context.ToolBoxes.Attach(toolBox);
                context.ToolBoxes.Remove(toolBox);
                context.SaveChanges();
            }
        }

        public async Task EditToolBox(Vaerktoejskasse toolBox)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                context.ToolBoxes.Update(toolBox);
                context.SaveChanges();
            }
        }

        public async Task<Vaerktoejskasse> GetToolBox(int id)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var toolBox = await context.ToolBoxes.FirstAsync(h => h.VTKId == id);

                return toolBox;
            }
        }

        public async Task<List<Vaerktoejskasse>> GetToolBoxes()
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                var toolBox = context.ToolBoxes; ;

                return  await toolBox.ToListAsync(); ;
            }
        }

        public async Task SaveToolBox(Vaerktoejskasse toolBox)
        {
            using (var context = new HaandvaerkerDbContext(_options))
            {
                await context.ToolBoxes.AddAsync(toolBox);
                await context.SaveChangesAsync();
            }
        }
    }
}
