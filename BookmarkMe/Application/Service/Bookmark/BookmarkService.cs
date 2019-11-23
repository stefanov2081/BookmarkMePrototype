namespace BookmarkMe.Application.Service.Bookmark
{
    using System;
    using System.Collections.Generic;
    using Domain.Model.Bookmark;
    using Infrastructure.Persistence.Repository;

    internal class BookmarkService
    {
        private IUnitOfWork unitOfWork;

        public BookmarkService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void CreateBookmark(string name, string uri)
        {
            var id = unitOfWork.BookmarkRepository.NextId();
            var bookmark = new Bookmark(id, name, uri);

            unitOfWork.BookmarkRepository.Add(bookmark);
            unitOfWork.Save();
        }

        public void DeleteBookmark(int id)
        {
            unitOfWork.BookmarkRepository.Delete(id);
        }

        public void EditBookmark(int id, string name, string uri)
        {
            var bookmark = (Bookmark)unitOfWork.BookmarkRepository.Find(id);
            bookmark.Rename(name);
            bookmark.ChangeUri(uri);

            unitOfWork.BookmarkRepository.Update(bookmark);
            unitOfWork.Save();
        }

        public Bookmark FindBookmark(int id)
        {
            return (Bookmark)unitOfWork.BookmarkRepository.Find(id);
        }

        public IList<Bookmark> GetBookmarks()
        {
            return (IList<Bookmark>)unitOfWork.BookmarkRepository.Get();
        }

        public IList<Bookmark> SearchBookmarks(/*searchBy, keyword*/)
        {
            throw new NotImplementedException();
        }
    }
}
