﻿using Carbook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carbook.Application.Validaters.ReviewValidater
{ 
	public class CreateReviewValidator: AbstractValidator<CreateReviewCommand>
	{
		public CreateReviewValidator()
		{
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen Müşteri Adını Boş Geçmeyiniz");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
			RuleFor(x => x.Rating).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum kısmını boş geçmeyiniz");
			RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen yorum kısmını en az 50 karakterle veri girişi yapınız");
			RuleFor(x => x.Comment).MaximumLength(250).WithMessage("Lütfen yorum kısmını en fazla 250 karakterle veri girişi yapınız");
		}
	}
}
