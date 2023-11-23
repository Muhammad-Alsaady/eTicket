using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.IRepositories
{
    public interface IActorRepository: IGenericRepository<Actor>
    {
        public ActorDetailsVM GetActorMovies(Actor actor);
        Task UpdateAsync(int id, Actor entity);
    }
}
