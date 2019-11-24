namespace BookmarkMe.Infrastructure.Persistence.Repository
{
    public interface IUnitOfWork
    {
        IBookmarkRepository BookmarkRepository { get; }
        void Save();
    }
}
