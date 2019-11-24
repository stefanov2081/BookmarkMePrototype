namespace BookmarkMe.Presentation.Web.Mvc.Repository
{
    using BookmarkMe.Infrastructure.Persistence.Repository;

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
