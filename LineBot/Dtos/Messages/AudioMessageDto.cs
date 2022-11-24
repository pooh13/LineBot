using System;
using LineBot.Enum;

namespace LineBot.Dtos
{
    public class AudioMessageDto : BaseMessageDto
    {
        public AudioMessageDto()
        {
            Type = MessageTypeEnum.Audio;
        }

        public string OriginalContentUrl { get; set; }
        public int Duration { get; set; }
    }
}

