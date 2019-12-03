using BookmarkMe.Domain.Model.Bookmark;
using BookmarkMe.Infrastructure;
using BookmarkMe.Presentation.Web.Mvc.ViewModels.Bookmark;

namespace BookmarkMe.Presentation.Web.Mvc
{
    public class BookmarkMapper : IMapper<IBookmark, BookmarkViewModel>
    {
        public BookmarkViewModel ToResult(IBookmark bookmark)
        {
            var result = new BookmarkViewModel()
            {
                Id = bookmark.Id,
                Name = bookmark.Name,
                Url = bookmark.Url,
                ThumbnailUrl= bookmark.ThumbnailUrl
            };

            return result;
        }

        public BookmarkViewModel[] ToResult(IBookmark[] model)
        {
            var result = new BookmarkViewModel[model.Length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = ToResult(model[i]);
            }

            return result;
        }
    }
}