using DiaB.Common.Enums;
using System;
using System.ComponentModel;
using System.IO;

namespace DiaB.Middle.Dtos.AccountImportDtos
{
    public partial class AccountImportDtos
    {
        public partial class AppItem
        {
            [DisplayName("mã định danh")]
            public Guid Id { get; set; }

            [DisplayName("mã bệnh nhân")]
            public string UserCode { get; set; }

            [DisplayName("tên hl")]
            public string Username { get; set; }

            [DisplayName("loại báo cáo")]
            public string SurveyType { get; set; }

            [DisplayName("mã khảo sát")]
            public string SurveyCode { get; set; }

            [DisplayName("ngày xử lý báo cáo")]
            public DateTime? ImportDay { get; set; }

           public string SurveyStatus { get; set; }

            public Guid? SurveyResultId { get; set; }
        }
    }
}
