namespace BookmarkMe.Interface.Web.Mvc
{
    using BookmarkMe.Infrastructure.Persistence.Repository;
    using BookmarkMe.Infrastructure.Persistence.Repository.InMemory;

    public static class StaticRepoContainer
    {
        static StaticRepoContainer()
        {
            UnitOfWork = new UnitOfWork();
        }

        public static IUnitOfWork UnitOfWork { get; private set; }
    }
}