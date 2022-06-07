using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CpTech.Core.Data.Entities;
using DiaB.Common.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiaB.Data.Database.Entities.Import
{
    public class AccountImportEntity : ModelEntity<AccountImportEntity>
    {
        [Required]
        public string UserCode { get; set; }

        public string UserName { get; set; }

        public string UserGender { get; set; }

        public int UserYearofbirth { get; set; }

        public string UserCareer { get; set; }

        public string UserPhone { get; set; }

        public string UserHoobit { get; set; }

        public string UserAddress { get; set; }

        public string UserProvince { get; set; }

        public string StorySuccess { get; set; }

        public string UserTypeofsick { get; set; }

        public int YearFoundout { get; set; }

        public Guid? CoverId { get; set; }

        public virtual IList<SurveyImportEntity> SurveyImports { get; set; }

        protected override void ModelConfigure(EntityTypeBuilder<AccountImportEntity> builder)
        {
            base.ModelConfigure(builder);

            builder.HasIndex(x => x.UserCode).IsUnique();
        }
    }
}
