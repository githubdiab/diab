using System;
using System.ComponentModel.DataAnnotations;
using CpTech.Core.Data.Entities;
using DiaB.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaB.Data.Database.Entities.Import
{
    public class SurveyImportDetailEntity : ModelEntity<SurveyImportDetailEntity>
    {

        [Required]
        public Guid SurveyId { get; set; }

        public string CategoryCode { get; set; }

        public string Category { get; set; }

        public string SubCategoryCode { get; set; }

        public string SubCategory { get; set; }

        public string QuestionCode { get; set; }

        public string QuestionNumber { get; set; }

        public string QuestionAnswer { get; set; }

        public string QuestionResult { get; set; }

        public virtual SurveyImportEntity SurveyImport { get; set; }

        protected override void ModelConfigure(EntityTypeBuilder<SurveyImportDetailEntity> builder)
        {
            base.ModelConfigure(builder);

            builder.HasOne(x => x.SurveyImport)
            .WithMany(x => x.SurveyImportDetails)
            .HasForeignKey(x => x.SurveyId)
            .IsRequired();
        }
    }
}
