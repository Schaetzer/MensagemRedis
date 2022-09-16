using Microsoft.AspNetCore.Mvc;
using MensagemRedis.API.Interfaces;

namespace MensagemRedis.API.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedisController : Controller
    {
        private readonly IRedisService _redisService;
        public RedisController(IRedisService redisService)
        {
            _redisService = redisService;
        }

        [HttpGet]
        public IActionResult GetMensagens()
        {
            var result = _redisService.GetMensagens();

            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id:long}")]
        public IActionResult GetMensagensPorId(long id, long languageId)
        {
            var result = _redisService.GetMensagensPorId(id, languageId);

            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
