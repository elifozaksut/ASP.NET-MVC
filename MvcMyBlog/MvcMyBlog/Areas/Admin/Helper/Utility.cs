using Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcMyBlog.Areas.Admin.Helper
{
    public class Utility
    {
        //Kategoriler için
        public static List<SelectListItem> ConvertList(List<Category> list)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem
            {
                Text = "Seçiniz",
                Value = "0",
                Selected = true
            });
            foreach (var item in list)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ID.ToString(),
                    Selected = false
                });
            }
            return result;
        }

        // Yazaralar için
        public static List<SelectListItem> ConvertList(List<Author> list)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            result.Add(new SelectListItem
            {
                Text = "Seçiniz",
                Value ="0",
                Selected= true
            });
            foreach (var item in list)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Name + " " + item.Surname,
                    Value = item.ID.ToString(),
                    Selected = false
                });
            }
            return result;
        }      
    }
}