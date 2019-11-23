namespace BookmarkMe.Infrastructure.Persistence.Repository
{
    using System.Collections.Generic;
    using Domain.Model.Bookmark;

    public interface IBookmarkRepository
    {
        void Add(IBookmark bookmark);
        void Delete(int id);
        IList<IBookmark> Get();
        int NextId();
        IBookmark Find(int id);
        void Update(IBookmark bookmark);
    }
}
