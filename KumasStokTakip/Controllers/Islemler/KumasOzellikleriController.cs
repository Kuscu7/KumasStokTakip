using KumasStokTakip.Models.Entity;
using KumasStokTakip.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KumasStokTakip.Controllers.Islemler
{
    public class KumasOzellikleriController : Controller
    {
        // GET: KumasOzellikleri
        KumasOzelliklerRepository repo = new KumasOzelliklerRepository();
       KumasTipiRepository re = new KumasTipiRepository();
        KumasTakipEntities2 db=new KumasTakipEntities2();
        public ActionResult ListKumasOzellikleri(string p,int id)
        {
            var values = from d in db.KumasOzellikleri select d;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(x => x.Renk.Contains(p));
            }
            return View(values.Where(x => x.KumasTipiID == id && x.Status == true).ToList());
        }
        [HttpGet]
        public ActionResult AddKumasOzellikleri()
        {
            List<SelectListItem> valueTip = (from x in re.list()
                                             select new SelectListItem
                                             {
                                                 Text = x.KumasAdi,
                                                 Value = x.ID.ToString()
                                             }
                                                 ).ToList();
            ViewBag.vlc = valueTip;

            return View();


        }
        [HttpPost]
        public ActionResult AddKumasOzellikleri(KumasOzellikleri p)
        {
            p.Status = true;
            repo.TAdd(p);
            return RedirectToAction("ListKumasOzellikleri");


        }
        public ActionResult DeleteKumasOZellikleri(int id)
        {
            var values = repo.Find(x => x.ID == id);
            repo.TDelete(values);
            return RedirectToAction("ListKumasOzellikleri");
        }

        [HttpGet]
        public ActionResult UpdateKumasOzellikleri(int id)
        {
            List<SelectListItem> valueTip = (from x in re.list()
                                             select new SelectListItem
                                             {
                                                 Text = x.KumasAdi,
                                                 Value = x.ID.ToString()
                                             }
                                                 ).ToList();
            ViewBag.vlc = valueTip;

            var values = repo.Find(x => x.ID == id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateKumasOzellikleri(KumasOzellikleri p)
        {
            if (!ModelState.IsValid)
            {

                return RedirectToAction("UpdateKumasOzellikleri");

            }
            else
            {
                var values = repo.Find(x => x.ID == p.ID);
                values.TopSayisi = p.TopSayisi;
                values.Metre= p.Metre;
                values.Renk = p.Renk;
                values.KumasTipiID = p.KumasTipiID;

                repo.TUpdate(values);
                return RedirectToAction("ListKumasOzellikleri");

            }

        }

    }
}