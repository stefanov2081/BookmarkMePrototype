namespace BookmarkMe.Interfaces.Bookmark.Web.Mvc
{
    using System;
    using System.Collections.Generic;
    using BookmarkMe.Application.Service.Bookmark;
    using BookmarkMe.Domain.Model.Bookmark;
    using BookmarkMe.Infrastructure.Persistence.Repository.InMemory;

    public class BookmarkServiceFacade
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

        //public IEditViewModel FindBookmark(int id, IEditViewModel viewModel)
        //{
        //    var bookmark = bookmarkService.FindBookmark(id);

        //    viewModel.Id = bookmark.Id;
        //    viewModel.Name = bookmark.Name;
        //    viewModel.Uri = bookmark.Uri;

        //    return viewModel;
        //}

        public ViewModel FindBookmark<ViewModel>(int id, ViewModel viewModel) where ViewModel : IBookmarkViewModel, new()
        {
            var bookmark = bookmarkService.FindBookmark(id);
            var asd = new ViewModel();

            viewModel.Id = bookmark.Id;
            viewModel.Name = bookmark.Name;
            viewModel.Uri = bookmark.Uri;

            return viewModel;
        }

        public List<ViewModel> GetBookmarks<ViewModel>(List<ViewModel> viewModelList) where ViewModel : IBookmarkViewModel
        {
            var bookmarks = bookmarkService.GetBookmarks();

            for (int i = 0; i < viewModelList.Count; i++)
            {
                viewModelList[i].Id = bookmarks[i].Id;
                viewModelList[i].Name = bookmarks[i].Name;
                viewModelList[i].Uri = bookmarks[i].Uri;
            }

            return viewModelList;
        }
    }
}
