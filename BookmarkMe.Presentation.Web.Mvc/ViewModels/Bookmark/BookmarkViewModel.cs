namespace BookmarkMe.Presentation.Web.Mvc.ViewModels.Bookmark
{
    using System.ComponentModel.DataAnnotations;
    using BookmarkMe.Interfaces.Bookmark.Web.Mvc;

    public class BookmarkViewModel : IBookmarkViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string Uri { get; set; }
    }
}