using LibraryApi.DataAccessLayer.Contracts;

namespace LibraryApi.DataAccessLayer.Models
{
    public class Book : IEntity
    {
        public long Id { get; private set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public string Author { get; private set; }
        public string Isbn { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Book(long id, string title, string summary, string author, string isbn, DateTime createdAt)
        {
            Id = id;
            Title = title;
            Summary = summary;
            Author = author;
            Isbn = isbn;
            CreatedAt = createdAt;
        }

        public void SetTitle(string title)
        {
            this.Title = title;
        }

        public void SetSummary(string summary)
        {
            this.Summary = summary;
        }

        public void SetAuthor(string author)
        {
            this.Author = author;
        }

        public void SetIsbn(string isbn)
        {
            this.Isbn = Isbn;
        }
    }
}