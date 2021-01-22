using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zuperdukkan.Nhibernate;

namespace Zuperdukkan.Controllers
{
    public class dukkanController : Controller
    {
        [Obsolete]
        public ActionResult Listele()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var zup = session.Query<Models.dukkan>().ToList();
                return View(zup);
            }
        }










        public ActionResult Delete(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var sil = session.Query<Models.dukkan>().FirstOrDefault(x => x.Id_Zup == id);
                session.Delete(sil);
                session.Flush();
            }
            return RedirectToAction("Index");
        }





        public ActionResult Edit(int id)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var dukkan = session.Query<Models.dukkan>().FirstOrDefault(x => x.Id_Zup == id);
                return View(dukkan);
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, Models.dukkan Dukkan)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var Dukkans = session.Query<Models.dukkan>().FirstOrDefault(x => x.Id_Zup == id);
                Dukkans.Ad = Dukkan.Ad;
                Dukkans.Telefon = Dukkan.Telefon;
                session.SaveOrUpdate(Dukkan);
                session.Flush();
            }
            return RedirectToAction("Index");
        }












        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.dukkan Dukkan)
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                session.SaveOrUpdate(Dukkan);
                session.Flush();
            }
            return RedirectToAction("Index");
        }














        
    }
}