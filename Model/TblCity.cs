using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblCity
    {
        public TblCity()
        {
            TblCompany = new HashSet<TblCompany>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }

        public virtual TblState State { get; set; }
        public virtual ICollection<TblCompany> TblCompany { get; set; }
    }
}
