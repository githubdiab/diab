using CpTech.Core.Common.Dtos;
using CpTech.Core.Middle.Services;
using DiaB.Data.Database.Entities.Import;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiaB.Middle.Services.Interfaces
{
    public interface ISurveyQuestionMappingService : ICoreService
    {
        Task<IList<SurveyQuestionMappingEntity>> GetQuestionByPrefix(string questionIdPrefix, SurveyImportEntity surveyImportEntity, ActionContext context = null);
    }
}
