using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using Zuperdukkan.Nhibernate;

namespace Zuperdukkan.Controllers
{
    public class urunController : Controller
    {
        

        
        









        public ActionResult Index()
        {
            using (var session = NhibernateHelper.OpenSession())
            {
                var sad = session.Query<Models.urun>().ToList();
                return View(sad);
            }
        }
    }
}
