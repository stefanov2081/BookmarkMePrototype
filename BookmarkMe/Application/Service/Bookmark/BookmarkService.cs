namespace BookmarkMe.Application.Service.Bookmark
{
    using System;
    using System.Collections.Generic;
    using BookmarkMe.Infrastructure;
    using Domain.Model.Bookmark;
    using Infrastructure.Persistence.Repository;

    public class BookmarkService<ResultModel>
    {
        private IUnitOfWork unitOfWork;
        private IMapper<IBookmark, ResultModel> mapper;

        public BookmarkService(IUnitOfWork unitOfWork, IMapper<IBookmark, ResultModel> mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public void CreateBookmark(string name, string url, string logoUrl)
        {
            var id = unitOfWork.BookmarkRepository.NextId();
            var bookmark = new Bookmark(id, name, url, logoUrl);

            unitOfWork.BookmarkRepository.Add(bookmark);
            unitOfWork.Save();
        }

        public void DeleteBookmark(int id)
        {
            unitOfWork.BookmarkRepository.Delete(id);
        }

        public void EditBookmark(int id, string name, string url)
        {
            var bookmark = (Bookmark)unitOfWork.BookmarkRepository.Find(id);
            bookmark.Rename(name);
            bookmark.ChangeUrl(url);

            unitOfWork.BookmarkRepository.Update(bookmark);
            unitOfWork.Save();
        }

        public ResultModel FindBookmark(int id)
        {
            var bookmark = unitOfWork.BookmarkRepository.Find(id);
            var result = mapper.ToResult(bookmark);

            return result;
        }

        public ResultModel[] GetBookmarks()
        {
            var bookmarks = unitOfWork.BookmarkRepository.Get();
            var result = mapper.ToResult(bookmarks);

            return result;
        }

        public List<ResultModel> SearchBookmarks(/*searchBy, keyword*/)
        {
            throw new NotImplementedException();
        }
    }
}
