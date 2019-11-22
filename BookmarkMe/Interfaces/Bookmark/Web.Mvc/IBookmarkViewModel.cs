namespace BookmarkMe.Interfaces.Bookmark.Web.Mvc
{
    public interface IBookmarkViewModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Uri { get; set; }
    }
}
