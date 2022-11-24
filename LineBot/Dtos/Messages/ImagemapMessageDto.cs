using System;
using LineBot.Enum;

namespace LineBot.Dtos
{
    public class ImagemapMessageDto : BaseMessageDto
    {
        public ImagemapMessageDto()
        {
            Type = MessageTypeEnum.Imagemap;
        }

        public string BaseUrl { get; set; }
        public string AltText { get; set; }
        public ImagemapBaseSizeDto BaseSize { get; set; }
        public ImagemapVideoDto? Video { get; set; }

        public List<ImagemapActionDto> Actions { get; set; }
    }

    public class ImagemapBaseSizeDto
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class ImagemapVideoDto
    {
        public string OriginalContentUrl { get; set; }
        public string PreviewImageUrl { get; set; }
        public ImagemapAreaDto Area { get; set; }
        public ImagemapVideoExternalLinkDto ExternalLink { get; set; }
    }

    public class ImagemapAreaDto
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class ImagemapVideoExternalLinkDto
    {
        public string LinkUri { get; set; }
        public string Label { get; set; }
    }
}

