using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblMenu
    {
        public TblMenu()
        {
            TblPages = new HashSet<TblPages>();
        }

        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int SortOrder { get; set; }
        public string ColorClass { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TblPages> TblPages { get; set; }
    }
}
