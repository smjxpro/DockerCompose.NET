using Application.Handlers;
using Infrastructure.Extensions;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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

app.Run();