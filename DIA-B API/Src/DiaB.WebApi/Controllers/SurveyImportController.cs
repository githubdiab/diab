using DiaB.Middle.Dtos.AccountImportDtos;
using DiaB.WebApi.Controllers.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DiaB.Test.Controllers
{
    [ApiExplorerSettings(GroupName = "app")]
    [Route("App/AccountImport")]
    public class SurveyImportController : AppController
    {
        
       
       private readonly IConfiguration _configuration;
      

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

        [HttpPost("survey")]
        public JsonResult Post(SurveyImport sur)
        {


            string query = @"insert into survey_imports(id,is_deleted,user_id,course_goal,course_action,course_final_rate,participation_package,survey_type_code,survey_type,survey_code,survey_name,survey_day,import_day)
               values(@id,@is_deleted,@user_id,@course_goal,@course_action,@course_final_rate,@participation_package,@survey_type_code,@survey_type,@survey_code,@survey_name,@survey_day,@import_day)";

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
                    cmd.Parameters.AddWithValue("@id", sur.id);
                    cmd.Parameters.AddWithValue("@is_deleted", sur.is_deleted);
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

