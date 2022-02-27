using System.Linq;
using AutoMapper;
using CpTech.Core.Common.Helpers;
using CpTech.Core.Middle.Mappers;
using DiaB.Common.Extensions;
using DiaB.Data.Database.Entities.Import;
using DiaB.Middle.Dtos.SurveyImportDtos;

namespace DiaB.Middle.Mappers
{
    public sealed class SurveyImportMapper : CoreMapper<SurveyImportEntity>
    {
        public SurveyImportMapper()
        {
            this.CreateMapFromEntity<SurveyImportDtos.AppItem>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserCode, opt => opt.MapFrom(src => src.AccountImport.UserCode))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.AccountImport.UserName))
                .ForMember(dest => dest.SurveyType, opt => opt.MapFrom(src => src.SurveyType))
                .ForMember(dest => dest.SurveyCode, opt => opt.MapFrom(src => src.SurveyCode))
                .ForMember(dest => dest.ImportDay, opt => opt.MapFrom(src => src.ImportDay))
                .ForMember(dest => dest.SurveyStatus, opt => opt.MapFrom(src => src.SurveyImportResult != null ? "1" : "0"))
                .ForMember(dest => dest.SurveyResultId, opt => opt.MapFrom(src => src.SurveyResultId));

            this.CreateMap<SurveyImportDtos.AppFilter, SurveyImportDtos.Filter>(MemberList.Source)
                .ForMember(dest => dest.OrderBy, opt => opt.MapFrom(src => src.SortBy));
        }
    }
}
