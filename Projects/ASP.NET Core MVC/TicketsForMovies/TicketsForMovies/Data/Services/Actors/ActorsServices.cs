using TicketsForMovies.Data.Base;
using TicketsForMovies.Models;

namespace TicketsForMovies.Data.Services.Actors
{
    public class ActorsServices : EntityBaseRepository<Actor>, IActorsServices
    {
        public ActorsServices(AppDbContext context) : base(context)
        {
        }
    }
}
