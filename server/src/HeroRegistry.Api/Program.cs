using FluentValidation;
using HeroRegistry.Application.Commands.Herois.Criar;
using HeroRegistry.Application.Common.Behaviors;
using HeroRegistry.Application.Heroes.Commands.Criar;
using HeroRegistry.Domain.Models.Herois;
using HeroRegistry.Infrastructure;
using HeroRegistry.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hero Registry API",
        Version = "v1",
        Description = "Uma API para gerenciar um cadastro de heróis.",
        Contact = new OpenApiContact
        {
            Name = "Hero Registry Suporte",
            Email = "",
        }
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CriarHeroiCommandHandler).Assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(typeof(CriarHeroiValidation).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(AtualizarHeroiValidation).Assembly);


builder.Services.AddScoped<IHeroiRepositorio, HeroRepository>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hero Registry API v1");
    });
}

app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapControllers();
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();

app.Run();
