using LabProject.Data;
using LabProject.Models.Customers;
using LabProject.Models.Sales;
using LabProject.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SalesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SalesContext") ?? throw new InvalidOperationException("Connection string 'SalesContext' not found.")));
builder.Services.AddDbContext<CustomersContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomersContext") ?? throw new InvalidOperationException("Connection string 'CustomersContext' not found.")));
builder.Services.AddTransient<CustomersRepo>();
builder.Services.AddTransient<OrderDetailsRepo>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

#region BBDD
//Creación de las tablas de BBDD
//using (var scope = app.Services.CreateScope())
//{
//    SalesContext context = scope.ServiceProvider.GetRequiredService<SalesContext>();
//    context.Database.Migrate();
//}
// Configure the HTTP request pipeline.

//Insercción de datos
//using (var customerContext = new CustomersContext)
//using (var salesContext = new SalesContext())
//{
//    // Nos aseguramos de que la base de datos esté creada.
//    salesContext.Database.EnsureCreated();

#region Customer
// Agregamos 10 datos de prueba.
//    if (!customersContext.Customer.Any())
//        {
//            for (int i = 1; i <= 10; i++)
//            {
//                customersContext.Customer.Add(new Customer
//                {
                    //Name = $"Name{i}",
                    //Surname = $"Surname{i}",
                    //Lastname = $"Lastname{i}",
                    //DateOfBirthday = new DateTime(1990 + i, i, 15),
                    //Email = $"person{i}@example.com",
                    //CountryOfResidence = $"Country{i}"
//                });
//            }

//            salesContext.SaveChanges();
//        }
#endregion

#region Order
// Agregamos 10 datos de prueba.
//    if (!salesContext.Order.Any())
//        {
//            for (int i = 1; i <= 10; i++)
//            {
//                salesContext.Order.Add(new Order
//                {
//                    CustomerId = i,
//                    OrderDate = DateTime.Now.AddDays(-i)
//                });
//            }

//            salesContext.SaveChanges();
//        }
#endregion

#region OrderDetail
//    // Agregamos 10 datos de prueba.
//    if (!salesContext.OrderDetail.Any())
//        {
//            for (int i = 1; i <= 10; i++)
//            {
//                salesContext.OrderDetail.Add(new OrderDetail
//                {
//                    OrderId = i,
//                    Sku = i * 100,
//                    SkuName = $"Product{i}",
//                    Amount = i * 2,
//                    UnitPrice = 10.5 * i
//                });
//            }

//            salesContext.SaveChanges();
//        }
#endregion
//}

#endregion

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
