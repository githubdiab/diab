using CpTech.Core.Middle.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaB.Middle.Dtos.AccountImportDtos
{
   
        public partial class SurveyImport
        {
            public int id { get; set; }
            public string code { get; set; }
            public int is_deleted { get; set; }
            public string user_id { get; set; }

            public string course_goal { get; set; }

            public string course_action { get; set; }
            public string course_final_rate { get; set; }
            public string participation_package { get; set; }
            public string survey_type_code { get; set; }
            public string survey_type { get; set; }
            public string survey_code { get; set; }
            public string survey_name { get; set; }

            public string survey_day { get; set; }
            public string import_day { get; set; }

            public DateTime create_datetime { get; set; }
            public DateTime update_datetime { get; set; }

            public string creator_id { get; set; }
            public string updater_id { get; set; }
        
    }
}
