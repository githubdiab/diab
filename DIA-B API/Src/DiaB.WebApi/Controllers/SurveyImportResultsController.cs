
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


namespace DiaB.WebApi.Controllers
{
    [ApiExplorerSettings(GroupName = "app")]
  
    public class SurveyImportResultsController : AppController
    {

        //     [SwaggerResponse(200, null, typeof(DataResult<IPagingData<AccountImportDtos.AppItem>>))]
        // [Route("App/SurveyImportResults")]
        private readonly IConfiguration _configuration;
        public SurveyImportResultsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
         
        [HttpGet("user_import")]
        public JsonResult Get_userimport(int size,string orderby ,int offset)
        {


            string query = @"select account_imports.user_name, account_imports.user_phone,account_imports.user_yearofbirth,account_imports.user_typeofsick,survey_imports.import_day,survey_imports.survey_day,survey_imports.participation_package,survey_imports.survey_type,survey_imports.survey_name,survey_imports.survey_code ,account_imports.user_code,account_imports.id 
                             from survey_imports,account_imports
                            where account_imports.id = survey_imports.user_id
                           group by survey_imports.id
                          order by survey_imports.update_datetime " + @orderby+ " LIMIT @offset,@size ";
          //  




            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection(sqlDataSource)
)
            {
                myconn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, myconn))
                {
                    cmd.Parameters.AddWithValue("@orderby", orderby);
                    cmd.Parameters.AddWithValue("@size", size);
                    cmd.Parameters.AddWithValue("@offset", offset);
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();
                }

            }

            return new JsonResult(table);
        }


        [HttpGet("details")]
        public JsonResult Get_all(string user_code)
        {


            string query = @"select * from account_imports , survey_imports where account_imports.id = survey_imports.user_id and user_code=@user_code ";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection(sqlDataSource)
)
            {
                myconn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, myconn))
                {
                    cmd.Parameters.AddWithValue("@user_code", user_code);
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();
                }

            }



            return new JsonResult(table);
        }
        [HttpGet("GetTotal")]
        public JsonResult GetTotal()
        {


            string query = @"select count(*) as CountTotal from survey_imports , account_imports where account_imports.id = survey_imports.user_id  ";


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection(sqlDataSource)
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

        [HttpGet]
        public JsonResult Get()
        {


            string query = @"select * from survey_import_results ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection(sqlDataSource)
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
        public JsonResult Post(SurveyImportResults sir)
        {


            string query = @"insert into survey_import_results(id,is_deleted)
               values(@id,@is_deleted)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection(sqlDataSource)
)
            {
                myconn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, myconn))
                {
                    cmd.Parameters.AddWithValue("@id", sir.id);
                    cmd.Parameters.AddWithValue("@is_deleted", sir.is_deleted);




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

        [HttpGet("user_name")]
        public JsonResult Get_userName(string survey_result_id)
        {
            //   SELECT user_name FROM account_imports where id = (select survey_imports.user_id from survey_imports where survey_imports.survey_result_id = '9ecd9e5d-d21e-42f1-95c4-08da4868fb0b') ;


            string query = @"SELECT user_name FROM account_imports where id = (select survey_imports.user_id from survey_imports where survey_imports.survey_result_id =@survey_result_id) ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection(sqlDataSource)
)
            {
                myconn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, myconn))
                {
                    cmd.Parameters.AddWithValue("@survey_result_id", survey_result_id);
                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();
                }
            }
            return new JsonResult(table);
        }

    }
}
