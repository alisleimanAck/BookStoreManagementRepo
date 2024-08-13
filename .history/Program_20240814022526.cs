// public class Program
// {
//     public static void Main(string[] args)
//     {
//         CreateHostBuilder(args).Build().Run();
//     }

//     public static IHostBuilder CreateHostBuilder(string[] args) =>
//         Host.CreateDefaultBuilder(args)
//             .ConfigureAppConfiguration((context, config) =>
//             {
//                 var env = context.HostingEnvironment;
//                 config.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: true);
//             })
//             .ConfigureWebHostDefaults(webBuilder =>
//             {
//                 webBuilder.UseStartup<IStartup>();
//             });
// }
