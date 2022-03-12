using CpTech.Core.Middle.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaB.Middle.Dtos.AccountImportDtos
{
    public class SurveyImportResults
    {
        public string id { get; set; }
        public string code { get; set; }
        public int is_deleted { get; set; }
        public DateTime create_datetime { get; set; }
        public DateTime update_datetime { get; set; }
    }
}
