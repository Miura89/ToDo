using Microsoft.AspNetCore.Mvc;

namespace ToDo.Controllers
{
    [Route("/v1")]
    public class ControllerTeste : ControllerBase
    {
        [HttpGet("/")]
        public string HelloWorld()
        {
            return "hello world";
        }
    }
}
