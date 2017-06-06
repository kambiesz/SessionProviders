using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SessionTest
{
	class Program
	{
		static void Main(string[] args)
		{
			const int iterations = 100000;

			for (int i = 0; i < iterations; i++)
			{
				Task.Run(() => GetStateServerAsync());
				//Task.Run(() => GetDefaultAsync());
				//Task.Run(() => GetRedisAsync());

				//GetDefault();
				//GetRedis();
				//GetStateServer();
			}

			Console.WriteLine("END");
			Console.ReadLine();
		}

		static void GetRedisAsync()
		{
			RestClient client = new RestClient(new Uri("http://localhost/RedisSession/api/default"));
			RestRequest request = new RestRequest(Method.GET);

			var response = client.Execute<int>(request);

			using (var context = new DataContext())
			{
				var data = new SessionData
				{
					Date = DateTime.Now,
					Time = response.Data,
					Type = "Redis_Async"
				};

				context.SessionData.Add(data);
				context.SaveChanges();
			}

		}

		static async void GetRedis()
		{
			RestClient client = new RestClient(new Uri("http://localhost/RedisSession/api/default"));
			RestRequest request = new RestRequest(Method.GET);

			var response = client.Execute<int>(request);

			using (var context = new DataContext())
			{
				var data = new SessionData
				{
					Date = DateTime.Now,
					Time = response.Data,
					Type = "Redis"
				};

				context.SessionData.Add(data);
				await context.SaveChangesAsync();
			}
		}

		static void GetDefaultAsync()
		{
			RestClient client = new RestClient(new Uri("http://localhost/DefaultSession/api/default"));
			RestRequest request = new RestRequest(Method.GET);

			var response = client.Execute<int>(request);

			using (var context = new DataContext())
			{
				var data = new SessionData
				{
					Date = DateTime.Now,
					Time = response.Data,
					Type = "Default_Async"
				};

				context.SessionData.Add(data);
				context.SaveChanges();
			}
		}

		static async void GetDefault()
		{
			RestClient client = new RestClient(new Uri("http://localhost/DefaultSession/api/default"));
			RestRequest request = new RestRequest(Method.GET);

			var response = client.Execute<int>(request);

			using (var context = new DataContext())
			{
				var data = new SessionData
				{
					Date = DateTime.Now,
					Time = response.Data,
					Type = "Default"
				};

				context.SessionData.Add(data);
				await context.SaveChangesAsync();
			}

		}

		static async void GetStateServer()
		{
			RestClient client = new RestClient(new Uri("http://localhost/StateServerSession/api/default"));
			RestRequest request = new RestRequest(Method.GET);

			var response = client.Execute<int>(request);

			using (var context = new DataContext())
			{
				var data = new SessionData
				{
					Date = DateTime.Now,
					Time = response.Data,
					Type = "StateServer"
				};

				context.SessionData.Add(data);
				await context.SaveChangesAsync();
			}
		}

		static void GetStateServerAsync()
		{
			RestClient client = new RestClient(new Uri("http://localhost/StateServerSession/api/default"));
			RestRequest request = new RestRequest(Method.GET);

			var response = client.Execute<int>(request);

			using (var context = new DataContext())
			{
				var data = new SessionData
				{
					Date = DateTime.Now,
					Time = response.Data,
					Type = "StateServer_Async"
				};

				context.SessionData.Add(data);
				context.SaveChanges();
			}
		}

	}
}
