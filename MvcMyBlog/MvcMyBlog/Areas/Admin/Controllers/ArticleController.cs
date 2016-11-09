using DAL.CRUD;
using Models;
using MvcMyBlog.Areas.Admin.Helper;
using System.Web.Mvc;

namespace MvcMyBlog.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Makale Yönetim Sayfası";
            CrudHelper crud = new CrudHelper();
            var categoryList = crud.CategorySelect();
            ViewBag.CategoryList = Utility.ConvertList(categoryList);

            var authorlist = crud.AuthorSelect();
            ViewBag.AuthorList = Utility.ConvertList(authorlist);

            var articleList = crud.ArticleSelect();
            ViewBag.ArticleList = articleList;
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Article model)
        {
            CrudHelper crud = new CrudHelper();           
            crud.ArticleInsert(model);           
            return RedirectToAction("Index", "Article");
        }
    }
}