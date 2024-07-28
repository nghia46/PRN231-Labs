using BusinisseObjects.Models;
using Dao;
using Repositoy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
# region ScopedServices
// Add Dao services
builder.Services.AddScoped<CategoryDao>();
builder.Services.AddScoped<ProductDao>();
builder.Services.AddScoped<OrderDao>();
builder.Services.AddScoped<OrderDetailDao>();
builder.Services.AddScoped<MemberDao>();
builder.Services.AddScoped<IGenericRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IGenericRepository<Product>, ProductRepository>();
builder.Services.AddScoped<IGenericRepository<Order>, OrderRepository>();
builder.Services.AddScoped<IGenericRepository<OrderDetail>, OrderDetailRepository>();
builder.Services.AddScoped<IGenericRepository<Member>, MemberRepository>();
// Add Repository services

# endregion
#region CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.UseCors();

app.Run();