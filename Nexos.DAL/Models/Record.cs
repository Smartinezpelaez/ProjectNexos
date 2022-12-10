namespace Nexos.DAL.Models
{
    public partial class Record
    {
        public int IdRecord { get; set; }
        public int? IdBook { get; set; }
        public int? IdAuthor { get; set; }

        public virtual Author? IdAuthorNavigation { get; set; }
        public virtual Bookss? IdBookNavigation { get; set; }
    }
}
