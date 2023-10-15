using EFCoreInterceptor.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddDbContext<ApplicationDbContext>((provider, optionsBuilder) =>
{
    optionsBuilder.UseSqlite("Data Source=LocalDatabase.db");
    optionsBuilder.AddInterceptors(new ServiceInjectorInterceptor(provider));
});


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
