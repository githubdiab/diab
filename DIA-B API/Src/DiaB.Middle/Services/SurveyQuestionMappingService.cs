

using CpTech.Core.Common.Dtos;
using DiaB.Data.Database.Entities.Import;
using DiaB.Data.Repositories.Interfaces;
using DiaB.Middle.Abstracts;
using DiaB.Middle.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaB.Middle.Services
{
    public class SurveyQuestionMappingService : BaseService<SurveyQuestionMappingEntity>, ISurveyQuestionMappingService
    {

        public SurveyQuestionMappingService(IAppRepo<SurveyQuestionMappingEntity> repo)
            : base(repo)
        {
        }

        public async Task<IList<SurveyQuestionMappingEntity>> GetQuestionByPrefix(string questionIdPrefix, SurveyImportEntity surveyImportEntity, ActionContext context = null)
        {
           var result = await this.GetListEntity(q => q.Where(r => !r.IsDeleted && r.SurveyCode == surveyImportEntity.SurveyCode && r.QuestionCode.Contains(questionIdPrefix)), context);

            return result.ToList();
        }
    }
}
