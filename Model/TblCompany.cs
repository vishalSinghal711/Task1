using System;
using System.Collections.Generic;

namespace AmritERP.Model
{
    public partial class TblCompany
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyGstno { get; set; }
        public string CompanyAddress { get; set; }
        public int CityId { get; set; }
        public string CompanyMobileNo { get; set; }
        public string CompanyLogoUrl { get; set; }
        public DateTime CompanyStartDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual TblCity City { get; set; }
    }
}
