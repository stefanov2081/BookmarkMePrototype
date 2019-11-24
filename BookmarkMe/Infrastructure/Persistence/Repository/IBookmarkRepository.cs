namespace BookmarkMe.Infrastructure.Persistence.Repository
{
    using Domain.Model.Bookmark;

    public interface IBookmarkRepository
    {
        void Add(IBookmark bookmark);
        void Delete(int id);
        IBookmark[] Get();
        int NextId();
        IBookmark Find(int id);
        void Update(IBookmark bookmark);
    }
}
