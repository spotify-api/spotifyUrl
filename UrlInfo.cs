using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Threading.Tasks;

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
                return d;
            }
            else if (rg.IsMatch(url))
            {
                var client = new HttpClient();
                url = url.Split(new[] { "https://open.spotify.com/track/" }, StringSplitOptions.None)[1];

                var res = await client.GetStringAsync("https://open.spotify.com/embed/track/" + url);
                var body = res.Split(new[] { $@"<script id=""resource"" type=""application/json"">" }, StringSplitOptions.None)[1].Split(new[] { "</script>" }, StringSplitOptions.None)[0];
                var json = Uri.UnescapeDataString(body);
                Structure d = JsonConvert.DeserializeObject<Structure>(json);
                return d;
            }
            else
            {
                throw new ArgumentException("The url is not a valid spotify track url");
            }
        }
    }
}
