using Business.DependencyResolvers;
using Business.Extensions;
using DataAccess.DependencyInjection;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddBusinessServices()
    .AddEfCoreServices(builder.Configuration)
    .AddFluentValidationWithAssemblies();

// Hangfire'ý ekleyin
builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection")); // Hangfire için veritabaný (libraryDb'ye kaydedildi)
});

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

// Hangfire sunucusu
app.UseHangfireServer();

// Hangfire yönetim panelini
app.UseHangfireDashboard("/hangfire");




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

