using DAL.CRUD;
using Models;
using System.Web.Mvc;

namespace MvcMyBlog.Areas.Admin.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Admin/Autor
        public ActionResult Index()
        {
            ViewBag.Title = "Yazar Yönetimi Sayfası";
            CrudHelper crud = new CrudHelper();
            var authorList = crud.AuthorSelect();
            ViewBag.AuthorList = authorList;
            return View();
        }

        public ActionResult Insert(Author model)
        {
            CrudHelper crud = new CrudHelper();
            crud.AuthorInsert(model);
            return RedirectToAction("Index", "Author");
        }

        public ActionResult Update(int id)
        {
            ViewBag.Title = "Yazar Yönetimi Sayfası";
            CrudHelper crud = new CrudHelper();
            Author model = crud.AuthorSelected(id);

            return View("Update",model);
        }

        [HttpPost]
        public ActionResult Update(Author model)
        {
            CrudHelper crud = new CrudHelper();
            crud.AuthorUpdate(model);
            return RedirectToAction("Index", "Author");
        }

        public ActionResult Delete(Author model)
        {
            CrudHelper crud = new CrudHelper();
            crud.AuthorDelete(model);
            return RedirectToAction("Index", "Author");
        }
    }
}