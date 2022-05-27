


//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.Data.SqlClient;
//using Microsoft.EntityFrameworkCore;
//using LabaOne.Models;
//using System.Reflection;
//using System.Data.SqlServerCe;

//namespace LabaOne.Controllers
//{
//    public class QueriesController : Controller
//    {
//        private const string CONN_STR = "Server=DESKTOP-JNBPJFN;Database=DBFinal;Trusted_Connection=True;MultipleActiveResultSets=true";

//        private const string S1_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S1.sql";
//        private const string S2_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S2.sql";
//        private const string S3_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S3.sql";
//        private const string S4_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S4.sql";
//        private const string S5_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S5.sql";
//        private const string S6_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\S6.sql";
//        private const string A1_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\A1.sql";
//        private const string A2_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\A2.sql";
//        private const string A3_PATH = @"C:\Users\Yaroslav\Desktop\БД\БД лаба 2\LabaOne\Запити\A3.sql";

//        //private const string ERR_AVG = "Неможливо обрахувати середню ціну, оскільки продукти відсутні.";
//        //private const string ERR_CUST = "Покупці, що задовольняють дану умову, відсутні.";
//        //private const string ERR_PROD = "Програмні продукти, що задовольняють дану умову, відсутні.";
//        //private const string ERR_DEV = "Розробники, що задовольняють дану умову, відсутні.";
//        private const string ERR_COUNTRY = "Країни, що задовольняють дану умову, відсутні.";

//        private readonly DBFinalContext _context;

//        public QueriesController(DBFinalContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index(int errorCode)
//        {
//            var variants = _context.Variants.Select(c => c.VariantName).Distinct().ToList();
//            var viruses = _context.Viruses.Select(c => c.VirusName).Distinct().ToList();
//            if (errorCode == 1)
//            {
//                ViewBag.ErrorFlag = 1;
//                ViewBag.PriceError = "Введіть коректну вартість";
//            }
//            if (errorCode == 2)
//            {
//                ViewBag.ErrorFlag = 2;
//                ViewBag.ProdNameError = "Поле необхідно заповнити";
//            }

//            var empty = new SelectList(new List<string> { "--Пусто--" });
//            ViewBag.VirusNames = viruses;
//            ViewBag.VariantNames = variants;
//            //var anyCusts = _context.Customers.Any();
//            //var anyDevs = _context.Developers.Any();

//            //ViewBag.DevIds = anyDevs ? new SelectList(_context.Developers, "Id", "Id") : empty;
//            //ViewBag.DevNames = anyDevs ? new SelectList(_context.Developers, "Name", "Name") : empty;
//            //ViewBag.CustNames = anyCusts ? new SelectList(customers) : empty;
//            //ViewBag.CustEmails = anyCusts ? new SelectList(_context.Customers, "Email", "Email") : empty;
//            //ViewBag.CustSurnames = anyCusts ? new SelectList(_context.Customers, "Surname", "Surname") : empty;
//            //ViewBag.Countries = _context.Countries.Any() ? new SelectList(_context.Countries, "Name", "Name") : empty;
//            return View();
//        }


//        string q = "SELECT Count(Countries.CountryName) FROM Countries JOIN CountriesVariants ON Countries.Id = CountriesVariants.CountryId JOIN Variants ON Variants.Id = CountriesVariants.VariantId JOIN Virus ON Virus.Id = Variants.VirusId WHERE Virus.Id= 15";


//        List<int> Ids = new List<int>();
//        List<string> VariantsNamesQ1 = new List<string>();
//        private void ReadSingleRowQ1(IDataRecord dataRecord)
//        {
//            var rec0 = dataRecord[0];
//            VariantsNamesQ1.Add((string)rec0);
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult SimpleQuery1(Query queryModel)
//        {
//            queryModel.QueryId = "S1";
//            var cid = "N\'" + queryModel.CountryName + "\'));";

//            string query = System.IO.File.ReadAllText(S1_PATH) + cid;


//            using (SqlConnection newconnection =
//                  new SqlConnection(CONN_STR))
//            {
//                SqlCommand command =
//                    new SqlCommand(query, newconnection);
//                newconnection.Open();

//                SqlDataReader newreader = command.ExecuteReader();

