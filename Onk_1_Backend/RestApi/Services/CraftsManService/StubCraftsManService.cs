using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Services.CraftsManService
{
    public class StubCraftsManService : ICraftsManService
    {
        public Task DeleteCraftsMan(Guid id)
        {
            return Task.CompletedTask;
        }

        public Task EditCraftsMan(Guid id, CraftsMan craftsMan)
        {
            return Task.CompletedTask;
        }

        public async Task<CraftsMan> GetCraftsMan(Guid id)
        {
            return new CraftsMan()
            {
                FirstName = "Jonas",
                SurName = "Hansen",
                DateOfEmployment = DateTime.Now,
                FieldOfWork = "Software",
                Id = Guid.NewGuid()
            };
        }

        public async Task<List<CraftsMan>> GetCraftsMen()
        {
            var craftsMen = new List<CraftsMan>();
            craftsMen.Add(new CraftsMan()
            {
                FirstName = "Jonas",
                SurName = "Hansen",
                DateOfEmployment = DateTime.Now,
                FieldOfWork = "Software",
                Id = Guid.NewGuid()
            });
            craftsMen.Add(new CraftsMan()
            {
                FirstName = "Andreas",
                SurName = "Harfeld",
                DateOfEmployment = DateTime.Now,
                FieldOfWork = "Fast food",
                Id = Guid.NewGuid()
            });

            return craftsMen;
        }

        public Task SaveCraftsMan(CraftsMan craftsMan)
        {
            return Task.CompletedTask;
        }
    }
}
