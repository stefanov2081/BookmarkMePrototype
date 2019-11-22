namespace BookmarkMe.Presentation.Web.Mvc.Assemblers
{
    using Interfaces.Bookmark.Facade;
    using System.Collections.Generic;
    using ViewModels.Bookmark;

    internal sealed class BookmarkViewModelAssembler
    {
        public DeleteViewModel ToDeleteViewModel(IBookmarkDto bookmark)
        {
            return new DeleteViewModel()
            {
                Id = bookmark.Id,
                Name = bookmark.Name,
                Uri = bookmark.Uri
            };
        }

        public BookmarkViewModel ToEditViewModel(IBookmarkDto bookmark)
        {
            return new BookmarkViewModel()
            {
                Id = bookmark.Id,
                Name = bookmark.Name,
                Uri = bookmark.Uri
            };
        }

        public ListViewModel[] ToIndexViewModel(IList<IBookmarkDto> bookmarks)
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

        public DetailsViewModel ToDetailsViewModel(IBookmarkDto bookmark)
        {
            return new DetailsViewModel()
            {
                Id = bookmark.Id,
                Name = bookmark.Name,
                Uri = bookmark.Uri
            };
        }
    }
}