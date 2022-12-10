using Nexos.DAL.Models;

namespace Nexos.BLL.Repositories.Implements
{
    public class RecordRepository : GenericRepository<Record>, IRecordRepository
    {
        private readonly NexosContext context;
        public RecordRepository(NexosContext context) :base(context)
        {
            this.context = context; 
        }
    }
}
