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
    public class ProducerRepository : GenericRepositorye<Producer>, IProducerRepository
    {
        private readonly ApplicationDbContext context;

        public ProducerRepository(ApplicationDbContext context): base(context)
        {
            this.context = context;
        }

        public ProducerDetailsVM GetActorMovies(Producer producer)
        {
            var producerModel = context.Producers
                            .Include(a => a.Movies)
                            .FirstOrDefault(a => a.Id == producer.Id);

            if (producerModel == null)
                return null;
            if (!producerModel.Movies.Any())
            {
                context.Entry(producerModel).Reference(a => a.Movies).Load();
            }
            var model = new ProducerDetailsVM()
            {
                Name = producerModel.Name,
                Bio = producerModel.Bio,
                ProfilePhotoURL = producerModel.ProfilePhotoURL,
            };
            foreach (var movieProducer in producerModel.Movies)
            {
                model.Movies.Add(movieProducer.Title);
            }
            return model;
        }
        public async Task UpdateAsync(int id, Producer entity)
        {
            EntityEntry entityEntry = context.Entry<Producer>(entity);
            entityEntry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
