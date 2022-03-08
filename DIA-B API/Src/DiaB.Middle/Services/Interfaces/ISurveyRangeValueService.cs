using CpTech.Core.Common.Dtos;
using CpTech.Core.Middle.Services;
using DiaB.Data.Database.Entities.Import;
using System.Threading.Tasks;

namespace DiaB.Middle.Services.Interfaces
{
    public interface ISurveyRangeValueService : ICoreService
    {
        Task<SurveyRangeValueEntity> GetRangeValueByCategory(string category, string subCategory, double value, ActionContext context = null);
    }
}
