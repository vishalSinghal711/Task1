using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblLoginTypePages
    {
        public int LoginTypePagesId { get; set; }
        public int LoginTypeId { get; set; }
        public int PageId { get; set; }

        public virtual TblLoginType LoginType { get; set; }
        public virtual TblPages Page { get; set; }
    }
}
