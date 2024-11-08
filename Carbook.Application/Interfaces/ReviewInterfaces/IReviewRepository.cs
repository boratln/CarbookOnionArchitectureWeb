using Carbook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Interfaces.ReviewInterfaces
{
	public interface IReviewRepository
	{
		Task<List<Review>> GetReviewsByCarId(int carId);
		int  ReviewCount(int carId);
	}
}
