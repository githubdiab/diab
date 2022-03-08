﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace DiaB.Test.Models
{
    public class SurveyImportResults
    {
       public string id { get; set; }
        public string code { get; set; }
        public int is_deleted { get; set; }
        public DateTime create_datetime { get; set; }
        public DateTime update_datetime { get; set; }

       
        public string SortBy { get; set; }

        public int Page { get; set; } = 1;

        public int Size { get; set; } = 1000;
    }
}
