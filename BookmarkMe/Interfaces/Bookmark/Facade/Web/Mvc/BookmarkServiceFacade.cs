namespace BookmarkMe.Interfaces.Bookmark.Facade.Web.Mvc
{
    using System.Collections.Generic;
    using Application.Service.Bookmark;
    using Infrastructure.Persistence.Repository.InMemory;

    public class BookmarkServiceFacade : IBookmarkServiceFacade
    {
        private BookmarkService bookmarkService;

        public BookmarkServiceFacade()
        {
            bookmarkService = new BookmarkService(new UnitOfWork());
        }

        public void CreateBookmark(string name, string uri)
        {
            bookmarkService.CreateBookmark(name, uri);
        }

        public void DeleteBookmark(int id)
        {
            bookmarkService.DeleteBookmark(id);
        }

        public void EditBookmark(int id, string name, string uri)
        {
            bookmarkService.EditBookmark(id, name, uri);
        }

        public IBookmarkDto FindBookmark(int id)
        {
            var bookmark = bookmarkService.FindBookmark(id);
            var assembler = new BookmarkDtoAssembler();

            return assembler.ToDto(bookmark);
        }

        public IList<IBookmarkDto> GetBookmarks()
        {
            var bookmarks = bookmarkService.GetBookmarks();
            var assembler = new BookmarkDtoAssembler();

            return assembler.ToDtoIList(bookmarks);
        }

        public IList<IBookmarkDto> SearchBookmarks()
        {
            throw new System.NotImplementedException();
        }
    }
}
