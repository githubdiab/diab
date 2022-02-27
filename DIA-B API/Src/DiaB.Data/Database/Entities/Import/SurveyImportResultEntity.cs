using System;
using System.ComponentModel.DataAnnotations;
using CpTech.Core.Data.Entities;
using DiaB.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaB.Data.Database.Entities.Import
{
    public class SurveyImportResultEntity : ModelEntity<SurveyImportResultEntity>
    {
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

        public virtual SurveyImportEntity SurveyImport { get; set; }

        protected override void ModelConfigure(EntityTypeBuilder<SurveyImportResultEntity> builder)
        {
            base.ModelConfigure(builder);
        }
    }
}