//                // Call Read before accessing data.
//                while (newreader.Read())
//                {
//                    ReadSingleRowQ1((IDataRecord)newreader);
//                }

//                newreader.Close();
//            }
//            queryModel.VariantNames = VariantsNamesQ1;
//            VariantsNamesQ1 = new List<string>();
//            return RedirectToAction("Result", queryModel);
//        }

//        List<string> VariantsNamesQ2 = new List<string>();
//        private void ReadSingleRowQ2(IDataRecord dataRecord)
//        {
//            var rec0 = dataRecord[0];
//            VariantsNamesQ2.Add((string)rec0);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult SimpleQuery2(Query queryModel)
//        {
//            queryModel.QueryId = "S2";
//            var cid = "N\'" + queryModel.VirusName + "\'));";

//            string query = System.IO.File.ReadAllText(S2_PATH) + cid;


//            using (SqlConnection newconnection =
//                  new SqlConnection(CONN_STR))
//            {
//                SqlCommand command =
//                    new SqlCommand(query, newconnection);
//                newconnection.Open();

//                SqlDataReader newreader = command.ExecuteReader();
//                while (newreader.Read())
//                {
//                    ReadSingleRowQ2((IDataRecord)newreader);
//                }

//                newreader.Close();
//            }
//            queryModel.VariantNames = VariantsNamesQ2;
//            VariantsNamesQ2 = new List<string>();
//            return RedirectToAction("Result", queryModel);
//        }

//        List<string> VariantsNamesQ3 = new List<string>();
//        private void ReadSingleRowQ3(IDataRecord dataRecord)
//        {
//            var rec0 = dataRecord[0];
//            VariantsNamesQ3.Add((string)rec0);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult SimpleQuery3(Query queryModel)
//        {
//            queryModel.QueryId = "S3";
//            var cid = "N\'" + queryModel.SymptomName + "\'));";

//            string query = System.IO.File.ReadAllText(S3_PATH) + cid;


//            using (SqlConnection newconnection =
//                  new SqlConnection(CONN_STR))
//            {
//                SqlCommand command =
//                    new SqlCommand(query, newconnection);
//                newconnection.Open();

//                SqlDataReader newreader = command.ExecuteReader();

//                // Call Read before accessing data.
//                while (newreader.Read())
//                {
//                    ReadSingleRowQ3((IDataRecord)newreader);
//                }

//                newreader.Close();
//            }
//            queryModel.VariantNames = VariantsNamesQ3;
//            VariantsNamesQ3 = new List<string>();
//            return RedirectToAction("Result", queryModel);
//        }


//        //List<string> VariantsNamesQ4 = new List<string>();
//        private int ReadSingleRowQ4(IDataRecord dataRecord)
//        {
//            return (int)dataRecord[0];
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult SimpleQuery4(Query queryModel)
//        {
//            queryModel.QueryId = "S4";
//            var cid = " N\'" + queryModel.VariantName + "\');";

//            string query = System.IO.File.ReadAllText(S4_PATH) + cid;


//            using (SqlConnection newconnection =
//                  new SqlConnection(CONN_STR))
//            {
//                SqlCommand command =
//                    new SqlCommand(query, newconnection);
//                newconnection.Open();

//                SqlDataReader newreader = command.ExecuteReader();

//                // Call Read before accessing data.
//                while (newreader.Read())
//                {
//                    queryModel.countryNamesCount = ReadSingleRowQ4((IDataRecord)newreader);
//                    break;
//                }

//                newreader.Close();
//            }

//            //queryModel.VariantNames = VariantsNamesQ4;
//            //VariantsNamesQ4 = new List<string>();
//            return RedirectToAction("Result", queryModel);
//        }


//        private int ReadSingleRowQ5(IDataRecord dataRecord)
//        {
//            return (int)dataRecord[0];
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult SimpleQuery5(Query queryModel)
//        {
//            queryModel.QueryId = "S5";
//            var cid = "N\'" + queryModel.CountryName + "\'";

//            string query = System.IO.File.ReadAllText(S5_PATH) + cid;


//            using (SqlConnection newconnection =
//                  new SqlConnection(CONN_STR))
//            {
//                SqlCommand command =
//                    new SqlCommand(query, newconnection);
//                newconnection.Open();

//                SqlDataReader newreader = command.ExecuteReader();

