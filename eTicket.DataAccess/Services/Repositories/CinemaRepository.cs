using eTicket.DataAccess.Services.IRepositories;
using eTicket.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.Repositories
{
    public class CinemaRepository : GenericRepositorye<Cinema>, ICinemaRepository
    {
        private readonly ApplicationDbContext context;

        public CinemaRepository(ApplicationDbContext context): base(context)
        {
            this.context = context;
        }

        public async Task UpdateAsync(int id, Cinema entity)
        {
            EntityEntry entityEntry = context.Entry<Cinema>(entity);
            entityEntry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
