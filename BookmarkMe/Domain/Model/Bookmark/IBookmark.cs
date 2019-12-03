namespace BookmarkMe.Domain.Model.Bookmark
{
    public interface IBookmark
    {
        int Id { get; }
        string Name { get; }
        string Url { get; }
        string ThumbnailUrl { get; }
    }
}
