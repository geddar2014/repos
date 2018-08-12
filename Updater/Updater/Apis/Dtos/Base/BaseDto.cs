using System;
using System.Collections.Generic;
using System.Text;
using Insight.Database;
using Newtonsoft.Json;

namespace Updater.Common
{
    public class BaseDto : IDto
    {
        [RecordId]
        [JsonProperty("I")]
        public string Id { get; set; }

        public override string ToString()
        {
            return $"[{Id}]";
        }
    }
}
