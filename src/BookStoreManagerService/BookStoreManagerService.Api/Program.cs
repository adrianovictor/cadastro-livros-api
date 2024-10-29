using System.Reflection;
using BookStoreManagerService.Application.Handlers.Command.Authors;
using BookStoreManagerService.Domain.Repository.Commands;
using BookStoreManagerService.Domain.Repository.Common;
using BookStoreManagerService.Domain.Repository.Queries;
using BookStoreManagerService.Infrastructure.DataContext;
using BookStoreManagerService.Infrastructure.Repositories.Commands;
using BookStoreManagerService.Infrastructure.Repositories.Common;
using BookStoreManagerService.Infrastructure.Repositories.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(typeof(CreateAuthorHandler).GetTypeInfo().Assembly);
//builder.Services.AddScoped(provider => new BookStoreDbContext(builder.Configuration.GetConnectionString("DefaultConnection")!));
builder.Services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
builder.Services.AddTransient<IBookQueryRepository>(provider => new BookQueryRepository(builder.Configuration.GetConnectionString("DefaultConnection")!));

builder.Services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
builder.Services.AddTransient<IAuthorRepository, AuthorCommandRepository>();
builder.Services.AddTransient<IBookRepository, BookCommandRepository>();
builder.Services.AddTransient<ISubjectRepository, SubjectCommandRepository>();

// Add services to the container.

builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAllOrigins", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins"); // Habilita a política CORS

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
