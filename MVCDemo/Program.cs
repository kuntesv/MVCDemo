using System.Net.Mime;
using System.Text;

namespace MVCDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();


            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute
                (
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );


            //   server/controller/action/optionId

            //   http://localhopst:78562/home/index/20
            app.Run();



        }
    }
}
