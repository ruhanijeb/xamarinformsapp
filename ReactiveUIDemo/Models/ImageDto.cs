using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ReactiveUIDemo.Models
{
    [SuppressMessage("Design", "CA2227: Change to be read-only by removing the property setter.", Justification = "Used in DTO object.")]
    public class ImagesDto
    {
        [JsonProperty(PropertyName = "base_url")]
        public string BaseUrl { get; set; }

        [JsonProperty(PropertyName = "secure_base_url")]
        public string SecureBaseUrl { get; set; }

        [JsonProperty(PropertyName = "backdrop_sizes")]
        public IList<string> BackdropSizes { get; set; }
        [JsonProperty(PropertyName = "logo_sizes")]
        public IList<string> LogoSizes { get; set; }

        [JsonProperty(PropertyName = "poster_sizes")]
        public IList<string> PosterSizes { get; set; }

        [JsonProperty(PropertyName = "profile_sizes")]
        public IList<string> ProfileSizes { get; set; }

        [JsonProperty(PropertyName = "still_sizes")]
        public IList<string> StillSizes { get; set; }
    }
}
