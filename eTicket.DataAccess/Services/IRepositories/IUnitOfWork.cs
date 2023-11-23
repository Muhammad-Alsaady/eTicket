using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.IRepositories
{
    public interface IUnitOfWork: IDisposable
    {
        IActorRepository Actor { get; }
        IMovieRepository Movie { get; }
        ICinemaRepository Cinema { get; }
        IProducerRepository Producer { get; }
        IShoppingCartRepository ShoppingCart { get; }
        void Save();
        Task SaveAsync();
    }
}
