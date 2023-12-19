using KumasStokTakip.Models.Entity;
using KumasStokTakip.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KumasStokTakip.Controllers.Islemler
{
    public class KumasTipiController : Controller
    {
        // GET: KumasTipi
        KumasTakipEntities2 db = new KumasTakipEntities2();
        KumasTipiRepository repo = new KumasTipiRepository();
        StokTipRepository re = new StokTipRepository();

        
        public ActionResult ListKumas(string p,int id) //int p
        {
            var values = from d in db.Tbl_KumasTipi select d;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(x => x.KumasAdi.Contains(p));
            }
            return View(values.Where(x=>x.TipID==id&&x.Status==true).ToList());


            /*var values = repo.list();  //re.Find(x => x.ID == p);  //Find(x => x.TipID == p);  

            return View(values);*/
        }
        [HttpGet]
        public ActionResult AddKumas()
        {
            List<SelectListItem> valueTip = (from x in re.list()
                                             select new SelectListItem
                                             {
                                                 Text = x.TipAdı,
                                                 Value = x.ID.ToString()
                                             }
                                                 ).ToList();
            ViewBag.vlc = valueTip;

            return View();

            
        }
        [HttpPost]
        public ActionResult AddKumas(Tbl_KumasTipi p)
        {
            p.Status = true;
            repo.TAdd(p);
            return RedirectToAction("ListKumas");


        }
        public ActionResult DeleteKumas(int id)
        {
            var values = repo.Find(x => x.ID == id);
            values.Status = false;
            repo.TUpdate(values);
            return RedirectToAction("ListKumas");
        }

        [HttpGet]
        public ActionResult UpdateKumas(int id)
        {
            List<SelectListItem> valueTip = (from x in re.list()
                                             select new SelectListItem
                                             {
                                                 Text = x.TipAdı,
                                                 Value = x.ID.ToString()
                                             }
                                                 ).ToList();
            ViewBag.vlc = valueTip;

            var values = repo.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateKumas(Tbl_KumasTipi p)
        {
            if (!ModelState.IsValid)
            {

                return RedirectToAction("UpdateKumas");

            }
            else
            {
                var values = repo.Find(x => x.ID == p.ID);
                values.KumasAdi = p.KumasAdi;
                repo.TUpdate(values);
                return RedirectToAction("ListKumas");
                
            }

        }

    }
}