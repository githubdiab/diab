using System.Linq;
using AutoMapper;
using CpTech.Core.Common.Helpers;
using CpTech.Core.Middle.Mappers;
using DiaB.Data.Database.Entities.Import;
using DiaB.Middle.Dtos.SurveyImportResultDtos;

namespace DiaB.Middle.Mappers
{
    public sealed class SurveyImportResultMapper : CoreMapper<SurveyImportResultEntity>
    {
        public SurveyImportResultMapper()
        {
            this.CreateMapFromEntity<SurveyImportResultDtos.AppItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.SurveyImport.AccountImport.UserName))
                .ForMember(dest => dest.UserGender, opt => opt.MapFrom(src => src.SurveyImport.AccountImport.UserGender))
                .ForMember(dest => dest.UserYearofbirth, opt => opt.MapFrom(src => src.SurveyImport.AccountImport.UserYearofbirth))
                .ForMember(dest => dest.UserCareer, opt => opt.MapFrom(src => src.SurveyImport.AccountImport.UserCareer))
                .ForMember(dest => dest.UserHoobit, opt => opt.MapFrom(src => src.SurveyImport.AccountImport.UserHoobit))
                .ForMember(dest => dest.UserProvince, opt => opt.MapFrom(src => src.SurveyImport.AccountImport.UserProvince))
                .ForMember(dest => dest.StorySuccess, opt => opt.MapFrom(src => src.SurveyImport.AccountImport.StorySuccess))
                .ForMember(dest => dest.UserTypeofsick, opt => opt.MapFrom(src => src.SurveyImport.AccountImport.UserTypeofsick))
                .ForMember(dest => dest.YearFoundout, opt => opt.MapFrom(src => src.SurveyImport.AccountImport.YearFoundout))
                .ForMember(dest => dest.Avatar, opt => opt.Ignore())

                .ForMember(dest => dest.Hba1cVal, opt => opt.MapFrom(src => src.Hba1cVal))
                .ForMember(dest => dest.BmiVal, opt => opt.MapFrom(src => src.BmiVal))

                .ForMember(dest => dest.KtBlVal, opt => opt.MapFrom(src => src.KtBlVal))
                .ForMember(dest => dest.KtTdcsVal, opt => opt.MapFrom(src => src.KtTdcsVal))
                .ForMember(dest => dest.KtDdVal, opt => opt.MapFrom(src => src.KtDdVal))
                .ForMember(dest => dest.KtVdVal, opt => opt.MapFrom(src => src.KtVdVal))
                .ForMember(dest => dest.KtThVal, opt => opt.MapFrom(src => src.KtThVal))
                .ForMember(dest => dest.KtTlhvVal, opt => opt.MapFrom(src => src.KtTlhvVal))
                .ForMember(dest => dest.KtVal, opt => opt.MapFrom(src => src.KtVal))
                .ForMember(dest => dest.KtNxtq, opt => opt.MapFrom(src => src.KtNxtq))

                .ForMember(dest => dest.KntcsHtVal, opt => opt.MapFrom(src => src.KntcsHtVal))
                .ForMember(dest => dest.KntcsCsbcVal, opt => opt.MapFrom(src => src.KntcsCsbcVal))
                .ForMember(dest => dest.KntcsTddhVal, opt => opt.MapFrom(src => src.KntcsTddhVal))
                .ForMember(dest => dest.KntcsCdvdVal, opt => opt.MapFrom(src => src.KntcsCdvdVal))
                .ForMember(dest => dest.KntcsCdauVal, opt => opt.MapFrom(src => src.KntcsCdauVal))
                .ForMember(dest => dest.KntcsVal, opt => opt.MapFrom(src => src.KntcsVal))
                .ForMember(dest => dest.KntcsNxtq, opt => opt.MapFrom(src => src.KntcsNxtq))

                .ForMember(dest => dest.MdrcDtVal, opt => opt.MapFrom(src => src.MdrcDtVal))
                .ForMember(dest => dest.MdrcDhVal, opt => opt.MapFrom(src => src.MdrcDhVal))
                .ForMember(dest => dest.MdrcCdvdVal, opt => opt.MapFrom(src => src.MdrcCdvdVal))
                .ForMember(dest => dest.MdrcCdauVal, opt => opt.MapFrom(src => src.MdrcCdauVal))
                .ForMember(dest => dest.MdrcVal, opt => opt.MapFrom(src => src.MdrcVal))
                .ForMember(dest => dest.MdrcNxtq, opt => opt.MapFrom(src => src.MdrcNxtq))


                .ForMember(dest => dest.KndctlCtlqdbsVal, opt => opt.MapFrom(src => src.KndctlCtlqdbsVal))
                .ForMember(dest => dest.KndctlCttcmqhVal, opt => opt.MapFrom(src => src.KndctlCttcmqhVal))
                .ForMember(dest => dest.KndctlGnvttdtVal, opt => opt.MapFrom(src => src.KndctlGnvttdtVal))
                .ForMember(dest => dest.KndctlGncxVal, opt => opt.MapFrom(src => src.KndctlGncxVal))
                .ForMember(dest => dest.KndctlVal, opt => opt.MapFrom(src => src.KndctlVal))
                .ForMember(dest => dest.KndctlNxtq, opt => opt.MapFrom(src => src.KndctlNxtq))

                .ForMember(dest => dest.DltdDltdbtVal, opt => opt.MapFrom(src => src.DltdDltdbtVal))
                .ForMember(dest => dest.DltdDltdbnVal, opt => opt.MapFrom(src => src.DltdDltdbnVal))
                .ForMember(dest => dest.DltdVal, opt => opt.MapFrom(src => src.DltdVal))
                .ForMember(dest => dest.DltdNxtq, opt => opt.MapFrom(src => src.DltdNxtq))

                .ForMember(dest => dest.Nxtq, opt => opt.MapFrom(src => src.Nxtq))
                .ForMember(dest => dest.DxvmtNxtq, opt => opt.MapFrom(src => src.DxvmtNxtq))
                .ForMember(dest => dest.KhvhdNxtq, opt => opt.MapFrom(src => src.KhvhdNxtq))

                .ForMember(dest => dest.IsClose, opt => opt.MapFrom(src => src.IsClose))

                .ForMember(dest => dest.FileReport, opt => opt.Ignore())
                .ForMember(dest => dest.FileReportTitle, opt => opt.Ignore());
        }
    }
}
