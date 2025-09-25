namespace CarBook_OnionArch.Dto.BlogDtos
{
    public class ResultBlogByIdWithDetailsDto
    {

        public int id { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }
        public string? coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public int authorId { get; set; }
        public Author? author { get; set; }
        public int categoryId { get; set; }
        public Category? category { get; set; }
        public Comment[]? comments { get; set; }


        public class Author
        {
            public int id { get; set; }
            public string? fullName { get; set; }
            public string? description { get; set; }
            public string? imageUrl { get; set; }
        }

        public class Category
        {
            public int id { get; set; }
            public string? name { get; set; }
        }

        public class Comment
        {
            public int id { get; set; }
            public string? content { get; set; }
            public DateTime createdDate { get; set; }
            public int authorId { get; set; }
            public string? authorName { get; set; }
            public string? authorImageUrl { get; set; }
        }
    }
}
