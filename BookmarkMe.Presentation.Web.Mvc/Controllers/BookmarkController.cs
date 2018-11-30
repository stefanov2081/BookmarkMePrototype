namespace BookmarkMe.Presentation.Web.Mvc.Controllers
{
    using System.Net;
    using System.Web.Mvc;
    using Interfaces.Bookmark.Facade.Web.Mvc;
    using Presentation.Web.Mvc.Assemblers;
    using Presentation.Web.Mvc.ViewModels.Bookmark;

    public class BookmarkController : Controller
    {
        private BookmarkServiceFacade bookmarkService;
        private BookmarkViewModelAssembler viewModelFactory;

        public BookmarkController()
        {
            bookmarkService = new BookmarkServiceFacade();
            viewModelFactory = new BookmarkViewModelAssembler();
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

            var viewModel = viewModelFactory.ToDeleteViewModel(bookmark);

            return View(viewModel);
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

            return View(viewModelFactory.ToDetailsViewModel(bookmark));
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

            return View(viewModelFactory.ToEditViewModel(bookmark));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Uri")] EditViewModel editViewModel)
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
        public ActionResult Create([Bind(Include = "Id,Name,Uri")] CreateViewModel createBookmarkViewModel)
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
            var bookmarks = bookmarkService.GetBookmarks();

            return View(viewModelFactory.ToIndexViewModel(bookmarks));
        }

        private bool IsBadRequest(int? parameter)
        {
            return !parameter.HasValue;
        }

        private bool IsNotFound(object obj)
        {
            return obj is null;
        }
    }
}