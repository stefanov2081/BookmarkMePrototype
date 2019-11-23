namespace BookmarkMe.Presentation.Web.Mvc.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using BookmarkMe.Infrastructure.Persistence.Repository;
    using Domain.Model.Bookmark;

    internal class BookmarkRepository : IBookmarkRepository
    {
        private static SortedDictionary<int, IBookmark> bookmarks;

        static BookmarkRepository()
        {
            bookmarks = new SortedDictionary<int, IBookmark>();
        }

        public void Add(IBookmark bookmark)
        {
            bookmarks.Add(bookmark.Id, bookmark);
        }

        public void Delete(int id)
        {
            bookmarks.Remove(id);
        }

        public IBookmark Find(int id)
        {
            if (!bookmarks.ContainsKey(id))
            {
                return null;
            }

            return bookmarks[id];
        }

        public IList<IBookmark> Get()
        {
            return bookmarks.Values.ToArray();
        }

        public int NextId()
        {
            return bookmarks.Keys.LastOrDefault() + 1;
        }

        public void Update(IBookmark bookmark)
        {
            bookmarks[bookmark.Id] = bookmark;
        }
    }
}
