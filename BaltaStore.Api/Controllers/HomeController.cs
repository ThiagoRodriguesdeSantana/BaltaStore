using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class HomeController : Controller
    {
        //O controller manipula as requisições que vem do usuario
        [HttpGet]
        [Route("")]
        public string Get()
        {
            return "Hello World";
        }
    }
}