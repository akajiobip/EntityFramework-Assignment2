namespace EntityFramework.Models
{
    public class PostType
    {
        public int PostTypeId { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Post> Posts { get; set; }
    }
}