using System;
using System.ComponentModel;
using DiaB.Common.Enums;
using Microsoft.AspNetCore.Http;

namespace DiaB.Middle.Dtos.SurveyImportResultDtos
{
    public partial class SurveyImportResultDtos
    {
        public partial class AppUpdate
        {
            public Guid Id { get; set; }

            public string UserName { get; set; }
            public string UserGender { get; set; }
            public int UserYearofbirth { get; set; }
            public string UserCareer { get; set; }
            public string UserHoobit { get; set; }
            public string UserProvince { get; set; }
            public string StorySuccess { get; set; }
            public string UserTypeofsick { get; set; }
            public int YearFoundout { get; set; }
            public IFormFile Image { get; set; }

            public string KtNxtq { get; set; }
            public string KntcsNxtq { get; set; }
            public string MdrcNxtq { get; set; }
            public string KndctlNxtq { get; set; }
            public string DltdNxtq { get; set; }
            public string Nxtq { get; set; }
            public string DxvmtNxtq { get; set; }
            public string KhvhdNxtq { get; set; }
            public string Status { get; set; }
        }
    }
}
