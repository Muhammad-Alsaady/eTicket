using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.IRepositories
{
    public interface IMovieRepository : IGenericRepository<Movie>
    {
        Task UpdateAsync(int id, CreateMovieVM model);
        Movie GetMovieDetails(int id);
        Movie GetMovieById(int id);
    }
}
