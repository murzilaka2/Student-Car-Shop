using Microsoft.EntityFrameworkCore;
using ShopApplication.Data;
using ShopApplication.Data.Interfaces;
using ShopApplication.Data.Mocks;
using ShopApplication.Data.Models;
using ShopApplication.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//если 2 пользователя зайдут в корзину, то будет выданы разные корзины
builder.Services.AddScoped(e => ShopCart.GetCart(e));
//подключаем MVC сервис для работы с проектом
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddMemoryCache();
builder.Services.AddSession();
//builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
//позволяет объединить между собой интерефес и класс, который реализует данный интерфейс
//первый параметр сам интерфес, второй - сам класс
//за счет регистрации сервиса, мы можем использовать данные класса
//внутри контроллера
builder.Services.AddTransient<IAllCars, CarRepository>();
builder.Services.AddTransient<ICarsCategory, CategoryRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();
builder.Services.AddTransient<IAllOrders, OrdersRepository>();
//получение файла настроек для устанвоки соединения с базой данных
IConfigurationRoot _confString = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("dbsettings.json").Build();
//подключение файла в общие сервисы (в самом файле нас интересует одна строка - DefaultConnection).
//options.UseSqlServer - необходимо подключить пространство имен
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));

var app = builder.Build();
//при старте программы, вызываем функцию Initial для заполнения данными
using (var scope = app.Services.CreateScope())
{
    //подключаем AppDbContext и на основе данного класса мы сможем подключаться к базе данных
    //и работать с ней (добавлять значения, удалять и т.д.)
    AppDbContext appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DbObjects.Initial(appDbContext);
}
//указываем что будем использовать сессии
app.UseSession();
//позволяет выводить возникшие ошибки на страницу
app.UseDeveloperExceptionPage();
//позволяет отображать коды страниц
app.UseStatusCodePages();
//позволяет отображать различные css, html файлы и картинки
app.UseStaticFiles();
//позволяет использовать встроенную маршрутизацию и сразу же
//появляется возможность обрабатывать запросы как в MVC 
//При этом что бы работало, при регистрации сервиса MVC на 7 строке
//добавляем в параметры: options => options.EnableEndpointRouting = false
//app.UseMvcWithDefaultRoute();

//Собственные URL адреса
app.UseMvc(routes =>
{
    //устаналиваем страницу по умолчанию. Параметр Id? - является не обязательным
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
    //Если оставляем параметр action без названия представления, может использоваться любое
    //представление. Сам параметр category, должен точно совпадать с параметром метода
    //в контроллере. Значение по умолчанию defaults, указываем какой контроллер и метод будет использоваться по умолчанию
    //на случай если мы не передадим параметры /{action}/{category?}, в контроллере Car
    routes.MapRoute(name: "categoryFilter", template: "{Car}/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
});

app.Run();

