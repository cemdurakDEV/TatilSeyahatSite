using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TatilSeyahatSite.Models.Siniflar;

namespace TatilSeyahatSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }

        [HttpGet] //bu ifade olmasa sayfa hiçbir şey yapmadan yeni kayıt ekler.
        [Authorize]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogBilgiGetir(int id)
        {
            var b = c.Blogs.Find(id);
            return View("BlogBilgiGetir", b);
        }
        [Authorize]
        public ActionResult BlogSil(int id)
        {
            Blog b = c.Blogs.Where(m => m.ID == id).FirstOrDefault();
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Baslik = b.Baslik;
            blg.Tarih = b.Tarih;
            blg.BlogImage = b.BlogImage;
            blg.Aciklama = b.Aciklama;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult YorumListesi()
        {
            var yorumlar = c.Yorumlars.ToList();
            return View("YorumListesi", yorumlar);
        }
        [Authorize]
        public ActionResult YorumBilgiGetir(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            return View("YorumBilgiGetir", yorum);
        }
        [Authorize]
        public ActionResult YorumSil(int id)
        {
            var yorum = c.Yorumlars.Where(x => x.ID == id).FirstOrDefault();
            c.Yorumlars.Remove(yorum);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        [Authorize]
        public ActionResult YorumGuncelle(Yorumlar y)
        {
            var yorum = c.Yorumlars.Find(y.ID);
            yorum.Kullanici = y.Kullanici;
            yorum.Yorum = y.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}