using Lesson4.Shops;
using Lesson4.Shops.Models;

var abstractShop = new AbstractShop();

// Данные сервиса "Буквоед"
var httpBook = new Book()
{
    Name = "Преступление и наказание, Достоевкий",
    Price = 1150
};

// Данные сервиса "Мясной"
var httpMeet = new Meet()
{
    Animal = "Кролик",
    Money = 700
};

// Данные сервиса "Шоколадница"
var httpCandy = new Candy()
{
    Sweet = "Ириска",
    Cost = 300
};

// Универсальный метод добавления
abstractShop.AddToCatalog(new BookShop(httpBook));
abstractShop.AddToCatalog(new MeetShop(httpMeet));
abstractShop.AddToCatalog(new CandyShop(httpCandy));

var list = abstractShop.GetCatalog();

// Вывод в приложение с объединением категорий без фильтрации
list.ForEach(c =>
{
    Console.WriteLine(c.Name);
    Console.WriteLine(c.Cost);
    Console.WriteLine();
});

Console.ReadLine();
