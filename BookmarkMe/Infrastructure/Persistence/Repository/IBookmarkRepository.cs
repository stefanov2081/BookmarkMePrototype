namespace BookmarkMe.Infrastructure.Persistence.Repository
{
    using System.Collections.Generic;
    using Domain.Model.Bookmark;

    public interface IBookmarkRepository
    {
        void Add(Bookmark bookmark);
        void Delete(int id);
        IList<Bookmark> Get();
        int NextId();
        Bookmark Find(int id);
        void Update(Bookmark bookmark);
    }
}
