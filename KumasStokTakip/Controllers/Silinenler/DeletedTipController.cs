using KumasStokTakip.Models.Entity;
using KumasStokTakip.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KumasStokTakip.Controllers.Silinenler
{
    public class DeletedTipController : Controller
    {
        KumasTakipEntities2 db = new KumasTakipEntities2();
        StokTipRepository repo = new StokTipRepository();
        public ActionResult DeletedListTip(string p)
        {
            var values = from d in db.Tip select d;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(x => x.TipAdı.Contains(p));
            }
            return View(values.Where(x => x.Status == false).ToList());
   
        }
        public ActionResult UpdateDeletedTip(int id)
        {

            var values = repo.Find(x => x.ID == id);
            values.Status = true;
            repo.TUpdate(values);
            return RedirectToAction("DeletedListTip");
        }
    }
}