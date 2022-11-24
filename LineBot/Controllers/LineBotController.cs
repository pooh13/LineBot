using System.ComponentModel.DataAnnotations;
using LineBot.Dtos;
using LineBot.Services;
using Microsoft.AspNetCore.Mvc;

namespace LineBot.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class LineBotController : ControllerBase
    {

        // 宣告 service
        private readonly LineBotService _lineBotService;
        // constructor
        public LineBotController()
        {
            _lineBotService = new LineBotService();
        }

        [HttpPost("Webhook")]
        public IActionResult Webhook(WebhookRequestBodyDto body)
        {
            _lineBotService.ReceiveWebhook(body); // 呼叫 Service
            return Ok();
        }

        [HttpPost("SendMessage/Broadcast")]
        public IActionResult Broadcast([Required] string messageType, object body)
        {
            _lineBotService.BroadcastMessageHandler(messageType, body);
            return Ok();
        }
    }

}