//                // Call Read before accessing data.
//                while (newreader.Read())
//                {
//                    queryModel.countryNamesCount = ReadSingleRowQ5((IDataRecord)newreader);
//                    break;
//                }

//                newreader.Close();
//            }
//            return RedirectToAction("Result", queryModel);
//        }

//        List<string> VariantsNamesA1 = new List<string>();
//        private void ReadSingleRowA1(IDataRecord dataRecord)
//        {
//            var rec0 = dataRecord[0];
//            VariantsNamesA1.Add((string)rec0);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult AdvancedQuery1(Query queryModel)
//        {
//            queryModel.QueryId = "A1";
//            var cid = "N'" + queryModel.VariantName + "\') AND CountriesVariants.VariantId = Variants.Id";

//            string query = System.IO.File.ReadAllText(A1_PATH) + cid;


//            using (SqlConnection newconnection =
//                  new SqlConnection(CONN_STR))
//            {
//                SqlCommand command =
//                    new SqlCommand(query, newconnection);
//                newconnection.Open();

//                SqlDataReader newreader = command.ExecuteReader();

//                // Call Read before accessing data.
//                while (newreader.Read())
//                {
//                    ReadSingleRowA1((IDataRecord)newreader);
//                }

//                newreader.Close();
//            }
//            queryModel.VariantNames = VariantsNamesA1;
//            VariantsNamesA1 = new List<string>();
//            return RedirectToAction("Result", queryModel);
//        }


//        List<string> VariantsNamesA2 = new List<string>();
//        private void ReadSingleRowA2(IDataRecord dataRecord)
//        {
//            var rec0 = dataRecord[0];
//            VariantsNamesA2.Add((string)rec0);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult AdvancedQuery2(Query queryModel)
//        {
//            queryModel.QueryId = "A2";
//            var cid = "N'" + queryModel.VariantName + "\') AND SymptomsVariants.VariantId = Variants.Id";

//            string query = System.IO.File.ReadAllText(A2_PATH) + cid;


//            using (SqlConnection newconnection =
//                  new SqlConnection(CONN_STR))
//            {
//                SqlCommand command =
//                    new SqlCommand(query, newconnection);
//                newconnection.Open();

//                SqlDataReader newreader = command.ExecuteReader();

//                // Call Read before accessing data.
//                while (newreader.Read())
//                {
//                    ReadSingleRowA2((IDataRecord)newreader);
//                }

//                newreader.Close();
//            }
//            queryModel.VariantNames = VariantsNamesA2;
//            VariantsNamesA2 = new List<string>();
//            return RedirectToAction("Result", queryModel);
//        }


//        List<string> VariantsNamesA3 = new List<string>();
//        private void ReadSingleRowA3(IDataRecord dataRecord)
//        {
//            var rec0 = dataRecord[0];
//            VariantsNamesA3.Add((string)rec0);
//        }
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult AdvancedQuery3(Query queryModel)
//        {
//            queryModel.QueryId = "A3";
//            var cid = "N\'" + queryModel.VirusName +
//                        "\'\nWHERE Countries.CountryName = N\'" + queryModel.CountryName +
//                        "\'" +
//                        ") AND CountriesVariants.VariantId = Variants.Id";


//            string query = System.IO.File.ReadAllText(A3_PATH) + cid;


//            using (SqlConnection newconnection =
//                  new SqlConnection(CONN_STR))
//            {
//                SqlCommand command =
//                    new SqlCommand(query, newconnection);
//                newconnection.Open();

//                SqlDataReader newreader = command.ExecuteReader();

//                // Call Read before accessing data.
//                while (newreader.Read())
//                {
//                    ReadSingleRowA3((IDataRecord)newreader);
//                }

//                newreader.Close();
//            }
//            queryModel.VariantNames = VariantsNamesA3;
//            VariantsNamesA3 = new List<string>();
//            return RedirectToAction("Result", queryModel);
//        }



//        public IActionResult TeacherQuery1(Query queryModel)
//        {
//            throw new NotImplementedException();
//        }

//        public IActionResult TeacherQuery2(Query queryModel)
//        {
//            throw new NotImplementedException();
//        }

//        public IActionResult Result(Query queryResult)
//        {
//            return View(queryResult);
//        }
//    }
//}