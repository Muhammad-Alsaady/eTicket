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
    public class MovieRepository : GenericRepositorye<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext context;

        public MovieRepository(ApplicationDbContext context): base(context)
        {
            this.context = context;
        }

        public Movie GetMovieDetails(int id)
        {
            var movieModel = context.Movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(ma => ma.MovieActors).ThenInclude(a => a.Actor)
                .FirstOrDefault(m => m.Id == id);
            if (movieModel == null) return null;
            return movieModel;
        }
        
        public Movie GetMovieById(int id)
        {
            return context.Movies.Include(x => x.MovieActors).FirstOrDefault(m => m.Id == id) ?? null;
        }

        public async Task UpdateAsync(int id, CreateMovieVM model)
        {
            var entity = context.Movies.Find(id);
            entity.Title = model.Title;
            entity.Description = model.Description;
            entity.ImageURL = model.ImageURL;
            entity.Price = model.Price;
            entity.StartDate = model.StartDate;
            entity.EndDate = model.EndDate;
            entity.ProducerID = model.ProducerID;
            entity.CinemaID = model.CinemaID;
            entity.MovieActors = model.ActorId.Select(a => new MovieActor { ActorID = a, MovieID = model.Id }).ToList();

            //EntityEntry entityEntry = context.Entry<Movie>(entity);
            //entityEntry.State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

    }
}
