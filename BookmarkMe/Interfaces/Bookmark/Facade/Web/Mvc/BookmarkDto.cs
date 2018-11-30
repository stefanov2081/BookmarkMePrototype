namespace BookmarkMe.Interfaces.Bookmark.Facade.Web.Mvc
{
    public class BookmarkDto : IBookmarkDto
    {
        public BookmarkDto(int id, string name, string uri)
        {
            Id = id;
            Name = name;
            Uri = uri;
        }

        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Uri { get; private set; }
    }
}
