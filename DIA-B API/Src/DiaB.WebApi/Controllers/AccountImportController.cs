
using DiaB.Middle.Dtos.AccountImportDtos;
using DiaB.WebApi.Controllers.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Data;


namespace DiaB.WebApi.Controllers
{
   
    [ApiExplorerSettings(GroupName = "app")]  
    public class AccountImportController : AppController
    {
        private readonly IConfiguration _configuration;
        public AccountImportController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("id")]
        public JsonResult Get()
        {


            string query = @"SELECT account_imports.id 
                                 FROM account_imports
                                 where id not in (select user_id from survey_imports order by user_id ASC) ";

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


        [HttpGet("account")]
        public JsonResult GetAll()
        {


            string query = @"select * from account_imports ";

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




        [HttpGet("{user_code}")]
        public JsonResult GetUserCode()
        {

            string query = @"select user_code from account_imports ";


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

      
        public JsonResult Post(AccountImport acc)
        {



            string query = @"insert into account_imports(id,is_deleted,user_code,user_name,user_gender,user_yearofbirth,user_career,user_phone,user_hoobit,user_address,user_province,story_success,user_typeofsick,year_foundout,creator_id,updater_id)
               values(@id,@is_deleted,@user_code,@user_name,@user_gender,@user_yearofbirth,@user_career,@user_phone,@user_hoobit,@user_address,@user_province,@story_success,@user_typeofsick,@year_foundout,@creator_id,@updater_id)
                 ON DUPLICATE KEY UPDATE user_code=@user_code";

            DataTable table = new DataTable();


            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection(sqlDataSource)
)
            {
                myconn.Open();


                using (MySqlCommand cmd = new MySqlCommand(query, myconn))
                {
                    cmd.Parameters.AddWithValue("@id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@is_deleted", 0);
                    cmd.Parameters.AddWithValue("@user_code", acc.user_code);
                    cmd.Parameters.AddWithValue("@user_name", acc.user_name);
                    cmd.Parameters.AddWithValue("@user_gender", acc.user_gender);
                    cmd.Parameters.AddWithValue("@user_yearofbirth", acc.user_yearofbirth);
                    cmd.Parameters.AddWithValue("@user_address", acc.user_address);
                    cmd.Parameters.AddWithValue("@user_province", acc.user_province);
                    cmd.Parameters.AddWithValue("@story_success", acc.story_success);
                    cmd.Parameters.AddWithValue("@user_typeofsick", acc.user_typeofsick);
                    cmd.Parameters.AddWithValue("@year_foundout", acc.year_foundout);
                    cmd.Parameters.AddWithValue("@user_career", acc.user_career);
                    cmd.Parameters.AddWithValue("@user_phone", acc.user_phone);
                    cmd.Parameters.AddWithValue("@user_hoobit", acc.user_hoobit);
                    cmd.Parameters.AddWithValue("@creator_id", "cb356d0b-b62b-4418-a295-b2b71393fba6");
                    cmd.Parameters.AddWithValue("@updater_id", "cb356d0b-b62b-4418-a295-b2b71393fba6");

                    myReader = cmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myconn.Close();

                }
            }


            return new JsonResult("Adding Success");
            // Get();
        
        // Get();
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
