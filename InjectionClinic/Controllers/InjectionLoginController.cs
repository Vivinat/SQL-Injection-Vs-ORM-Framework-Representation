using InjectionClinic.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace InjectionClinic.Controllers
{
    public class InjectionLoginController : Controller
    {
        private readonly ConnectionService _connectionService;

        public InjectionLoginController(ConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {
            DataTable queryResults = new DataTable();
            queryResults = _connectionService.StartUnsafeQuery(username, password);

            // Converter a DataTable em uma lista de dicionários
            var resultsList = new List<Dictionary<string, string>>();
            foreach (DataRow row in queryResults.Rows)
            {
                var dict = new Dictionary<string, string>();
                foreach (DataColumn col in queryResults.Columns)
                {
                    dict[col.ColumnName] = row[col].ToString();
                }
                resultsList.Add(dict);
            }


            return Json(resultsList);
        }
    }
}
