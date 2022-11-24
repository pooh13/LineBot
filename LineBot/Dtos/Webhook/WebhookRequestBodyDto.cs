using System;
using LineBot.Dtos.Webhook;

namespace LineBot.Dtos
{
	public class WebhookRequestBodyDto
	{
        public string? Destination { get; set; }
        public List<WebhookEventsDto> Events { get; set; }
    }
}

