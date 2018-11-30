namespace BookmarkMe.Presentation.Web.Mvc.ViewModels.Bookmark
{
    using System.ComponentModel.DataAnnotations;

    public class CreateViewModel
    {
        [Required]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string Uri { get; set; }
    }
}