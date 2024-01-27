using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSite.Models.Siniflar;

namespace TatilSeyahatSite.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context c =  new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var degerler = c.Blogs.ToList();
            by.Deger1 = c.Blogs.OrderByDescending(x => x.ID).ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x=>x.ID).Take(2);
            return View(by);
        }
        
        public ActionResult BlogDetay(int id)
        {
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            by.Deger3 = c.Blogs.OrderByDescending(x => x.ID).Take(2);
            by.Deger4 = c.Yorumlars.OrderByDescending(x => x.ID).Take(2);
            return View(by);
        }

        public PartialViewResult SonBloglar()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult SonYorumlar()
        {
            by.Deger4 = c.Yorumlars.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}