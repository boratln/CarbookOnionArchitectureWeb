using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudience = "https://localhost";
		public const string ValidIssiuer = "http://localhost";
		public const string Key = "Carbook01Carbook014548+CarbookProje01214+";
		public const int Expire = 3;
	}
}
