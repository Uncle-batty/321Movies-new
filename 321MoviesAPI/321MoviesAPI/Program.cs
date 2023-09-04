using _321MoviesAPI.Data;
using _321MoviesAPI.Modle;
using _321MoviesAPI.Modles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Add dbContext, here you can we are using In-memory database.
builder.Services.AddDbContext<MyDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();


app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});

//my endpoints

app.MapPost("/SaveCatagory", async (Catagory catagory, MyDataContext db) =>
{
    // Don't set the ID property, let the database generate it
    db.Catagories.Add(catagory);
    await db.SaveChangesAsync();

    return Results.Created($"/save/{catagory.ID}", catagory);
});


app.MapGet("/GetAllCatagories", async (MyDataContext db) =>
    await db.Catagories.ToListAsync());

app.MapGet("/GetCatById/{id}", async (int id, MyDataContext db) =>
    await db.Catagories.FindAsync(id)
        is Catagory catagory
            ? Results.Ok(catagory)
            : Results.NotFound());

app.MapPut("/UpdateCat/{id}", async (int id, Catagory  catinput, MyDataContext db) =>
{
    var student = await db.Catagories.FindAsync(id);

    if (student is null) return Results.NotFound();

    student.Title = catinput.Title;
    student.Discription = catinput.Discription;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/DeleteCat/{id}", async (int id, MyDataContext db) =>
{
    if (await db.Catagories.FindAsync(id) is Catagory student)
    {
        db.Catagories.Remove(student);
        await db.SaveChangesAsync();
        return Results.Ok(student);
    }

    return Results.NotFound();
});

//Director endpoints 
app.MapPost("/SaveDirector", async (Directors directorss, MyDataContext db) =>
{
    db.directors.Add(directorss);
    await db.SaveChangesAsync();

    return Results.Created($"/save/{directorss.ID}", directorss);
});

app.MapGet("/GetAllDirctors", async (MyDataContext db) =>
    await db.directors.ToListAsync());

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
