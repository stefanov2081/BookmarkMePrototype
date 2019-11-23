namespace BookmarkMe.Infrastructure.Persistence.Repository.InMemory
{
    using BookmarkMe.Presentation.Web.Mvc.Repository;

    public class UnitOfWork : IUnitOfWork
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
