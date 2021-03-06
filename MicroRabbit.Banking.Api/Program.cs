using MediatR;

using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Infra.IoC;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();

DependencyContainer.Register(builder.Services);



ConfigureServices(builder);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapRazorPages();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microservice V1");
});

// ---------------------------------------------------------------------------------------------------------------------------
// https://stackoverflow.com/questions/56781385/no-operations-defined-in-spec-i-get-this-error-even-though-the-swagger-is-set
// ---------------------------------------------------------------------------------------------------------------------------
app.MapControllers(); 


app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    var services = builder.Services;
    var configuration = builder.Configuration;

    services.AddDbContext<BankingDbContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("BankingDbConnection"));
    });

    services.AddEndpointsApiExplorer();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Banking Microservice", Version = "v1" });
    });


    services.AddMediatR(typeof(Program));

    services.AddControllers(); 

}
