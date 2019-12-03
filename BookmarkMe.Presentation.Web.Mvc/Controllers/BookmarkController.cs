namespace BookmarkMe.Presentation.Web.Mvc.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using BookmarkMe.Application.Service.Bookmark;
    using BookmarkMe.Presentation.Web.Mvc.Repository;
    using Presentation.Web.Mvc.ViewModels.Bookmark;

    public class BookmarkController : Controller
    {
        private BookmarkService<BookmarkViewModel> bookmarkService;

        public BookmarkController()
        {
            bookmarkService = new BookmarkService<BookmarkViewModel>(new UnitOfWork(), new BookmarkMapper());
        }

        public ActionResult Delete(int? id)
        {
            if (IsBadRequest(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bookmark = bookmarkService.FindBookmark(id.GetValueOrDefault());

            if (IsNotFound(bookmark))
            {
                return HttpNotFound();
            }

            return View(bookmark);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookmarkService.DeleteBookmark(id);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (IsBadRequest(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bookmark = bookmarkService.FindBookmark(id.GetValueOrDefault());

            if (IsNotFound(bookmark))
            {
                return HttpNotFound();
            }

            return View(bookmark);
        }

        public ActionResult Edit(int? id)
        {
            if (IsBadRequest(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bookmark = bookmarkService.FindBookmark(id.GetValueOrDefault());

            if (IsNotFound(bookmark))
            {
                return HttpNotFound();
            }

            return View(bookmark);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Url,ThumbnailUrl")] BookmarkViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }

            bookmarkService.EditBookmark(editViewModel.Id, editViewModel.Name, editViewModel.Url);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Url,ThumbnailUrl")] BookmarkViewModel createBookmarkViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createBookmarkViewModel);
            }

            bookmarkService.CreateBookmark(createBookmarkViewModel.Name, createBookmarkViewModel.Url, createBookmarkViewModel.ThumbnailUrl);

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var bookmarks = bookmarkService.GetBookmarks();

            return View(bookmarks);
        }

        public string ThumbnailUrl()
        {
            return "https://www.google.com/images/branding/googleg/1x/googleg_standard_color_128dp.png";
        }

        private bool IsBadRequest(int? parameter)
        {
            return parameter.HasValue == false;
        }

        private bool IsNotFound(object obj)
        {
            return obj is null;
        }
    }
}