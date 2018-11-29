namespace BookmarkMe.Interface.Web.Mvc.ViewModels.Bookmark
{
    using BookmarkMe.Application.Service.Bookmark;

    public class DeleteViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Uri { get; set; }
    }
}