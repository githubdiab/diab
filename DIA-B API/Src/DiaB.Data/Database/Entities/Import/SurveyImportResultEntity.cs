using System;
using System.ComponentModel.DataAnnotations;
using CpTech.Core.Data.Entities;
using DiaB.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaB.Data.Database.Entities.Import
{
    public class SurveyImportResultEntity : ModelEntity<SurveyImportResultEntity>
    {
        public double Hba1cVal { get; set; }
        public String Hba1cPhanloai { get; set; }
        public double BmiVal { get; set; }
        public String BmiPhanloai { get; set; }

        public double KtBlVal { get; set; }
        public double KtTdcsVal { get; set; }
        public double KtDdVal { get; set; }
        public double KtVdVal { get; set; }
        public double KtThVal { get; set; }
        public double KtTlhvVal { get; set; }
        public double KtVal { get; set; }
        public String KtPhanloai { get; set; }
        public string KtNxtq { get; set; }

        public double KntcsHtVal { get; set; }
        public double KntcsCsbcVal { get; set; }
        public double KntcsTddhVal { get; set; }
        public double KntcsCdvdVal { get; set; }
        public double KntcsCdauVal { get; set; }
        public double KntcsVal { get; set; }
        public String KntcsPhanloai { get; set; }
        public string KntcsNxtq { get; set; }

        public double MdrcDtVal { get; set; }
        public double MdrcTddhVal { get; set; }
        public double MdrcCdvdVal { get; set; }
        public double MdrcCdauVal { get; set; }
        public double MdrcVal { get; set; }
        public String MdrcPhanloai { get; set; }
        public string MdrcNxtq { get; set; }

        public double KndctlCtlqdbsVal { get; set; }
        public double KndctlCttcmqhVal { get; set; }
        public double KndctlGnvttdtVal { get; set; }
        public double KndctlGncxVal { get; set; }
        public double KndctlVal { get; set; }
        public String KndctlPhanloai { get; set; }
        public string KndctlNxtq { get; set; }

        public double DltdDltdbtVal { get; set; }
        public double DltdDltdbnVal { get; set; }
        public double DltdVal { get; set; }
        public String DltdPhanloai { get; set; }
        public string DltdNxtq { get; set; }

        public string Nxtq { get; set; }
        public string DxvmtNxtq { get; set; }
        public string KhvhdNxtq { get; set; }
        public bool IsClose { get; set; }

        public virtual SurveyImportEntity SurveyImport { get; set; }

        protected override void ModelConfigure(EntityTypeBuilder<SurveyImportResultEntity> builder)
        {
            base.ModelConfigure(builder);
        }
    }
}
