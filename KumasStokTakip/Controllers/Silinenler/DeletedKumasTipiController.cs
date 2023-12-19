using KumasStokTakip.Models.Entity;
using KumasStokTakip.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KumasStokTakip.Controllers.Silinenler
{
    public class DeletedKumasTipiController : Controller
    {
        // GET: DeletedKumasTipi
        KumasTakipEntities2 db = new KumasTakipEntities2();
        KumasTipiRepository repo = new KumasTipiRepository();
        
        public ActionResult DeletedListKumas(string p)
        {
            var values = from d in db.Tbl_KumasTipi select d;
            if (!string.IsNullOrEmpty(p))
            {
                values = values.Where(x => x.KumasAdi.Contains(p));
            }
            return View(values.Where(x => x.Status == false).ToList());

        }
        
        public ActionResult UpdateDeletedKumas(int id)
        {

            var values = repo.Find(x => x.ID == id);
            values.Status= true;
            repo.TUpdate(values);
            return RedirectToAction("DeletedListKumas");
        }
    }
}