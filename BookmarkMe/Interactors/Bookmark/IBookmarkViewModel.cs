namespace BookmarkMe.Interactors.Bookmark
{
    public interface IBookmarkViewModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Uri { get; set; }
    }
}
