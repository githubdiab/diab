using System;
using System.Collections.Generic;
using System.ComponentModel;
using CpTech.Core.Middle.Dtos;
using Microsoft.AspNetCore.Http;


namespace DiaB.Middle.Dtos.FileUploadDtos
    {
        public partial class FileUploadDtos
        {
            public partial class StaffInfo : BaseItemDto
            {
            // public string Count { get; set; }
            public string user_code { get; set; }
            public string user_name { get; set; }
            public string user_gender { get; set; }

            public string user_yearofbirth { get; set; }
            public string survey_type { get; set; }
            public string survey_name { get; set; }
            public string survey_code { get; set; }
            public string code { get; set; }
            public string user_phone { get; set; }
            public string survey_day { get; set; }
            public string user_province { get; set; }

            public int stt { get; set; }
            public string user_career { get; set; }


            public string user_hoobit { get; set; }
            public string user_address { get; set; }
            public string story_success { get; set; }
            public string course_goal { get; set; }
            public string course_action { get; set; }
            public string course_final_rate { get; set; }

            public string user_typeofsick { get; set; }
            public string year_foundout { get; set; }
            public string participation_package { get; set; }
            public string survey_type_code { get; set; }
            public string import_day { get; set; }
            public string category { get; set; }

            public string category_code { get; set; }
            public string sub_category_code { get; set; }

            public string sub_category { get; set; }
            public string question_code { get; set; }
            public string question_number { get; set; }
            public string question_result { get; set; }
            public string question_answer { get; set; }













            public List<StaffInfo> StaffList { get; set; }
                public StaffInfo()
                {
                    StaffList = new List<StaffInfo>();
                }
            }
        }
    }


