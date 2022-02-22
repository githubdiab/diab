using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CpTech.Core.Data.Entities;
using DiaB.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaB.Data.Database.Entities.Import
{
    public class SurveyImportEntity : ModelEntity<SurveyImportEntity>
    {

        [Required]
        public Guid UserId { get; set; }

        public string CourseGoal { get; set; }

        public string CourseAction { get; set; }

        public string CourseFinalRate { get; set; }

        public string ParticipationPackage { get; set; }

        public string SurveyTypeCode { get; set; }

        public string SurveyType { get; set; }

        public DateTime? SurveyDay { get; set; }

        public DateTime? ImportDay { get; set; }

        public string SurveyCode { get; set; }

        public string SurveyName { get; set; }

        public Guid? SurveyResultId { get; set; }

        public virtual AccountImportEntity AccountImport { get; set; }

        public virtual SurveyImportResultEntity SurveyImportResult { get; set; }

        public virtual IList<SurveyImportDetailEntity> SurveyImportDetails { get; set; }

        protected override void ModelConfigure(EntityTypeBuilder<SurveyImportEntity> builder)
        {
            base.ModelConfigure(builder);

            builder.HasOne(x => x.AccountImport)
                .WithMany(x => x.SurveyImports)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.SurveyImportResult)
                .WithOne(x => x.SurveyImport)
                .HasForeignKey<SurveyImportEntity>(x => x.SurveyResultId);

        }
    }
}
