using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblLogin
    {
        public TblLogin()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int LoginId { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public int LoginTypeId { get; set; }
        public DateTime LastLoginDateTime { get; set; }
        public bool IsDeleted { get; set; }

        public virtual TblLoginType LoginType { get; set; }
        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
