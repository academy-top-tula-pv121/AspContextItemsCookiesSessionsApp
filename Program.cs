namespace AspContextItemsCookiesSessionsApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.Run(async context =>
            {
                if(context.Request.Cookies.ContainsKey("books"))
                {
                    string booksValue = context.Request.Cookies["books"];
                    await context.Response.WriteAsync($"Books Value: {booksValue}");
                }
                else
                {
                    context.Response.Cookies.Append("books", "List of books");
                    await context.Response.WriteAsync($"Hello!");
                }
            });



            //Context.Items

            //app.Use(async (context, next) =>
            //{
            //    //
            //    context.Items["books"] = "List of books";
            //    await next(context);
            //});

            //app.Run(async context => await context
            //                            .Response
            //                            .WriteAsync($"books: {context.Items["books"]}"));

            app.Run();
        }
    }
}