using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PartyInvites.Models
{
    public class PageLength
    {
		public string Address { get; set; }
		public long Length { get; set; }


		public async static Task<long?> GetPageLength(string page)
		{
			HttpClient client = new HttpClient();
			var httpMessage = await client.GetAsync(page);
			return httpMessage.Content.Headers.ContentLength;
		}
	}
}
