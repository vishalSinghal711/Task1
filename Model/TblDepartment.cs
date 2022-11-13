using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblDepartment
    {
        public TblDepartment()
        {
            TblEmployee = new HashSet<TblEmployee>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<TblEmployee> TblEmployee { get; set; }
    }
}
