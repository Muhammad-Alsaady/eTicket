using eTicket.DataAccess.Services.IRepositories;
using eTicket.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.Repositories
{
    public class ActorRepository: GenericRepositorye<Actor>, IActorRepository
    {
        private readonly ApplicationDbContext context;

        public ActorRepository(ApplicationDbContext context): base(context)
        {
            this.context = context;
        }

        public ActorDetailsVM GetActorMovies(Actor actor)
        {
            var actorModel = context.Actors
                            .Include(a => a.MovieActors)
                            .ThenInclude(a => a.Movie)
                            .FirstOrDefault(a => a.Id == actor.Id);
            
            if (actorModel == null)
                return null;
            if (!actorModel.MovieActors.Any())
            {
                context.Entry(actorModel).Reference(a => a.MovieActors).Load();
            }
            var model = new ActorDetailsVM()
            {
                Id = actor.Id,
                Name = actorModel.Name,
                Bio = actorModel.Bio,
                ProfilePhotoURL = actorModel.ProfilePhotoURL,
            };
            foreach (var movieActor in actorModel.MovieActors)
            {
                model.Movies.Add(movieActor.Movie.Title);
            }
            return model;
        }
        public async Task UpdateAsync(int id, Actor entity)
        {
            EntityEntry entityEntry = context.Entry<Actor>(entity);
            entityEntry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
