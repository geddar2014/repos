using System;
using Newtonsoft.Json;
using Updater.Common;

namespace Updater.Apis.Dtos
{
	public abstract class DtoBase : IDto
	{
		protected DtoBase()
		{
			CreationTime = DateTime.Now;
			IsDeleted    = false;
		}

		[JsonIgnore]
		public DateTime CreationTime { get; set; }

		[JsonProperty("Id")]
		public int Id { get; set; }

		[JsonIgnore]
		public bool IsDeleted { get; set; }
	}
}