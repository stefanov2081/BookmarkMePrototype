namespace BookmarkMe.Interfaces.Bookmark.Facade
{
    using System.Collections.Generic;
    using Domain.Model.Bookmark;

    internal interface IBookmarkDtoAssembler
    {
        IBookmarkDto ToDto(Bookmark bookmark);
        IList<IBookmarkDto> ToDtoIList(IList<Bookmark> bookmark);
    }
}
