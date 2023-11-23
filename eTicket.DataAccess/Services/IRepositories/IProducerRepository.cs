using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.IRepositories
{
    public interface IProducerRepository: IGenericRepository<Producer>
    {
        public ProducerDetailsVM GetActorMovies(Producer actor);
        Task UpdateAsync(int id, Producer entity);
    }
}
