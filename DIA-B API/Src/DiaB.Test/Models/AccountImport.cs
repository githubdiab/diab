using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaB.Test.Models
{
    public class AccountImport
    {
        //   public int user_id { get; set; }
       public int  id { get; set; }
       public int is_deleted { get; set; }
        public string code { get; set; }

        public DateTime create_datetime { get; set; }
        public DateTime update_datetime { get; set; }

        public string creator_id { get; set; }
        public string updater_id { get; set; }

        public int user_code {get;set;}
        public string user_name { get; set; }
        public string user_gender { get; set; }
        public int user_yearofbirth { get; set; }
        public string user_career { get; set; } 
        public string user_phone { get; set; }  
        public string user_hoobit { get; set; } 
       public string  user_address { get; set; }   
       public string  user_province { get; set; }
       public string story_success { get; set; }   
        public string user_typeofsick { get; set; }
       public int  year_foundout { get; set; }

    }
}
