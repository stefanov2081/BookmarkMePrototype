namespace BookmarkMe.Presentation.Web.Mvc.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using BookmarkMe.Interactors.Bookmark;
    using BookmarkMe.Presentation.Web.Mvc.Repository;
    using BookmarkMe.Presentation.Web.Mvc.Utilities;
    using Presentation.Web.Mvc.ViewModels.Bookmark;

    public class BookmarkController : Controller
    {
        private BookmarkServiceInteractor bookmarkService;

        public BookmarkController()
        {
            bookmarkService = new BookmarkServiceInteractor(new UnitOfWork());
        }

        public ActionResult Delete(int? id)
        {
            if (IsBadRequest(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var bookmark = bookmarkService.FindBookmark<BookmarkViewModel>(id.GetValueOrDefault());

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

            var bookmark = bookmarkService.FindBookmark<BookmarkViewModel>(id.GetValueOrDefault());

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

            var bookmark = bookmarkService.FindBookmark<BookmarkViewModel>(id.GetValueOrDefault());

            if (IsNotFound(bookmark))
            {
                return HttpNotFound();
            }

            return View(bookmark);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Uri")] BookmarkViewModel editViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(editViewModel);
            }

            bookmarkService.EditBookmark(editViewModel.Id, editViewModel.Name, editViewModel.Uri);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Uri")] BookmarkViewModel createBookmarkViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createBookmarkViewModel);
            }

            bookmarkService.CreateBookmark(createBookmarkViewModel.Name, createBookmarkViewModel.Uri);

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            var asd = ThumbnailTest.GetWebSiteThumbnail("https://www.google.com/", 100, 100, 100, 100);


            var bookmarks = bookmarkService.GetBookmarks<BookmarkViewModel>();

            return View(bookmarks);
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