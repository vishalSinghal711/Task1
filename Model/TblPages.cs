using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblPages
    {
        public TblPages()
        {
            TblLoginTypePages = new HashSet<TblLoginTypePages>();
        }

        public int PageId { get; set; }
        public string PageName { get; set; }
        public int MenuId { get; set; }
        public string PageStateName { get; set; }
        public int PageOrder { get; set; }
        public bool IsDeleted { get; set; }

        public virtual TblMenu Menu { get; set; }
        public virtual ICollection<TblLoginTypePages> TblLoginTypePages { get; set; }
    }
}
