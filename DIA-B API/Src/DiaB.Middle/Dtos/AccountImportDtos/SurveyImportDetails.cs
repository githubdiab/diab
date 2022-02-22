using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaB.Middle.Dtos.AccountImportDtos
{
    public class SurveyImportDetails
    {
        public string id { get; set; }
        public string code { get; set; }
        public int is_deleted { get; set; }
        public DateTime create_date { get; set; }
        public DateTime update_datetime { get; set; }
        public string survey_id { get; set; }
        public string category_code { get; set; }
        public string category { get; set; }
        public string sub_category_code { get; set; }
        public string sub_category { get; set; }
        public string question_code { get; set; }
        public string question_number { get; set; }
        public string question_answer { get; set; }
        public int question_result { get; set; }
    }
}
