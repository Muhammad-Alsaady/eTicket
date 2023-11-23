using eTicket.DataAccess.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eTicket.DataAccess.Services.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;
            Actor = new ActorRepository(context);
            Movie = new MovieRepository(context);
            Cinema = new CinemaRepository(context);
            Producer = new ProducerRepository(context);
            ShoppingCart = new ShoppingCart(context);
        }

        public IActorRepository Actor { get; private set; }

        public IMovieRepository Movie { get; private set; }

        public ICinemaRepository Cinema { get; private set; }

        public IProducerRepository Producer { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
