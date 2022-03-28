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
        public string SurveyType { get; set; }
        public string SurveyCode { get; set; }
        public string SurveyName { get; set; }
        public string CategoryCode { get; set; }
        public string Category { get; set; }
        public string SubCategoryCode { get; set; }
        public string QuestionCode { get; set; }
        public string QuestionNumber { get; set; }
        public string QuestionAnswer { get; set; }
        protected override void ModelConfigure(EntityTypeBuilder<SurveyQuestionMappingEntity> builder)
        {
            base.ModelConfigure(builder);
        }
    }
}
