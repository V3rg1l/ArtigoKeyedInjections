using KeyedInjections.Assets;
using Microsoft.AspNetCore.Mvc;

namespace KeyedInjections.Controllers
{
    [ApiController]
    public class KeyedInjectionsController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public KeyedInjectionsController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpGet("net7")]
        public IEnumerable<string> Get(IService service) 
        {
            yield return service.Notice("One or Two");
        }

        [HttpGet("net8One")]
        public IEnumerable<string> Net8One([FromKeyedServices("One")]IService service)
        {
            yield return service.Notice("One or Two");
        }

        [HttpGet("net8Two")]
        public IEnumerable<string> Net8Two([FromKeyedServices("Two")] IService service)
        {
            yield return service.Notice("One or Two");
        }

        [HttpGet("net8OneAndTwo")]
        public ActionResult<string> Net8OneAndTwo()
        {
            var _one = _serviceProvider.GetRequiredKeyedService<IService>("One");
            var _two = _serviceProvider.GetRequiredKeyedService<IService>("Two");

            return Ok(new { one = _one.Notice("One or Two"), two = _two.Notice("One or Two") });
            
        }
    }
}
