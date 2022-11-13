using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblState
    {
        public TblState()
        {
            TblCity = new HashSet<TblCity>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }

        public virtual ICollection<TblCity> TblCity { get; set; }
    }
}
