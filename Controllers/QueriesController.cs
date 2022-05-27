using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using LabaOne.Models;
using System.Reflection;
using System.Data.SqlServerCe;

namespace LabaOne.Controllers
{
    public class QueriesController : Controller
    {
        private const string CONN_STR = "Server=DESKTOP-JNBPJFN;Database=DBFinal;Trusted_Connection=True;MultipleActiveResultSets=true";

        private const string S1_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S1.sql";
        private const string S2_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S2.sql";
        private const string S3_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S3.sql";
        private const string S4_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S4.sql";
        private const string S5_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S5.sql";
        private const string S6_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S6.sql";
        private const string A1_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\A1.sql";
        private const string A2_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\A2.sql";
        private const string A3_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\A3.sql";

        private const string ERR_COUNTRY = "Країни, що задовольняють дану умову, відсутні.";

        private readonly DBFinalContext _context;

        public QueriesController(DBFinalContext context) => _context = context;

        public IActionResult Index(int errorCode)
        {
            var variants = _context.Variants.Select(c => c.VariantName).Distinct().ToList();
            var viruses = _context.Viruses.Select(c => c.VirusName).Distinct().ToList();

            var empty = new SelectList(new List<string> { "--Пусто--" });
            ViewBag.VirusNames = viruses;
            ViewBag.VariantNames = variants;
            return View();
        }

        // Query 1

