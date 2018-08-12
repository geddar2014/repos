using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Updater.Common
{
    public class BaseDtoWithTitle : BaseDto, IDtoWithTitle
    {
        [JsonProperty("T")]
		[JsonProperty("N")]
        public string Title { get; set; }

        public override string ToString()
        {
            return $"[{Id}] {Title}";
        }
    }
}
