using Identity.Properties;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


var users = new List<User>();

app.MapGet("/list", () =>
{
    return users;

});


app.MapPost("/register", (Register body) =>
{
    
    users.Add(new User()
    {
        login = body.login,
        password = body.password,
        id = Guid.NewGuid()

    });
    
    return "Ok";

});

app.MapPost("/login", (Login body) =>
{
    var user = users.Find(u => u.login == body.login);
    if (user == null) 
        return "Неверный логин";
    if (user.password == body.password) 
        return "Вход выполнен";
    return "Неверный пароль";

});

app.MapPost("/Role", handler: (ChangeRole body) =>
{
    var user = users.Find(u => u.id == body.id);
    if (user == null) 
        return "Неверный логин";
    user.role = body.role;
    return "Успешно";


});

app.Run();
