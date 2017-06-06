using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionTest
{
	class DataContext : DbContext
	{
		public DataContext() : base("Data Source=.; Database=SessionTest; Integrated Security = True; MultipleActiveResultSets=true;")
		{

		}
		public DbSet<SessionData> SessionData { get; set; }
	}
}
