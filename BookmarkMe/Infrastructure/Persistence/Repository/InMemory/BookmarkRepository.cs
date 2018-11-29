namespace BookmarkMe.Infrastructure.Persistence.Repository.InMemory
{
    using System.Collections.Generic;
    using System.Linq;
    using Domain.Model.Bookmark;

    public class BookmarkRepository : IBookmarkRepository
    {
        private SortedDictionary<int, Bookmark> bookmarks;

        public BookmarkRepository()
        {
            bookmarks = new SortedDictionary<int, Bookmark>();
        }

        public void Add(Bookmark bookmark)
        {
            bookmarks.Add(bookmark.Id, bookmark);
        }

        public void Delete(int id)
        {
            bookmarks.Remove(id);
        }

        public Bookmark Find(int id)
        {
            if (!bookmarks.ContainsKey(id))
            {
                return null;
            }

            return bookmarks[id];
        }

        public IList<Bookmark> Get()
        {
            var result = new Bookmark[bookmarks.Count];
            bookmarks.Values.CopyTo(result, 0);

            return result;
        }

        public int NextId()
        {
            return bookmarks.Keys.LastOrDefault() + 1;
        }

        public void Update(Bookmark bookmark)
        {
            bookmarks[bookmark.Id] = bookmark;
        }
    }
}
