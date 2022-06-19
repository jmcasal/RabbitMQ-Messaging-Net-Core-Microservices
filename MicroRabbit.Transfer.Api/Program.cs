using MediatR;

using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Infra.IoC;

using Microsoft.EntityFrameworkCore;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Domain.Events;
using MicroRabbit.Transfer.Domain.EventsHandlers;

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
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microservice V1");
});

// ---------------------------------------------------------------------------------------------------------------------------
// https://stackoverflow.com/questions/56781385/no-operations-defined-in-spec-i-get-this-error-even-though-the-swagger-is-set
// ---------------------------------------------------------------------------------------------------------------------------
app.MapControllers();

ConfigureEventBus(app);


app.Run();

void ConfigureServices(WebApplicationBuilder builder)
{
    var services = builder.Services;
    var configuration = builder.Configuration;

    services.AddDbContext<TransferDbContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("TransferDbConnection"));
    });

    services.AddEndpointsApiExplorer();

    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Transfer Microservice", Version = "v1" });
    });


    services.AddMediatR(typeof(Program));

    services.AddControllers();

}

static void ConfigureEventBus(WebApplication app)
{
    var eventBus = app.Services.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();
}
