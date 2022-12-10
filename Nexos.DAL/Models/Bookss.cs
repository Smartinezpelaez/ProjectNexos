namespace Nexos.DAL.Models
{
    public partial class Bookss
    {
        public Bookss()
        {
            Records = new HashSet<Record>();
        }

        public int IdBook { get; set; }
        public string? Title { get; set; }
        public DateTime? Year { get; set; }
        public int? Pages { get; set; }
        public string? Author { get; set; }

        public virtual Author IdBookNavigation { get; set; } = null!;
        public virtual ICollection<Record> Records { get; set; }
    }
}
