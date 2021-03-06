using Application.Handlers;
using Infrastructure.Extensions;
using MediatR;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            // builder.WithOrigins("http://example.com",
            //     "http://www.contoso.com");

            builder.AllowAnyMethod();
            builder.AllowAnyOrigin();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(GetAllTodoQueryHandler));

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDevInfrastructure(builder.Configuration);
}
else
{
    builder.Services.AddProdInfrastructure();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();