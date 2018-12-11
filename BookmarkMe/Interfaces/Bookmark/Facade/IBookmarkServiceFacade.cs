namespace BookmarkMe.Interfaces.Bookmark.Facade
{
    using System.Collections.Generic;

    public interface IBookmarkServiceFacade
    {
        void CreateBookmark(string name, string uri);

        void DeleteBookmark(int id);

        void EditBookmark(int id, string name, string uri);

        IBookmarkDto FindBookmark(int id);

        IList<IBookmarkDto> GetBookmarks();

        IList<IBookmarkDto> SearchBookmarks(/*searchBy, keyword*/);
    }
}
