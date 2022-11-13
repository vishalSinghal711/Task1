using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblEmployee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeMobileNo { get; set; }
        public int EmployeeStatusId { get; set; }
        public int EmployeeBranchId { get; set; }
        public int EmployeeDepartmentId { get; set; }
        public string EmployeePhotoUrl { get; set; }
        public string EmployeeAddress { get; set; }
        public int EmployeeGender { get; set; }
        public int LoginId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual TblBranch EmployeeBranch { get; set; }
        public virtual TblDepartment EmployeeDepartment { get; set; }
        public virtual TblStatus EmployeeStatus { get; set; }
        public virtual TblLogin Login { get; set; }
    }
}
