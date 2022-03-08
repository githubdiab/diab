using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CpTech.Core.Data.Entities;
using DiaB.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaB.Data.Database.Entities.Import
{
    public class SurveyQuestionMappingEntity : ModelEntity<SurveyQuestionMappingEntity>
    {
        public string QuestionId { get; set; }
        public string QuestionCode { get; set; }
        public string QuestionAnswer { get; set; }
        protected override void ModelConfigure(EntityTypeBuilder<SurveyQuestionMappingEntity> builder)
        {
            base.ModelConfigure(builder);
        }
    }
}
