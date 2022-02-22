using System;
using System.ComponentModel;
using DiaB.Common.Enums;

namespace DiaB.Middle.Dtos.SurveyImportDtos
{
    public partial class SurveyImportDtos
    {
        public partial class AppFilter
        {
            public string UserCode { get; set; }

            public string Username { get; set; }

            public string UserPhone { get; set; }

            public string SurveyType { get; set; }

            public string SurveyName { get; set; }

            public string SurveyStatus { get; set; }

            [DisplayName("sắp xếp theo")]
            public string SortBy { get; set; }

            public int Page { get; set; } = 1;

            public int Size { get; set; } = 1000;
        }
    }
}
