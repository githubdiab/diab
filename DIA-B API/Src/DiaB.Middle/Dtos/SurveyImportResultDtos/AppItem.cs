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


            public double Hba1cVal { get; set; }
            public double BmiVal { get; set; }
            public double KtBlVal { get; set; }
            public double KtTdcsVal { get; set; }
            public double KtDdVal { get; set; }
            public double KtVdVal { get; set; }
            public double KtThVal { get; set; }
            public double KtTlhvVal { get; set; }
            public double KtVal { get; set; }
            public string KtNxtq { get; set; }
            public double KntcsHtVal { get; set; }
            public double KntcsCsbcVal { get; set; }
            public double KntcsTddhVal { get; set; }
            public double KntcsCdvdVal { get; set; }
            public double KntcsCdauVal { get; set; }
            public double KntcsVal { get; set; }
            public string KntcsNxtq { get; set; }
            public double MdrcDtVal { get; set; }
            public double MdrcTddhVal { get; set; }
            public double MdrcCdvdVal { get; set; }
            public double MdrcCdauVal { get; set; }
            public double MdrcVal { get; set; }
            public string MdrcNxtq { get; set; }
            public double KndctlCtlqdbsVal { get; set; }
            public double KndctlCttcmqhVal { get; set; }
            public double KndctlGnvttdtVal { get; set; }
            public double KndctlGncxVal { get; set; }
            public double KndctlVal { get; set; }
            public string KndctlNxtq { get; set; }
            public double DltdDltdbtVal { get; set; }
            public double DltdDltdbnVal { get; set; }
            public double DltdVal { get; set; }
            public string DltdNxtq { get; set; }
            public string Nxtq { get; set; }
            public string DxvmtNxtq { get; set; }
            public string KhvhdNxtq { get; set; }

            public string CourseGoal { get; set; }

            public bool IsClose { get; set; }

            [DisplayName("nội dung report")]
            public Stream? FileReport { get; set; }

            [DisplayName("tên report")]
            public String FileReportTitle { get; set; }
        }
    }
}
