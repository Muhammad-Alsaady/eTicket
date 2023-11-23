using eTicket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.IRepositories
{
    public interface ICinemaRepository: IGenericRepository<Cinema>
    {
        Task UpdateAsync(int id, Cinema entity);
    }
}
