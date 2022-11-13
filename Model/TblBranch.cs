using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblBranch
    {
        public TblBranch()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
