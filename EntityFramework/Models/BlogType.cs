namespace EntityFramework.Models
{
    public class BlogType
    {
        public int BlogTypeId { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}