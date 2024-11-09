using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Dtos
{
	public class TokenResponseDto
	{
		public TokenResponseDto(string token,DateTime expireDate) {
		Token= token;
			Expire_Date = expireDate;
		}
		public string Token { get; set; }
		public DateTime Expire_Date {  get; set; }
	}
}
