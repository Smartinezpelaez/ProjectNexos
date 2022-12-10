using Nexos.DAL.Models;

namespace Nexos.BLL.Repositories.Implements
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly NexosContext context;
        public AuthorRepository(NexosContext context) :base(context)
        {
            this.context = context; 
        }

        public new async Task DeleteAsync(int id)
        {
            var account = await GetByIdAsync(id);

            if (account == null) throw new Exception("The entity is null.");
            if (context.Records.Any(x => x.IdAuthor == id)) throw new Exception("Foreign Key Author.");

            context.Authors.Remove(account);
            await context.SaveChangesAsync();
        }
    }
}
