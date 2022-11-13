using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblStatus
    {
        public TblStatus()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string ColorClass { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
