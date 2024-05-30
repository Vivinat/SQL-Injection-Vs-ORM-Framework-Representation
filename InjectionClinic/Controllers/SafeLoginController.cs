using InjectionClinic.DataDictionary;
using InjectionClinic.Services;
using Microsoft.AspNetCore.Mvc;
using InjectionClinic.Entities;

namespace InjectionClinic.Controllers
{
    public class SafeLoginController : Controller
    {
        private readonly ConnectionService _connectionService;
        private readonly DataDictionaryCreator _dataDictionaryCreator;


        public SafeLoginController(ConnectionService connectionService, DataDictionaryCreator dataDictionaryCreator)
        {
            _connectionService = connectionService;
            _dataDictionaryCreator = dataDictionaryCreator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Login(string username, string password)
        {
            userinfo user = await _connectionService.StartSafeQuery(username, password);
            await _dataDictionaryCreator.CreateDictionary();
            return Json(user);
        }
    }
}
