﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Features.Mediator.Results.ReviewResults
{
	public class GetReviewByCarIdQueryResult
	{
		public int ReviewId { get; set; }
		public string CustomerName { get; set; }
		public string CustomerImageUrl { get; set; }
		public string Comment { get; set; }
		public string Rating { get; set; }
		public DateTime Rating_Date { get; set; }
		public int CarId { get; set; }
	}
}