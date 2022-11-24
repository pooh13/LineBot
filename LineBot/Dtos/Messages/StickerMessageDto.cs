using System;
using LineBot.Enum;

namespace LineBot.Dtos
{
    public class StickerMessageDto : BaseMessageDto
    {
        public StickerMessageDto()
        {
            Type = MessageTypeEnum.Sticker;
        }
        public string PackageId { get; set; }
        public string StickerId { get; set; }
    }
}

