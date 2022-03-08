using System;
using System.ComponentModel.DataAnnotations;
using CpTech.Core.Data.Entities;
using DiaB.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaB.Data.Database.Entities.Import
{
    public class SurveyRangeValueEntity : ModelEntity<SurveyRangeValueEntity>
    {
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public int FromValue { get; set; }
        public int ToValue { get; set; }
        public string Description { get; set; }
        public string MessageToCustomer { get; set; }

        protected override void ModelConfigure(EntityTypeBuilder<SurveyRangeValueEntity> builder)
        {
            base.ModelConfigure(builder);
        }
    }
}
