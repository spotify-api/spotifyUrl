using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyUrl
{
    public class Structure
    {
        public AlbumStruct album { get; set; }
        public ArtistStruct[] artists { get; set; }
        public int disc_number { get; set; }
        public int duration_ms { get; set; }
        public external_urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public bool is_local { get; set; }
        public bool is_playable { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public string preview_url { get; set; }
        public int track_number { get; set; }
        public string uri { get; set; }
        public string dominantColor { get; set; }
    }
    public class AlbumStruct
    {
        public string album_type { get; set; }
        public ArtistStruct[] artists { get; set; }
        public external_urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public Images[] images { get; set; }
        public string name { get; set; }
        public string release_date { get; set; }
        public int total_tracks { get; set; }
        public string type { get; set; }
        public string uri { get; set; }

    }
    public class ArtistStruct
    {
        public external_urls external_urls { get; set; }
        public string href { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string uri { get; set; }
    }
    public class external_urls
    {
        public string spotify { get; set; }
    }
    public class Images
    {
        public int height { get; set; }
        public int width { get; set; }
        public string url { get; set; }
    }
}
