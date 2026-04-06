using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// app.MapGet("/", () => "Добро пожаловать на срвер!");
// app.MapGet("/about", () => "Это мой первый ASP.NET Core серрвер");
// app.MapGet("/time", () => $"Время на сервере {DateTime.Now}");
// app.MapGet("/hello/{name}", (string name) => $"Привет {name}");

// app.MapGet("/sum/{a}/{b}", (int a, int b) => $"Сумма {a+b}");

// app.MapGet("/student", () => new {
//     Name = "Иван Иванов",
//     Group = "Исп 233",
//     Year = 3,
//     IsActive = true
// });

// app.MapGet("/subjects", () => new[] {
//     "рпм",
//     "рпм",
//     "исрпо",
//     "сп"
// });


// app.MapGet("/product/{id}", (int id) => new Product (
//     Id: id,
//     Name : $"Товар #{id}",
//     Price : id * 99.99m,
//     InStock : id % 2 == 0
// ));


// app.Use(async ( context, next ) => {
//     Console.WriteLine($"[LOG] {context.Request.Method} {context.Request.Path}");
//     await next(context);
//     Console.WriteLine($"[LOG] Ответ отправлен {context.Response.StatusCode}");
// });

// app.Use(async ( context, next ) => {
//     context.Response.Headers.Append("X-Powered-By" , "ASP.NET Core Lab27");
//     await next(context);
// });


// app.Use(async (context, next) =>
// {
//     var key = context.Request.Query["key"]; //берем значени параметра кей
    
//     if (key != "secret") 
//     {
//         context.Response.StatusCode = 401;  
//         await context.Response.WriteAsync("Access denied. Valid 'key' parameter required.");
//         return; 
//     }
    
//     await next(); 
// });


app.Use(async (context , next) => {
   var method = context.Request.Method;
   var path = context.Request.Path;
   Console.WriteLine($"-> {method} {path}");
   await next(context); 
});


app.MapGet("/me", () => Results.Ok(new {
    Name = "Иван Иванович",
    Group = "Исп 233",
    Course = 3,
    Skills = new[] {"c#" , "hyml", "css","js"}
}));


app.MapGet("/calc/{a}/{b}" , (double  a, double b) =>
    Results.Ok(new {
        A = a,
        B = b,
        Sum = a + b ,
        Diff = a - b ,
        Mul = a * b ,
        Div = b != 0 ? a / b : 0
    })
);


app.MapFallback(() => Results.NotFound(new {
    Error = "Машрут не найден",
    Code = 404
}));






app.Run();


// record Product(int Id, string Name, decimal Price, bool InStock);