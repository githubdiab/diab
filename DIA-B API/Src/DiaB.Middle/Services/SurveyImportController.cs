
using DiaB.Middle.Dtos.AccountImportDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace DiaB.Middle.Services
{
    [Route("api/[controller]")]
    public class SurveyImportController : Controller
    {


        private readonly IConfiguration _configuration;


      


        [HttpGet("id")]

        public JsonResult GetId()
        {


            /* string query = @"SELECT survey_imports.id 
                                    FROM survey_imports
                                    where id not in (select survey_id from survey_import_details) order by user_id ASC ";*/
            string query = @"SELECT id from survey_imports order by user_id ASC ";

            DataTable table = new DataTable();
            //  string sqlDataSource = _configuration.GetConnectionString("sqlconn");
            /*  MySqlConnection myconn = new MySqlConnection("server=localhost;userid=root;password=Root12345;database=diab_stg;Port=3306"*/


            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection("server=127.0.0.1;userid=root;password=Root12345;database=diab_stg;Port=3306")
)
            {
                myconn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, myconn))
                {
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();
                }
            }
            return new JsonResult(table);
        }



        [HttpGet("survey")]
        public JsonResult Get()
        {


            string query = @"select * from survey_imports ";

            DataTable table = new DataTable();
            //  string sqlDataSource = _configuration.GetConnectionString("sqlconn");
            /*  MySqlConnection myconn = new MySqlConnection("server=localhost;userid=root;password=Root12345;database=diab_stg;Port=3306"*/


            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection("server=127.0.0.1;userid=root;password=Root12345;database=diab_stg;Port=3306")
)
            {
                myconn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, myconn))
                {
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();
                }
            }
            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(SurveyImport sur)
        {


            string query = @"insert into survey_imports(id,is_deleted,user_id,course_goal,course_action,course_final_rate,participation_package,survey_type_code,survey_type,survey_code,survey_name,survey_day,import_day,creator_id,updater_id)
               values(@id,@is_deleted,@user_id,@course_goal,@course_action,@course_final_rate,@participation_package,@survey_type_code,@survey_type,@survey_code,@survey_name,@survey_day,@import_day,@creator_id,@updater_id)";

            //   string query2 = @"select id from";
            DataTable table = new DataTable();
            //  string sqlDataSource = _configuration.GetConnectionString("sqlconn");
            /*  MySqlConnection myconn = new MySqlConnection("server=localhost;userid=root;password=Root12345;database=diab_stg;Port=3306"*/


            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection("server=127.0.0.1;userid=root;password=Root12345;database=diab_stg;Port=3306")
)
            {
                myconn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, myconn))
                {
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@is_deleted", 0);
                    cmd.Parameters.AddWithValue("@user_id", sur.user_id);
                    cmd.Parameters.AddWithValue("@course_goal", sur.course_goal);
                    cmd.Parameters.AddWithValue("@course_action", sur.course_action);
                    cmd.Parameters.AddWithValue("@course_final_rate", sur.course_final_rate);
                    cmd.Parameters.AddWithValue("@participation_package", sur.participation_package);
                    cmd.Parameters.AddWithValue("@survey_type_code", sur.survey_type_code);
                    cmd.Parameters.AddWithValue("@survey_type", sur.survey_type);
                    cmd.Parameters.AddWithValue("@survey_code", sur.survey_code);
                    cmd.Parameters.AddWithValue("@survey_name", sur.survey_name);
                    cmd.Parameters.AddWithValue("@survey_day", sur.survey_day);
                    cmd.Parameters.AddWithValue("@import_day", sur.import_day);
                    cmd.Parameters.AddWithValue("@creator_id", "cb356d0b-b62b-4418-a295-b2b71393fba6");
                    cmd.Parameters.AddWithValue("@updater_id", "cb356d0b-b62b-4418-a295-b2b71393fba6");


                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();
                }
            }
            return new JsonResult("Adding Success");
        }

        /*  [HttpPut]
          public JsonResult Put(AccountImport acc)
          {


              string query = @"update Department set DepartmentName=@DepartmentName where DepartmentId=@DepartmentId ";

              DataTable table = new DataTable();
              //  string sqlDataSource = _configuration.GetConnectionString("sqlconn");
              *//*  MySqlConnection myconn = new MySqlConnection("server=localhost;userid=root;password=Root12345;database=diab_stg;Port=3306"*//*


              MySqlDataReader myReader;
              using (MySqlConnection myconn = new MySqlConnection("server=127.0.0.1;userid=root;password=Root12345;database=diab_stg;Port=3306")
  )
              {
                  myconn.Open();
                  using (MySqlCommand cmd = new MySqlCommand(query, myconn))
                  {
                      cmd.Parameters.AddWithValue("@DepartmentId", acc.DepartmentId);
                      cmd.Parameters.AddWithValue("@DepartmentName", acc.DepartmentName);
                      myReader = cmd.ExecuteReader();
                      table.Load(myReader);
                      myReader.Close();
                      myconn.Close();
                  }
              }
              return new JsonResult("Update Success");
          }*/

        /*   [HttpDelete]
           public JsonResult Delete(Department dep)
           {


               string query = @"Delete from Department where DepartmentId=@DepartmentId ";

               DataTable table = new DataTable();
               //  string sqlDataSource = _configuration.GetConnectionString("sqlconn");
               *//*  MySqlConnection myconn = new MySqlConnection("server=localhost;userid=root;password=Root12345;database=diab_stg;Port=3306"*//*


               MySqlDataReader myReader;
               using (MySqlConnection myconn = new MySqlConnection("server=127.0.0.1;userid=root;password=Root12345;database=diab_stg;Port=3306")
   )
               {
                   myconn.Open();
                   using (MySqlCommand cmd = new MySqlCommand(query, myconn))
                   {
                       cmd.Parameters.AddWithValue("@DepartmentId", dep.DepartmentId);
                       myReader = cmd.ExecuteReader();
                       table.Load(myReader);
                       myReader.Close();
                       myconn.Close();
                   }
               }
               return new JsonResult("Delete Successfully");
           }*/

    }
}
