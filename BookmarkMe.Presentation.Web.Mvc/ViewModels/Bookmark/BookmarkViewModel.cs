namespace BookmarkMe.Presentation.Web.Mvc.ViewModels.Bookmark
{
    using System.ComponentModel.DataAnnotations;
    using BookmarkMe.Interactors.Bookmark;

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