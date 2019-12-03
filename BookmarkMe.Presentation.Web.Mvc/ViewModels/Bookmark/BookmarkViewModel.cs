namespace BookmarkMe.Presentation.Web.Mvc.ViewModels.Bookmark
{
    using System.ComponentModel.DataAnnotations;
    using BookmarkMe.Domain.Model.Bookmark;

    public class BookmarkViewModel : IBookmark
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string Url { get; set; }

        public string LogoUrl { get; set; }
    }
}