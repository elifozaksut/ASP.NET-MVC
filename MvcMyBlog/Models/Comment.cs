namespace Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

    }
}