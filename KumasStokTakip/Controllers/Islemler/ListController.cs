using KumasStokTakip.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KumasStokTakip.Models.Entity;

namespace KumasStokTakip.Controllers.Islemler
{
    public class ListController : Controller
    {
        // GET: List
       StokTipRepository repo = new StokTipRepository();
        KumasTakipEntities2 db =new KumasTakipEntities2();
        
        public ActionResult ListTip(string p)
        {

            var values = from d in db.Tip select d;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(x => x.TipAdı.Contains(p));
            }
            return View(values.Where(x=> x.Status==true).ToList());
            /*var values = repo.list();
            return View(values);*/
        }
        [HttpGet]
        public ActionResult AddTip()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTip(Tip p)
        {
            if (!ModelState.IsValid)
            {
                return View("ListTip");
            }
            else
            {
                
                p.Status = true;
                repo.TAdd(p); 
                return RedirectToAction("ListTip");
            }


        }
        public ActionResult DeleteTip(int id)
        {
            var values = repo.Find(x => x.ID == id);
            values.Status = false;
            repo.TUpdate(values);
            return RedirectToAction("ListTip");
        }

        [HttpGet]
        public ActionResult UpdateTip(int id)
        {
            var values = repo.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateTip(Tip p)
        {
            if (!ModelState.IsValid)
            {
                return View("UpdateTip");

            }
            else
            {
                var values = repo.Find(x => x.ID == p.ID);
                values.TipAdı = p.TipAdı;
                repo.TUpdate(values);
                return RedirectToAction("ListTip");
            }

        }


    }
}