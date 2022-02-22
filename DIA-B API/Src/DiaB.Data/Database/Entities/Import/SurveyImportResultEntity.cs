using System;
using System.ComponentModel.DataAnnotations;
using CpTech.Core.Data.Entities;
using DiaB.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaB.Data.Database.Entities.Import
{
    public class SurveyImportResultEntity : ModelEntity<SurveyImportResultEntity>
    {
        public virtual SurveyImportEntity SurveyImport { get; set; }

        protected override void ModelConfigure(EntityTypeBuilder<SurveyImportResultEntity> builder)
        {
            base.ModelConfigure(builder);
        }
    }
}
