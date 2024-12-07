using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace decoSpammer
{
    internal class Program
    {
     
        private static readonly HttpClient client = new HttpClient();

        public static string nickname;
        private static string authorizationToken;
        public static int treeTrongDuoc = 0;
        private static readonly Random random = new Random();
        public static string nicknameDefault = "NTA2k7|T.Manh|TManh|HuyNho|GiaUy|iamgiauy|MTriet|NhuLong|HPhong|Dangrangto|TranLaLuot|MCKey|trmy|Quân|An|Bảo|Cát|Duy|Khôi|Lam|Linh|MinhNgọc|Phúc|Quỳnh|Sơn|Thảo|Thiên|Thu|Trúc|Uyên|Vân|Việt||NgHân|TPhúc|HDuy|ThThảo|HVân|TrQuỳnhh|PhNam|ATuấn|HĐăng|BảoG|TVy|QHưngg|L.Anh|TDương|Khoa|HữuPhước|NhưÝ|Gill2k9|KimNgân|HảiYến|NgọcAnh|MinhHuy|ThiênAn|PhúcLâm|KhánhVy|BảoNgọc|HoàngPhong|ThanhTrúc|PhươngThảo|AnhKhoa|TúUyên|HồngĐào|HữuTín|NhậtMinh|QuỳnhChi|TrườngSơn|ThảoVy|VĩnhPhát||AnNhi_2008|BảoChâu_2009|CẩmHà_2010|DuyAnh_2011|GiaHuy_2012|HảiĐông_2013|KimThư_2008|LamPhương_2009|MinhTriết_2010|NgọcKhang_2011|PhúcAn_2012|QuốcThái_2013|TúVi_2008|ThànhĐạt_2009|ThảoNhi_2010|2011pronhe|VKhánhh_2012|Minh2k13pro|YếnNgọc_2008|HTâm2009|";
        private static string[] nicknameArray;
        private static string token = "your_authorization_token"; 
        private static string url = "https://deco-my-tree-web.com/api/v1/message/";
        private static string hash = "endpoint_hash"; 

        static async Task SendRequest()
        {
            try
            {
                nicknameArray = nickname.Split('|');
                // Ensure nicknameArray is not empty
                if (nicknameArray == null || nicknameArray.Length == 0)
                {
                    throw new InvalidOperationException("Nickname array is empty or null.");
                }

                var data = new
                {
                    name = nicknameArray[random.Next(0, nicknameArray.Length)],
                    content = "giáng sinh vui vẻ",
                    deco_index = random.Next(0, 26),
                    only_for_user = false
                };

                string json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Check if token or URL is null
                if (string.IsNullOrEmpty(token)) throw new InvalidOperationException("Token is null or empty.");
                if (string.IsNullOrEmpty(url)) throw new InvalidOperationException("URL is null or empty.");
                if (string.IsNullOrEmpty(hash)) throw new InvalidOperationException("Hash is null or empty.");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add("Host", "deco-my-tree-web.com");
                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/131.0.0.0 Safari/537.36 Edg/131.0.0.0");
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Accept-Language", "tr-TR,tr;q=0.8,en-US;q=0.5,en;q=0.3");
                client.DefaultRequestHeaders.Add("Authorization", token);

                HttpResponseMessage response = await client.PostAsync(url + hash, content);

                string responseBody = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;

                if (response.IsSuccessStatusCode && responseBody.Contains("success"))
                {
                    treeTrongDuoc++;
                    Console.WriteLine("Số lần thiệp được tạo: " + treeTrongDuoc);
                }
                else
                {
                    Console.WriteLine($"Request failed: {response.StatusCode} - {responseBody}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Không thể gửi! " + ex.Message);
            }
        }


        public static int freq;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Set the console encoding to UTF-8
            Console.OutputEncoding = Encoding.UTF8;

            // Array of colors to choose from
            ConsoleColor[] colors = ((ConsoleColor[])Enum.GetValues(typeof(ConsoleColor)))
                        .Where(c => c != ConsoleColor.Black)
                        .ToArray();
            Random random = new Random();

            // ASCII art lines
            string[] asciiArt = {
            "·▄▄▄▄  ▄▄▄ . ▄▄·       .▄▄ ·  ▄▄▄· ▄▄▄· • ▌ ▄ ·. • ▌ ▄ ·. ▄▄▄ .▄▄▄  ",
            "██▪ ██ ▀▄.▀·▐█ ▌▪▪     ▐█ ▀. ▐█ ▄█▐█ ▀█ ·██ ▐███▪·██ ▐███▪▀▄.▀·▀▄ █·",
            "▐█· ▐█▌▐▀▀▪▄██ ▄▄ ▄█▀▄ ▄▀▀▀█▄ ██▀·▄█▀▀█ ▐█ ▌▐▌▐█·▐█ ▌▐▌▐█·▐▀▀▪▄▐▀▀▄ ",
            "██. ██ ▐█▄▄▌▐███▌▐█▌.▐▌▐█▄▪▐█▐█▪·•▐█ ▪▐▌██ ██▌▐█▌██ ██▌▐█▌▐█▄▄▌▐█•█▌",
            "▀▀▀▀▀•  ▀▀▀ ·▀▀▀  ▀█▄▀▪ ▀▀▀▀ .▀    ▀  ▀ ▀▀  █▪▀▀▀▀▀  █▪▀▀▀ ▀▀▀ .▀  ▀ decoSpammer - by. giauydev"
        };

            // Loop through each line and set a random color
            foreach (string line in asciiArt)
            {
                Console.ForegroundColor = colors[random.Next(colors.Length)]; // Pick a random color
                Console.WriteLine(line);
            }

            // Reset color to default
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Nhập token của bạn: ");
            token = Console.ReadLine();
            Console.Write("Nhập mã hash của bạn: ");
            hash = Console.ReadLine();
            Console.WriteLine("Nhập tất cả các nickname mà bạn muốn xuất hiện trong cây thông(Mỗi nickname cách nhau bởi dấu | - Gõ default để sử dụng các nickname của hệ thống): ");
            nickname = Console.ReadLine();
            if(nickname == "default")
            {
                nickname = nicknameDefault;
            }
            Console.Write("Số lần spam: ");
            freq = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[WAITING] - Preparing...");
            Thread.Sleep(30);
            Console.WriteLine("[READY] - Prepared, will start in 5 seconds");
            Thread.Sleep(500);
            Console.Clear();
            for (int i = 0; i <= freq;i++)
            {

               
                    Thread.Sleep(3);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                    SendRequest();

            
            }
        }
    }
}
