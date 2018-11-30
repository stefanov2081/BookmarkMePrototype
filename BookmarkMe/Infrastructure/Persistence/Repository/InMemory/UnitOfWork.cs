namespace BookmarkMe.Infrastructure.Persistence.Repository.InMemory
{
    internal class UnitOfWork : IUnitOfWork
    {
        private IBookmarkRepository bookmarkRepository;

        public UnitOfWork()
        {
        }

        public IBookmarkRepository BookmarkRepository => bookmarkRepository ?? (bookmarkRepository = new BookmarkRepository());

        public void Save()
        {
            // Do nothing
        }
    }
}