        List<string> VariantsNamesQ1 = new List<string>();
        private void ReadSingleRowQ1(IDataRecord dataRecord)
        {
            var rec0 = dataRecord[0];
            VariantsNamesQ1.Add((string)rec0);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQuery1(Query queryModel)
        {
            queryModel.QueryId = "S1";
            var cid = "N\'" + queryModel.CountryName + "\'));";

            string query = System.IO.File.ReadAllText(S1_PATH) + cid;


            using (SqlConnection newconnection =
                  new SqlConnection(CONN_STR))
            {
                SqlCommand command =
                    new SqlCommand(query, newconnection);
                newconnection.Open();

                SqlDataReader newreader = command.ExecuteReader();

                // Call Read before accessing data.
                while (newreader.Read())
                {
                    ReadSingleRowQ1((IDataRecord)newreader);
                }

                newreader.Close();
            }
            queryModel.VariantNames = VariantsNamesQ1;
            VariantsNamesQ1 = new List<string>();
            return RedirectToAction("Result", queryModel);
        }


        // Query 1

        List<string> VariantsNamesQ2 = new List<string>();
        private void ReadSingleRowQ2(IDataRecord dataRecord)
        {
            var rec0 = dataRecord[0];
            VariantsNamesQ2.Add((string)rec0);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQuery2(Query queryModel)
        {
            queryModel.QueryId = "S2";
            var cid = "N\'" + queryModel.VirusName + "\'));";

            string query = System.IO.File.ReadAllText(S2_PATH) + cid;


            using (SqlConnection newconnection =
                  new SqlConnection(CONN_STR))
            {
                SqlCommand command =
                    new SqlCommand(query, newconnection);
                newconnection.Open();

                SqlDataReader newreader = command.ExecuteReader();
                while (newreader.Read())
                {
                    ReadSingleRowQ2((IDataRecord)newreader);
                }

                newreader.Close();
            }
            queryModel.VariantNames = VariantsNamesQ2;
            VariantsNamesQ2 = new List<string>();
            return RedirectToAction("Result", queryModel);
        }



        // Query 3

        List<string> VariantsNamesQ3 = new List<string>();
        private void ReadSingleRowQ3(IDataRecord dataRecord)
        {
            var rec0 = dataRecord[0];
            VariantsNamesQ3.Add((string)rec0);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQuery3(Query queryModel)
        {
            queryModel.QueryId = "S3";
            var cid = "N\'" + queryModel.SymptomName + "\'));";

            string query = System.IO.File.ReadAllText(S3_PATH) + cid;


            using (SqlConnection newconnection =
                  new SqlConnection(CONN_STR))
            {
                SqlCommand command =
                    new SqlCommand(query, newconnection);
                newconnection.Open();

                SqlDataReader newreader = command.ExecuteReader();

                // Call Read before accessing data.
                while (newreader.Read())
                {
                    ReadSingleRowQ3((IDataRecord)newreader);
                }

                newreader.Close();
            }
            queryModel.VariantNames = VariantsNamesQ3;
            VariantsNamesQ3 = new List<string>();
            return RedirectToAction("Result", queryModel);
        }



        // Query 4
        private int ReadSingleRowQ4(IDataRecord dataRecord) => (int)dataRecord[0];

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQuery4(Query queryModel)
        {
            queryModel.QueryId = "S4";
            var cid = " N\'" + queryModel.VariantName + "\'));";
            string query = System.IO.File.ReadAllText(S4_PATH) + cid;

            using (SqlConnection newconnection =
                  new SqlConnection(CONN_STR))
            {
                SqlCommand command =
                    new SqlCommand(query, newconnection);
                newconnection.Open();

                SqlDataReader newreader = command.ExecuteReader();

                while (newreader.Read())
                {
                    queryModel.countryNamesCount = ReadSingleRowQ4((IDataRecord)newreader);
                    break;
                }
                newreader.Close();
            }
            return RedirectToAction("Result", queryModel);
        }


        // Query 5
        List<string> VariantsNamesQ5 = new List<string>();
        private void ReadSingleRowQ5(IDataRecord dataRecord)
        {
            var rec0 = dataRecord[0];
            VariantsNamesQ5.Add((string)rec0);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQuery5(Query queryModel)
        {
            queryModel.QueryId = "S5";
            var cid = "N\'" + queryModel.CountryName + "\'))";

            string query = System.IO.File.ReadAllText(S5_PATH) + cid;


            using (SqlConnection newconnection =
                  new SqlConnection(CONN_STR))
            {
                SqlCommand command =
                    new SqlCommand(query, newconnection);
                newconnection.Open();

                SqlDataReader newreader = command.ExecuteReader();

                // Call Read before accessing data.
                while (newreader.Read())
                {
                    ReadSingleRowQ5((IDataRecord)newreader);
                }
                queryModel.VariantNames = VariantsNamesQ5;
                VariantsNamesQ5 = new List<string>();
                newreader.Close();
            }
            return RedirectToAction("Result", queryModel);
        }

        // Query 5
        List<string> VirusNamesByGroup = new List<string>();
        private void ReadSingleRowQ6(IDataRecord dataRecord)
        {
            var rec0 = dataRecord[0];
            VirusNamesByGroup.Add((string)rec0);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SimpleQuery6(Query queryModel)
        {
            queryModel.QueryId = "S6";
            var cid = "N\'" + queryModel.GroupName + "\'))";

            string query = System.IO.File.ReadAllText(S6_PATH) + cid;


            using (SqlConnection newconnection =
                  new SqlConnection(CONN_STR))
            {
                SqlCommand command =
                    new SqlCommand(query, newconnection);
                newconnection.Open();

                SqlDataReader newreader = command.ExecuteReader();

                // Call Read before accessing data.
                while (newreader.Read())
                {
                    ReadSingleRowQ6((IDataRecord)newreader);
                }
                queryModel.VirusNamesByGroup = VirusNamesByGroup;
                VirusNamesByGroup = new List<string>();
                newreader.Close();
            }
            return RedirectToAction("Result", queryModel);
        }




        // Advanced query 1
        List<string> VariantsNamesA1 = new List<string>();
        private void ReadSingleRowA1(IDataRecord dataRecord)
        {
            var rec0 = dataRecord[0];
            VariantsNamesA1.Add((string)rec0);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdvancedQuery1(Query queryModel)
        {
            queryModel.QueryId = "A1";
            var cid = "N'" + queryModel.VariantName + "\') AND CountriesVariants.VariantId = Variants.Id";
            string query = System.IO.File.ReadAllText(A1_PATH) + cid;

            using (SqlConnection newconnection =
                  new SqlConnection(CONN_STR))
            {
                SqlCommand command =
                    new SqlCommand(query, newconnection);
                newconnection.Open();

                SqlDataReader newreader = command.ExecuteReader();

                while (newreader.Read())
                {
                    ReadSingleRowA1((IDataRecord)newreader);
                }
                newreader.Close();
            }
            queryModel.VariantNames = VariantsNamesA1;
            VariantsNamesA1 = new List<string>();
            return RedirectToAction("Result", queryModel);
        }


        // Advanced Query 2
        List<string> VariantsNamesA2 = new List<string>();
        private void ReadSingleRowA2(IDataRecord dataRecord)
        {
            var rec0 = dataRecord[0];
            VariantsNamesA2.Add((string)rec0);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdvancedQuery2(Query queryModel)
        {
            queryModel.QueryId = "A2";
            var cid = "N'" + queryModel.VariantName + "\') AND SymptomsVariants.VariantId = Variants.Id";
            string query = System.IO.File.ReadAllText(A2_PATH) + cid;

            using (SqlConnection newconnection =
                  new SqlConnection(CONN_STR))
            {
                SqlCommand command =
                    new SqlCommand(query, newconnection);
                newconnection.Open();

                SqlDataReader newreader = command.ExecuteReader();

                while (newreader.Read())
                {
                    ReadSingleRowA2((IDataRecord)newreader);
                }
                newreader.Close();
            }
            queryModel.VariantNames = VariantsNamesA2;
            VariantsNamesA2 = new List<string>();
            return RedirectToAction("Result", queryModel);
        }


        // Advanced Query 3
        List<string> VariantsNamesA3 = new List<string>();
        private void ReadSingleRowA3(IDataRecord dataRecord)
        {
            var rec0 = dataRecord[0];
            VariantsNamesA3.Add((string)rec0);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AdvancedQuery3(Query queryModel)
        {
            queryModel.QueryId = "A3";
            var cid = "N\'" + queryModel.VirusName +
                        "\'\nWHERE Countries.CountryName = N\'" + queryModel.CountryName +
                        "\'" +
                        ") AND CountriesVariants.VariantId = Variants.Id";
            string query = System.IO.File.ReadAllText(A3_PATH) + cid;

            using (SqlConnection newconnection =
                  new SqlConnection(CONN_STR)) {
                SqlCommand command =
                    new SqlCommand(query, newconnection);
                newconnection.Open();

                SqlDataReader newreader = command.ExecuteReader();

                while (newreader.Read()) {
                    ReadSingleRowA3((IDataRecord)newreader);
                }
                newreader.Close();
            }
            queryModel.VariantNames = VariantsNamesA3;
            VariantsNamesA3 = new List<string>();
            return RedirectToAction("Result", queryModel);
        }
        // заг. інформація к-ть всіх штамів по всіх вірусах
        // вивести всі країни, в яких за країною, які
        public IActionResult Result(Query queryResult) => View(queryResult);
    }
}
