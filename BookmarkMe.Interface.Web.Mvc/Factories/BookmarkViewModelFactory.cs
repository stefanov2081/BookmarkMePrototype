namespace BookmarkMe.Interface.Web.Mvc.Factories
{
    using Domain.Model.Bookmark;
    using System.Collections.Generic;
    using ViewModels.Bookmark;

    internal sealed class BookmarkViewModelFactory
    {
        public DeleteViewModel CreateDeleteViewModel(Bookmark bookmark)
        {
            return new DeleteViewModel()
            {
                Id = bookmark.Id,
                Name = bookmark.Name,
                Uri = bookmark.Uri
            };
        }

        public EditViewModel CreateEditViewModel(Bookmark bookmark)
        {
            return new EditViewModel()
            {
                Id = bookmark.Id,
                Name = bookmark.Name,
                Uri = bookmark.Uri
            };
        }

        public ListViewModel[] CreateIndexViewModel(IList<Bookmark> bookmarks)
        {
            var viewModel = new ListViewModel[bookmarks.Count];

            for (int i = 0; i < bookmarks.Count; i++)
            {
                viewModel[i] = new ListViewModel();
                viewModel[i].Id = bookmarks[i].Id;
                viewModel[i].Name = bookmarks[i].Name;
                viewModel[i].Uri = bookmarks[i].Uri;
            }

            return viewModel;
        }
    }
}