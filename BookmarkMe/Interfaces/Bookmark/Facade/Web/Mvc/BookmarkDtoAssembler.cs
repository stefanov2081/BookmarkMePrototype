namespace BookmarkMe.Interfaces.Bookmark.Facade.Web.Mvc
{
    using System.Collections.Generic;
    using Domain.Model.Bookmark;

    internal sealed class BookmarkDtoAssembler : IBookmarkDtoAssembler
    {
        //public BookmarkDto ToBookmarkDto(Bookmark bookmark)
        //{
        //    return new BookmarkDto(bookmark.Id, bookmark.Name, bookmark.Uri);
        //}

        //public IList<IBookmark> ToBookmarkDtoArray(IList<Bookmark> bookmark)
        //{
        //    var result = new BookmarkDto[bookmark.Count];

        //    for (int i = 0; i < result.Length; i++)
        //    {
        //        result[i] = new BookmarkDto(bookmark[i].Id, bookmark[i].Name, bookmark[i].Uri);
        //    }

        //    return result;
        //}

        public IList<IBookmarkDto> ToDtoIList(IList<Bookmark> bookmark)
        {
            var result = new BookmarkDto[bookmark.Count];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new BookmarkDto(bookmark[i].Id, bookmark[i].Name, bookmark[i].Uri);
            }

            return result;
        }

        public IBookmarkDto ToDto(Bookmark bookmark)
        {
            return new BookmarkDto(bookmark.Id, bookmark.Name, bookmark.Uri);
        }
    }
}
