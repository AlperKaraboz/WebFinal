using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zuperdukkan.Models
{
    public class urun
    {
        public virtual int Id { get; set; }
        public virtual string Ad { get; set; }
        public virtual string Fiyat { get; set; }
        public virtual dukkan Dukkan { get; set; }

    }

    public class urunMap : ClassMapping<urun>
    {
        public urunMap()
        {
            Table("Urun");
            Id(x => x.Id, m => m.Generator(Generators.Native));
            Property(x => x.Ad, c => c.Length(40));
            Property(x => x.Fiyat, c => c.Length(20));
            ManyToOne(x => x.Dukkan);
        }
    }
}