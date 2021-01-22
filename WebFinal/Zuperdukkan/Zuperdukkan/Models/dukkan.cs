
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;

namespace Zuperdukkan.Models
{
    [Serializable]
    public class dukkan
    {
        public virtual int Id_Zup { get; set; }
        public virtual string Ad { get; set; }
        
        public virtual string Telefon { get; set; }
        public virtual ICollection<urun> Urunler { get; set; } = new List<urun>();
    }

   
    public class dukkanMap : ClassMapping<dukkan>
    {
        public dukkanMap()
        {
            Table("Dukkan");
            Id(x => x.Id_Zup, m => m.Generator(Generators.Native));
            Property(x => x.Ad, c => c.Length(20));
            Property(x => x.Telefon, c => c.Length(20));
            

            Set(e => e.Urunler,
                mapper =>
                {
                    mapper.Key(k => k.Column("Dukkan"));
                    mapper.Inverse(true);
                    mapper.Cascade(Cascade.All);
                },
               relation => relation.OneToMany(mapping => mapping.Class(typeof(urun))));
        }
    }
}