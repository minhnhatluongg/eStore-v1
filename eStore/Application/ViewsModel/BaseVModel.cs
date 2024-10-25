using OA.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewsModel
{
    public class FiltersGetAllVModel
    {
        public bool? IsActive { get; set; }
        public long? LanguageId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int PageSize { get; set; } = CommonConstants.ConfigNumber.pageSizeDefault;
        public int PageNumber { get; set; } = 1;
        public bool IsDescending { get; set; } = true;
    }
}
