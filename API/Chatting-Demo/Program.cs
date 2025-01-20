using Chatting_Demo.DataAccess;
using Chatting_Demo.Signal_R;
using Microsoft.AspNetCore.SignalR.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://localhost:4200")  // Specify allowed origin
               .AllowCredentials()  // Allow credentials like cookies, authorization tokens
               .AllowAnyMethod()   // Allow any HTTP method (GET, POST, etc.)
               .AllowAnyHeader();  // Allow any header
    });
});
builder.Services.AddSingleton<IUserRepository, UsersRepository>();
builder.Services.AddSingleton<ChattingClient>();
// Register the SignalR HubConnection
builder.Services.AddSingleton(provider =>
{
    var hubConnection = new HubConnectionBuilder()
        .WithUrl("http://localhost:5002/chathub") // Replace with your hub URL
        .Build();

    return hubConnection;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.UseCors("AllowSpecificOrigin");

app.UseRouting();

app.MapHub<ChattingHub>("/chathub");

app.Run();
