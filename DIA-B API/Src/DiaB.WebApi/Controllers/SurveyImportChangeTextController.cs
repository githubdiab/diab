
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
    public class SurveyImportChangeTextController : AppController
    {

        private readonly IConfiguration _configuration;
        public SurveyImportChangeTextController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPut("change_text")]
        public JsonResult Put()
        {
          //  SurveyImportDetails sid, SurveyImportChangeText ct

            string query = @"update survey_import_details , survey_import_change_numbers set survey_import_details.question_answer = survey_import_change_numbers.convert_number_range where survey_import_details.category_code=survey_import_change_numbers.category_code and survey_import_change_numbers.description_answer = survey_import_details.question_answer";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection(sqlDataSource))
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

        [HttpPut("change_numbers")]
        public JsonResult Put_number()
        {
            //  SurveyImportDetails sid, SurveyImportChangeText ct

            string query = @"update survey_import_details , survey_import_change_numbers set survey_import_details.question_answer = survey_import_change_numbers.description_answer where survey_import_details.category_code=survey_import_change_numbers.category_code and  survey_import_details.question_answer = survey_import_change_numbers.convert_number_range ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection myconn = new MySqlConnection(sqlDataSource))
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
    }
}
