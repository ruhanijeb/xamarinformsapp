using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ReactiveUIDemo.Models
{
    public class ImageConfigurationDto
    {
        [JsonProperty(PropertyName = "images")]
        public ImagesDto Images { get; set; }

        /// <summary>
        /// Gets or sets the change keys.
        /// </summary>
        [JsonProperty(PropertyName = "change_keys")]
        [SuppressMessage("Design", "CA2227: Change to be read-only by removing the property setter.", Justification = "Used in DTO object.")]
        public IList<string> ChangeKeys { get; set; }
    }
}
