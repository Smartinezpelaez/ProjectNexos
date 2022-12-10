namespace Nexos.DAL.Models
{
    public partial class Author
    {
        public Author()
        {
            Records = new HashSet<Record>();
        }

        public int IdAuthor { get; set; }
        public string? Name { get; set; }
        public DateTime? Birthday { get; set; }
        public string? City { get; set; }
        public string? Mail { get; set; }

        public virtual Bookss Bookss { get; set; } = null!;
        public virtual ICollection<Record> Records { get; set; }
    }
}
