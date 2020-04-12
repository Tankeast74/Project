using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Project.Models;
using System.Linq;

namespace Project.Data
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(
                        new Product { Name = "Гамбургер", Category = "Бургеры", Description = "Гамбургер", Price = 100, ImgPath = "" },
                        new Product { Name = "Чизбургер", Category = "Бургеры", Description = "Чизбургер", Price = 100, ImgPath = "" },
                        new Product { Name = "Филадельфия", Category = "Роллы", Description = "Филадельфия", Price = 100, ImgPath = "" },
                        new Product { Name = "Калифорния", Category = "Роллы", Description = "Калифорния", Price = 100, ImgPath = "" },
                        new Product { Name = "Пепперони", Category = "Пицца", Description = "Пепперони", Price = 100, ImgPath = "" },
                        new Product { Name = "Маргарита", Category = "Пицца", Description = "Маргарита", Price = 100, ImgPath = "" }
                    );
                    context.SaveChanges();
                }
            }

        }
    }
}
