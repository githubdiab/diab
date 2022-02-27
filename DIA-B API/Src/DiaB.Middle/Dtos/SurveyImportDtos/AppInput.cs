using System;
using System.Collections.Generic;

namespace DiaB.Middle.Dtos.SurveyImportDtos
{
    public partial class SurveyImportDtos
    { 
    public class AppInput
        {
            public IList<Guid> Ids { get; set; }
        }
    }
}
