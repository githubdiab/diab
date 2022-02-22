using DiaB.Test.Models;
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
    [Route("api/[controller]")]

    public class SurveyImportDetailsController : Controller
    {
        private readonly IConfiguration _configuration;
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public JsonResult Get()
        {


            string query = @"select * from survey_import_details ";

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
        public JsonResult Post(SurveyImportDetails sid)
        {


            string query = @"insert into survey_import_details(id,is_deleted,survey_id,category_code,category,sub_category_code,sub_category,question_code,question_number,question_answer,question_result)
               values(@id,@is_deleted,@survey_id,@category_code,@category,@sub_category_code,@sub_category,@question_code,@question_number,@question_answer,@question_result)";

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
                    cmd.Parameters.AddWithValue("@id", sid.id);
                    cmd.Parameters.AddWithValue("@is_deleted", sid.is_deleted);
                    cmd.Parameters.AddWithValue("@survey_id", sid.survey_id);
                    cmd.Parameters.AddWithValue("@category_code", sid.category_code);
                    cmd.Parameters.AddWithValue("@category", sid.category);
                    cmd.Parameters.AddWithValue("@sub_category_code", sid.sub_category_code);
                    cmd.Parameters.AddWithValue("@sub_category", sid.sub_category);
                    cmd.Parameters.AddWithValue("@question_code", sid.question_code);
                    cmd.Parameters.AddWithValue("@question_number", sid.question_number);
                    cmd.Parameters.AddWithValue("@question_answer", sid.question_answer);
                    cmd.Parameters.AddWithValue("@question_result", sid.question_result);
                 


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
