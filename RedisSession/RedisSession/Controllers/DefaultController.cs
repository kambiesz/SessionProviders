using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

namespace RedisSession.Controllers
{
    public class DefaultController : ApiController
    {
		private HttpSessionState Session => HttpContext.Current.Session;

		public IHttpActionResult Get()
		{
			var data = new SessionData
			{
				Id = 1,
				Date = DateTime.Now,
				Name = "Kamil",
				Words = new List<string>
				{
					"Wyraz1", "Wyraz2", "Wyraz3"
				}

			};

			Stopwatch sw = new Stopwatch();
			sw.Start();
			Session["Data"] = data;
			var sessionData = (SessionData)Session["Data"];
			sw.Stop();

			return Ok(sw.ElapsedTicks);

		}
    }

	[Serializable]
	public class SessionData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Date { get; set; }
		public List<string> Words { get; set; }
	}
}
