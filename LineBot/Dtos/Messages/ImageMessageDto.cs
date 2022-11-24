using System;
using LineBot.Enum;

namespace LineBot.Dtos
{
    public class ImageMessageDto : BaseMessageDto
    {
        public ImageMessageDto()
        {
            Type = MessageTypeEnum.Image;
        }

        public string OriginalContentUrl { get; set; } //張開後的樣子
        public string PreviewImageUrl { get; set; } //縮圖
    }
}

