namespace BookmarkMe.Interactors.Bookmark
{
    using System.Collections.Generic;
    using BookmarkMe.Application.Service.Bookmark;
    using BookmarkMe.Infrastructure.Persistence.Repository;

    public class BookmarkServiceInteractor
    {
        private BookmarkService bookmarkService;

        public BookmarkServiceInteractor(IUnitOfWork unitOfWork)
        {
            bookmarkService = new BookmarkService(unitOfWork);
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

        public ViewModel FindBookmark<ViewModel>(int id) where ViewModel : IBookmarkViewModel, new()
        {
            var bookmark = bookmarkService.FindBookmark(id);

            return new ViewModel()
            {
                Id = bookmark.Id,
                Name = bookmark.Name,
                Uri = bookmark.Uri
            };
        }

        public List<ViewModel> GetBookmarks<ViewModel>() where ViewModel : IBookmarkViewModel, new()
        {
            var bookmarks = bookmarkService.GetBookmarks();
            var result = new List<ViewModel>();

            foreach (var bookmark in bookmarks)
            {
                result.Add(new ViewModel()
                {
                    Id = bookmark.Id,
                    Name = bookmark.Name,
                    Uri = bookmark.Uri
                });
            }

            return result;
        }
    }
}
