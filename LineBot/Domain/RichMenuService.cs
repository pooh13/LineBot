using System.Net.Http.Headers;
using LineBot.Dtos;
using LineBot.Enum;
using LineBot.Providers;
using System.Text;
using LineBot.Providers;

namespace LineBot.Domain
{
    public class RichMenuService
    {
        // 貼上 messaging api channel 中的 accessToken & secret
        private readonly string channelAccessToken = "FfsPjDpMjVbSXrtL+PPzlvLaFxedfIj9AF2v5GeRjfeiBZhBINIv0FYaVCVhYrd/tcCMNHLz9PImDWWWOjmSIYlT8NLOvLJ/l3Krn13hSHPRpAv0kShY/4CDUePe00FSIyC4mQHtNeCxlmm4+K7tzAdB04t89/1O/w1cDnyilFU=";
        private readonly string channelSecret = "f570200b4ac594a281e27c9e6fc68f56";

        private static HttpClient client = new HttpClient();
        private readonly JsonProvider _jsonProvider = new JsonProvider();

        private readonly string validateRichMenuUri = "https://api.line.me/v2/bot/richmenu/validate";
        private readonly string createRichMenuUri = "https://api.line.me/v2/bot/richmenu";
        private readonly string getRichMenuListUri = "https://api.line.me/v2/bot/richmenu/list";

        // {0} 的位置要帶入 richMenuId
        private readonly string uploadRichMenuImageUri = "https://api-data.line.me/v2/bot/richmenu/{0}/content";
        // {0} 的位置要帶入 richMenuId
        private readonly string setDefaultRichMenuUri = "https://api.line.me/v2/bot/user/all/richmenu/{0}";

        private readonly string createRichMenuAliasUri = "https://api.line.me/v2/bot/richmenu/alias";
        private readonly string commonRichMenuAliasUri = "https://api.line.me/v2/bot/richmenu/alias/{0}";
        private readonly string getRichMenuAliasListUri = "https://api.line.me/v2/bot/richmenu/alias/list";

        public RichMenuService()
        {
            
        }

        public async Task<string> ValidateRichMenu(RichMenuDto richMenu)
        {
            var jsonBody = new StringContent(_jsonProvider.Serialize(richMenu), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(validateRichMenuUri),
                Content = jsonBody,
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken);
            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }


        public async Task<string> CreateRichMenu(RichMenuDto richMenu)
        {
            var jsonBody = new StringContent(_jsonProvider.Serialize(richMenu), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(createRichMenuUri),
                Content = jsonBody,
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken);
            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<RichMenuListDto> GetRichMenuList()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(getRichMenuListUri),
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken);
            var response = await client.SendAsync(request);

            Console.WriteLine(await response.Content.ReadAsStringAsync());
            var list = _jsonProvider.Deserialize<RichMenuListDto>(await response.Content.ReadAsStringAsync());
            // 依照名稱排序
            list.Richmenus = list.Richmenus.OrderBy((rm) => rm.Name).ToList();
            return list;
        }

        public async Task<string> UploadRichMenuImage(string richMenuId, IFormFile imageFile)
        {
            //判斷檔案格式 需為 png or jpeg
            if (!(Path.GetExtension(imageFile.FileName).Equals(".png", StringComparison.OrdinalIgnoreCase) || Path.GetExtension(imageFile.FileName).Equals(".jpeg", StringComparison.OrdinalIgnoreCase)))
            {
                return "圖片格式錯誤，須為 png or jpeg";
            }
            using (var stream = new MemoryStream())
            {
                //建立檔案內容
                imageFile.CopyTo(stream);
                var fileBytes = stream.ToArray();
                var content = new ByteArrayContent(fileBytes);
                content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
                var request = new HttpRequestMessage(HttpMethod.Post, String.Format(uploadRichMenuImageUri, richMenuId))
                {
                    Content = content
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken);
                var response = await client.SendAsync(request);

                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> SetDefaultRichMenu(string richMenuId)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, String.Format(setDefaultRichMenuUri, richMenuId));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", channelAccessToken);

            var response = await client.SendAsync(request);

            return await response.Content.ReadAsStringAsync();
        }
    }
}