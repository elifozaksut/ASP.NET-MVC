using DAL.CRUD;
using Models;
using System.Threading;
using System.Web.Mvc;

namespace MvcMyBlog.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            ViewBag.Title = "Kategori Yönetim Sayfası";
            return View(); 
        }

        public JsonResult BindCategories()
        {
            CrudHelper select = new CrudHelper();
            var catList = select.CategorySelect();

            Thread.Sleep(5000);

            return Json(catList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertPar()
        {
            
            return View();
        }

        public ActionResult Insert(Category model)
        {
            
            CrudHelper crud = new CrudHelper();
            var IsSaved = crud.CategoryInsert(model);
            if (IsSaved)
            {
                ViewBag.Message = "Yeni Kategori Eklendi";
            }
            else
            {
                ViewBag.Message = "Bir Hata Oluştu";
            }

            return RedirectToAction("Index", "Category");
        }

        
        public ActionResult Update(int Id)
        {
            ViewBag.Title = "Kategori Yönetim Sayfası";
            CrudHelper crud = new CrudHelper();
             var selectedCategory = crud.CategorySelected(Id);

            return View("Update", selectedCategory);
        }

        [HttpPost]
        public ActionResult Update(Category model)
        {
            
            CrudHelper crud = new CrudHelper();
            var IsUpdate = crud.CategoryUpdate(model);
            return RedirectToAction("Index", "Category");
        }

        public ActionResult Delete(int Id)
        {
            CrudHelper crud = new CrudHelper();
            crud.CategoryDelete(Id);
            return RedirectToAction("Index", "Category");
        }
    }
}