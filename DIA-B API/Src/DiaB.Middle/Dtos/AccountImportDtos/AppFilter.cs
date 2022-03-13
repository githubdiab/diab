using System;
using System.ComponentModel;
using DiaB.Common.Enums;

namespace DiaB.Middle.Dtos.AccountImportDtos
{
    public partial class AccountImportDtos
    {
        public partial class AppFilter
        {
            public int id { get; set; }

            public DateTime import_day { get; set; }

            public string participation_package { get; set; }

            public string survey_code { get; set; }

            public string survey_name { get; set; }

            public string survey_type { get; set; }

            public int user_code { get; set; }

            public string user_name { get; set; }

            public string user_typeofsick { get; set; }

            [DisplayName("sắp xếp theo")]
            public string SortBy { get; set; }

            public int Page { get; set; } = 1;

            public int Size { get; set; } = 1000;
        }
    }
}
