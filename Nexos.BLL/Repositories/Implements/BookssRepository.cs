using Nexos.DAL.Models;

namespace Nexos.BLL.Repositories.Implements
{
    public class BookssRepository : GenericRepository<Bookss>, IBookssRepository
    {
        private readonly NexosContext context;

        public BookssRepository(NexosContext context) :base(context)
        {
            this.context = context;
        }

        public new async Task DeleteAsync(int id)
        {
            var customer = await GetByIdAsync(id);

            if (customer == null) throw new Exception("The entity is null.");
            if (context.Records.Any(x => x.IdBook == id)) throw new Exception("Foreign Key Books.");

            context.Booksses.Remove(customer);
            await context.SaveChangesAsync();
        }

    }
}
