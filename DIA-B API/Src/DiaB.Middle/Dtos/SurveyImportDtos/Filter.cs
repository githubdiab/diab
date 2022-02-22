using System;
using System.ComponentModel;
using DiaB.Common.Enums;

namespace DiaB.Middle.Dtos.SurveyImportDtos
{
    public partial class SurveyImportDtos
    {
        public partial class Filter
        {
            public int? UserCode { get; set; }

            public string Username { get; set; }

            public string UserPhone { get; set; }

            public string SurveyType { get; set; }

            public string SurveyName { get; set; }

            public string SurveyStatus { get; set; }
        }
    }
}
