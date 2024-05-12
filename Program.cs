using TS.Bootcamp.MinimalWebAPI.Dtos;
using TS.Bootcamp.MinimalWebAPI.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// eðer minimal apilerde servisleri parametre olarak inject etmek istemiyorsak ve bütün uç noktalarda kullanmak istiyorsak bu yöntem ile ilerleyebiliyoruz.
//var provider = builder.Services.BuildServiceProvider();
//var userService = provider.GetRequiredService<IUserService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
var users = new List<AppUser>();

//app.MapGet("api/getallusers", /*parametre istiyorsak burada parantezler içersinde verilecek*/ async (IUserService userService, int age, string name) =>
//{
//    await userService.CreateUserAsync();
//    await Task.CompletedTask;
//    return "API is working...";
//});


app.MapPost("api/createuser", (CreateAppUserDto request) =>
{
    AppUser appUser = new AppUser()
    {
        Email = request.Email,
        Password = request.Password,
        FirstName = request.FirstName,
        LastName = request.LastName,
    };

    users.Add(appUser);
    return Results.Ok(new { Message = "User created" });
});


app.MapGet("api/getallusers", () =>
{
    return Results.Ok(users);
});

app.Run();