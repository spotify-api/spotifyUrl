using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Drawing;

namespace SpotifyUrl
{
    public class UrlInfo

    {
        public async Task<Structure> GetData(string url)
        {
            var reg = new Regex(@"(http|https):\/\/open.spotify.com\/embed(\/track\/|\?uri=)(.*?)");
            var rg = new Regex(@"(http|https):\/\/open.spotify.com\/track\/(.*?)");
            if (reg.IsMatch(url))
            {
                var client = new HttpClient();
                var res = await client.GetStringAsync(url);
                var body = res.Split(new[] { $@"<script id=""resource"" type=""application/json"">" }, StringSplitOptions.None)[1].Split(new[] { "</script>" }, StringSplitOptions.None)[0];
                var json = Uri.UnescapeDataString(body);
                Structure d = JsonConvert.DeserializeObject<Structure>(json);
                d.dominantColor = GetDominantColor(d.album.images[0].url);
                return d;
            }
            else if (rg.IsMatch(url))
            {
                var client = new HttpClient();
                url = url.Split(new[] { "https://open.spotify.com/track/" }, StringSplitOptions.None)[1];

                var res = await client.GetStringAsync("https://open.spotify.com/embed/track/" + url);
                var body = res.Split(new[] { $@"<script id=""resource"" type=""application/json"">" }, StringSplitOptions.None)[1].Split(new[] { "</script>" }, StringSplitOptions.None)[0];
                var json = Uri.UnescapeDataString(body);
                Structure d = new Structure();
                d = JsonConvert.DeserializeObject<Structure>(json);
                d.dominantColor = GetDominantColor(d.album.images[0].url);
                return d;
            }
            else
            {
                throw new ArgumentException("The url is not a valid spotify track url");
            }
        }
        private string GetDominantColor(String imageURL) {
            System.Net.WebRequest request = System.Net.WebRequest.Create(imageURL);
            var stream = request.GetResponse().GetResponseStream();
            Bitmap bmp = new Bitmap(stream);
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;
            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    Color clr = bmp.GetPixel(x, y);

                    r += clr.R;
                    g += clr.G;
                    b += clr.B;

                    total++;
                }
            }

            r /= total;
            g /= total;
            b /= total;
            return ColorTranslator.ToHtml(Color.FromArgb(r,g,b));
        }
    }
}
