using DiaB.Common.Enums;
using System;
using System.ComponentModel;
using System.IO;
using static DiaB.Middle.Dtos.ImageDtos.ImageDtos;

namespace DiaB.Middle.Dtos.SurveyImportResultDtos
{
    public partial class SurveyImportResultDtos
    {
        public partial class AppItem
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
            public AppUrl Avatar { get; set; }


            public int Hba1cVal { get; set; }
            public int BmiVal { get; set; }
            public int KtBlVal { get; set; }
            public int KtTdcsVal { get; set; }
            public int KtDdVal { get; set; }
            public int KtVdVal { get; set; }
            public int KtThVal { get; set; }
            public int KtTlhvVal { get; set; }
            public int KtVal { get; set; }
            public string KtNxtq { get; set; }
            public int KntcsHtVal { get; set; }
            public int KntcsCsbcVal { get; set; }
            public int KntcsTddhVal { get; set; }
            public int KntcsCdvdVal { get; set; }
            public int KntcsCdauVal { get; set; }
            public int KntcsVal { get; set; }
            public string KntcsNxtq { get; set; }
            public int MdrcDtVal { get; set; }
            public int MdrcDhVal { get; set; }
            public int MdrcCdvdVal { get; set; }
            public int MdrcCdauVal { get; set; }
            public int MdrcVal { get; set; }
            public string MdrcNxtq { get; set; }
            public int KndctlCtlqdbsVal { get; set; }
            public int KndctlCttcmqhVal { get; set; }
            public int KndctlGnvttdtVal { get; set; }
            public int KndctlGncxVal { get; set; }
            public int KndctlVal { get; set; }
            public string KndctlNxtq { get; set; }
            public int DltdDltdbtVal { get; set; }
            public int DltdDltdbnVal { get; set; }
            public int DltdVal { get; set; }
            public string DltdNxtq { get; set; }
            public string Nxtq { get; set; }
            public string DxvmtNxtq { get; set; }
            public string KhvhdNxtq { get; set; }
            public bool IsClose { get; set; }

            [DisplayName("nội dung report")]
            public Stream? FileReport { get; set; }

            [DisplayName("tên report")]
            public String FileReportTitle { get; set; }
        }
    }
}
