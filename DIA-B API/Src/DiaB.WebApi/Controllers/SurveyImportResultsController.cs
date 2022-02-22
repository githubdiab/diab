﻿using DiaB.Middle.Dtos.AccountImportDtos;
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

    public class SurveyImportResultsController : AppController
    {
        private readonly IConfiguration _configuration;
       

        [HttpGet]
        public JsonResult Get()
        {


            string query = @"select * from survey_import_results ";

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
        public JsonResult Post(SurveyImportResults sir)
        {


            string query = @"insert into survey_import_results(id,is_deleted)
               values(@id,@is_deleted)";

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

    }
}
