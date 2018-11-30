namespace BookmarkMe.Infrastructure.Persistence.Repository
{
    internal interface IUnitOfWork
    {
        IBookmarkRepository BookmarkRepository { get; }

        void Save();
    }
}
