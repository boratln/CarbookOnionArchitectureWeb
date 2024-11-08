using Carbook.Application.Features.CQRS.Commands.ContactCommands;
using Carbook.Application.Features.CQRS.Handlers.AboutHandlers;
using Carbook.Application.Features.CQRS.Handlers.BannerHandlers;
using Carbook.Application.Features.CQRS.Handlers.BrandHandlers;
using Carbook.Application.Features.CQRS.Handlers.CarHandlers;
using Carbook.Application.Features.CQRS.Handlers.CategoryHandlers;
using Carbook.Application.Features.CQRS.Handlers.ContactHandlers;
using Carbook.Application.Features.CQRS.Results.CarResults;
using Carbook.Application.Features.Mediator.Handlers.CarPricingHandlers;
using Carbook.Application.Features.RepositoryPattern.CommentRepositories;
using Carbook.Application.Interfaces;
using Carbook.Application.Interfaces.BlogInterFaces;
using Carbook.Application.Interfaces.CarDescriptionInterfaces;
using Carbook.Application.Interfaces.CarFeatureInterfaces;
using Carbook.Application.Interfaces.CarInterfaces;
using Carbook.Application.Interfaces.RentACarInterfaces;
using Carbook.Application.Interfaces.ReviewInterfaces;
using Carbook.Application.Interfaces.StatistictsInterfaces;
using Carbook.Application.Interfaces.TagCloudInterfaces;
using Carbook.Application.Repositories.CarPricingRepository;
using Carbook.Application.Services;
using Carbook.Domain.Entities;
using Carbook.Persistence.Context;
using Carbook.Persistence.Repositories;
using Carbook.Persistence.Repositories.BlogRepositories;
using Carbook.Persistence.Repositories.CarDescriptionRepositories;
using Carbook.Persistence.Repositories.CarFeatureRepository;
using Carbook.Persistence.Repositories.CarPricingRepositories;
using Carbook.Persistence.Repositories.CarRepositories;
using Carbook.Persistence.Repositories.CommentRepositories;
using Carbook.Persistence.Repositories.RentACarRepositories;
using Carbook.Persistence.Repositories.ReviewRepositories;
using Carbook.Persistence.Repositories.StatisticRepositories;
using Carbook.Persistence.Repositories.TagCloudRepositories;
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<CarbookContext>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();

//About

builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

//Banner

//Brand
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();

//Car

builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarWithBrandQueryHandler>();
builder.Services.AddScoped<GetCarWithBrandByCarIdQueryHandler>();


//Category

builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandle>();
builder.Services.AddScoped<UpdateCategoryCommandHandle>();
builder.Services.AddScoped<RemoveCategoryCommandHandle>();


//Contact

builder.Services.AddScoped<GetContactByIdQueryHandle>();
builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();


//CarPricing

builder.Services.AddScoped<GetCarPricingQueryHandler>();


builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IstatisticRepository), typeof(StatistictsRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));

//Mediatr Dependecy Injection

builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
