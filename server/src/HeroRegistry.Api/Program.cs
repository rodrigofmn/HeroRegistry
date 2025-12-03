using FluentValidation;
using HeroRegistry.Api.Profiles;
using HeroRegistry.Application.Commands.Herois.Criar;
using HeroRegistry.Application.Common.Behaviors;
using HeroRegistry.Application.Heroes.Commands.Atualizar;
using HeroRegistry.Application.Heroes.Commands.Criar;
using HeroRegistry.Application.Heroes.Commands.Herois.Remover;
using HeroRegistry.Domain.Models.Herois;
using HeroRegistry.Domain.Models.SuperPoderesHeroi;
using HeroRegistry.Infrastructure;
using HeroRegistry.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CriarHeroiCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(AtualizarHeroiCommandHandler).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(RemoverHeroiCommandHandler).Assembly);
    cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .WithOrigins("http://localhost:5173");
    });
});

builder.Services.AddValidatorsFromAssembly(typeof(CriarHeroiValidation).Assembly);
builder.Services.AddValidatorsFromAssembly(typeof(AtualizarHeroiValidation).Assembly);


builder.Services.AddScoped<IHeroiRepositorio, HeroRepositorio>();
builder.Services.AddScoped<ISuperPoderRepositorio, SuperPoderRepositorio>();

builder.Services.AddAutoMapper(cfg => cfg.AddMaps(typeof(HeroiProfile).Assembly));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Hero Registry API v1");
    });
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.MapGet("/", () => Results.Redirect("/swagger"));

app.MapControllers();
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();

app.UseCors("AllowFrontend");

app.Run();
