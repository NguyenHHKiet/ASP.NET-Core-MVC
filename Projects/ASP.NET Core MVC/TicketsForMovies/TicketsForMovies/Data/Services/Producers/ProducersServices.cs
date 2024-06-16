using TicketsForMovies.Data.Base;
using TicketsForMovies.Models;

namespace TicketsForMovies.Data.Services.Producers
{
    public class ProducersServices : EntityBaseRepository<Producer>, IProducersServices
    {
        public ProducersServices(AppDbContext context) : base(context)
        {
        }
    }
}
