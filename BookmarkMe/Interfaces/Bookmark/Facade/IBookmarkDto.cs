namespace BookmarkMe.Interfaces.Bookmark.Facade
{
    public interface IBookmarkDto
    {
        int Id { get; }

        string Name { get; }

        string Uri { get; }
    }
}
