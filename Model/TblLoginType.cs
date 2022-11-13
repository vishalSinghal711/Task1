using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblLoginType
    {
        public TblLoginType()
        {
            TblLogin = new HashSet<TblLogin>();
            TblLoginTypePages = new HashSet<TblLoginTypePages>();
        }

        public int LoginTypeId { get; set; }
        public string LoginTypeName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TblLogin> TblLogin { get; set; }
        public virtual ICollection<TblLoginTypePages> TblLoginTypePages { get; set; }
    }
}
